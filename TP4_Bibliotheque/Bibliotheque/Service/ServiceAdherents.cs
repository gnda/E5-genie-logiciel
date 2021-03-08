using Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceAdherents : Service
    {
        public ServiceAdherents(IDataAccess factory) : base(factory) { }


        public List<Adherent> ObtenirListe()
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                List<Adherent> liste = depotAdherents.Query().ToList();
                uow.Commit();
                return liste;
            }
        }

        public void Ajouter(Adherent ad)
        {
            depotAdherents.Create(ad);
        }

        public void Modifier(Adherent ad)
        {
            depotAdherents.Update(ad);
        }

        public void Supprimer(Adherent ad)
        {

            //vérifier si l'adhérent a des prets
            if (ad.Prets != null)
            {
                if (ad.Prets.Count != 0) throw new Exception("L'adhérent ne peut pas être supprimé car il possède encore des emprunts");
                else
                {
                    depotAdherents.Delete(ad);
                }
            }
            else
            {
                depotAdherents.Delete(ad);
            }
           
        }


    }
}
