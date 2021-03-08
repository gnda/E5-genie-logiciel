using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using Domaine;
using Persistance;
using System.Collections.Generic;
using NHibernate;

namespace TestBibliotheque
{
    [TestClass]
    public class TestService
    {
        ISessionFactory sessionFactory;
        IDataAccess dataAccess;
        ServicePrets servicePrets;

        Adherent adherent;
        Ouvrage ouvrage;
        Exemplaire exemplaire1, exemplaire2;

        [TestInitialize]
        public void SetUp()
        {
            sessionFactory = ORM<Adherent>.CreateSessionFactory(true);
            dataAccess = new DataAccess(sessionFactory);
            servicePrets = new ServicePrets(dataAccess);
            CreateFixtures();
            PopulateDatabase();
        }

        [TestCleanup]
        public void TearDown()
        {
            dataAccess.Dispose();
            sessionFactory.Dispose();
        }

        void CreateFixtures()
        {
            adherent = new Adherent { Nom = "Mario Rossi" };
            ouvrage = new Ouvrage { Titre = "Il grande Gatsby", Auteur = "F. S. Fitzgerald" };
            exemplaire1 = new Exemplaire { Ouvrage = ouvrage, Etat = "Nuovo" };
            exemplaire2 = new Exemplaire { Ouvrage = ouvrage, Etat = "Usato" };
        }

        void PopulateDatabase()
        {
            using (ISession session = sessionFactory.OpenSession())
            using (ITransaction uow = session.BeginTransaction())
            {
                session.Save(adherent);
                session.Save(ouvrage);
                session.Save(exemplaire1);
                session.Save(exemplaire2);
                uow.Commit();
            }
        }

        [TestMethod]
        public void EmpruntSucces()
        {
            servicePrets.TraiterEmprunt(adherent.Id, exemplaire1.Id);
            AssertPret(adherent.Id, exemplaire1.Id, true);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void EmpruntEchec()
        {
            servicePrets.TraiterEmprunt(adherent.Id, 3);
        }

        [TestMethod]
        public void RetourSucces()
        {
            servicePrets.TraiterEmprunt(adherent.Id, exemplaire1.Id);
            servicePrets.TraiterRetour(exemplaire1.Id);
            AssertPret(adherent.Id, exemplaire1.Id, false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RetourEchec()
        {
            servicePrets.TraiterRetour(exemplaire1.Id);
        }

        void AssertPret(int id_adherent, int id_exemplaire, bool estEnCours)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                Adherent ad = session.Get<Adherent>(id_adherent);
                Exemplaire ex = session.Get<Exemplaire>(id_exemplaire);
                Assert.AreEqual(ex.Id, ad.Prets[0].Exemplaire.Id);
                if (estEnCours)
                    Assert.AreEqual(ad.Id, ex.Adherent.Id);
                else
                    Assert.IsNull(ex.Adherent);
            }
        }
    }
}
