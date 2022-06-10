using Guia_Tramites_Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Guia_Tramites_Api.Services
{
    public class UnidadAdministrativaService : IUnidadAdministrativaService
    {
        public void cambiarOrden(List<unidad_administrativa> lst)
        {
            throw new NotImplementedException();
        }

        public void delete(int id)
        {
            try
            {
                Entities.unidad_administrativa.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public unidad_administrativa getByPk(int id)
        {
            try
            {
                return Entities.unidad_administrativa.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insert(unidad_administrativa obj)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    int maxOrden = unidad_administrativa.maxOrden();
                    obj.orden = maxOrden + 1;
                    int id = unidad_administrativa.insert(obj);                    
                    scope.Complete();
                    return id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<unidad_administrativa> read()
        {
            try
            {
                return Entities.unidad_administrativa.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void reordenar(List<Reordenar> lst)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        Entities.unidad_administrativa.reordenarLista(lst[i].id,
                            i + 1);
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(unidad_administrativa obj)
        {
            try
            {
                Entities.unidad_administrativa.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateActiva(int id, bool activa)
        {
            try
            {
                Entities.unidad_administrativa.updateActiva(id, activa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
