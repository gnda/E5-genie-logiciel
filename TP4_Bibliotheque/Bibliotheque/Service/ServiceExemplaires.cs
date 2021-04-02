using Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceExemplaires : Service
    {
        public ServiceExemplaires(IDataAccess factory) : base(factory) { }

        public List<Exemplaire> ObtenirListeParOuvrage(int id_ouvrage)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                List<Exemplaire> liste = depotExemplaires.Query().Where(ex => ex.Ouvrage.Id == id_ouvrage).ToList();
                uow.Commit();
                return liste;
            }
        }

        public void Ajouter(Exemplaire ex)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                depotExemplaires.Create(ex);
                uow.Commit();
            }
        }

        public void Modifier(Exemplaire ex)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                depotExemplaires.Update(ex);
                uow.Commit();
            }
        }

        public void Supprimer(Exemplaire ex)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                depotExemplaires.Delete(ex);
                uow.Commit();
            }
        }



    }
}
