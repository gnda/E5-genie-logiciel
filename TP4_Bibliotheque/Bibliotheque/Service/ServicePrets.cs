using Domaine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class ServicePrets : Service
    {
        public ServicePrets(IDataAccess factory) : base(factory) { }

        public List<Pret> ObtenirListeParAdherent(int id_adherent)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                List<Pret> liste = depotPrets.Query().Where(p => p.Adherent.Id == id_adherent).ToList();
                uow.Commit();
                return liste;
            }
        }


        public void TraiterEmprunt(int idAdherent, int idExemplaire)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                Adherent adh = depotAdherents.Read(idAdherent);
                Exemplaire ex = depotExemplaires.Read(idExemplaire);

                if(adh == null)  throw new Exception(" Pas d'adherent");
                if (ex == null) throw new Exception(" Pas d'exemplaire");
                adh.Emprunte(ex);
                depotAdherents.Update(adh);

                uow.Commit();
            }
        }

        public void TraiterRetour(int idExemplaire)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                Exemplaire ex = depotExemplaires.Read(idExemplaire);
                if (ex == null) throw new Exception(" Pas d'exemplaire");
                
                if (ex.Adherent == null) throw new Exception(" Pas d'adherent, livre non emprunté");

                Adherent adh = ex.Adherent;
                adh.Retourne(ex);
                depotAdherents.Update(adh);
                depotExemplaires.Update(ex);
                uow.Commit();
            }
        }
    }
}
