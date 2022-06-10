using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guia_Tramites_Api.Services
{
    public interface ITramitesService
    {
        public List<Entities.tramite> read(int idUnidadAdministrativa);
        public Entities.tramite getByPk(int id);
        public int insert(Entities.tramite obj);
        public void update(Entities.tramite obj);
        public void delete(int id);
        public void updateActiva(int id, bool activa);
        public void reordenar(List<Entities.tramite> lst);
    }
}
