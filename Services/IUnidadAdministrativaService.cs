using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guia_Tramites_Api.Services
{
    public interface IUnidadAdministrativaService
    {
        public List<Entities.unidad_administrativa> read();
        public Entities.unidad_administrativa getByPk(int id);
        public int insert(Entities.unidad_administrativa obj);
        public void update(Entities.unidad_administrativa obj);
        public void delete(int id);
        public void cambiarOrden(List<Entities.unidad_administrativa> lst);
        public void updateActiva(int id, bool activa);
        public void reordenar(List<Entities.Reordenar> lst);
    }
}
