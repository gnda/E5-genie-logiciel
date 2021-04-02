using Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceOuvrages : Service
    {
        public ServiceOuvrages(IDataAccess factory) : base(factory) { }

        public List<Ouvrage> ObtenirListe()
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                List<Ouvrage> liste = depotOuvrages.Query().ToList();
                uow.Commit();
                return liste;
            }
        }

        public void Ajouter(Ouvrage ouv)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                depotOuvrages.Create(ouv);
                uow.Commit();
            }
        }

        public void Modifier(Ouvrage ouv)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                depotOuvrages.Update(ouv);
                uow.Commit();
            }
        }

        public void Supprimer(Ouvrage ouv)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                depotOuvrages.Delete(ouv);
                uow.Commit();
            }
        }

    }
}
