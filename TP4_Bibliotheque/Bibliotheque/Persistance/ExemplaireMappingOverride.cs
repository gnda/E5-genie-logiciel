using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Automapping;
using Domaine;

namespace Bibliotheque.Persistance
{
    public class ExemplaireMappingOverride : IAutoMappingOverride<Exemplaire>
    {
        public void Override(AutoMapping<Exemplaire> mapping)
        {
            // TODO : La suppression de l'exemplaire ne doit pas entraîner celle de l'ouvrage...
        }
    }
}
