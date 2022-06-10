using Guia_Tramites_Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Guia_Tramites_Api.Services
{
    public class TramitesService : ITramitesService
    {
        public void delete(int id)
        {
            try
            {
                Entities.tramite.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tramite getByPk(int id)
        {
            try
            {
                return Entities.tramite.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insert(tramite obj)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    int id = Entities.tramite.insert(obj);
                    List<Entities.pasos> lstPasos =
                        Entities.pasos.read();
                    foreach (var item in lstPasos)
                    {
                        Entities.pasos_x_tramite objPaso = new pasos_x_tramite();
                        objPaso.id_paso = item.id;
                        objPaso.id_tramite = id;
                        Entities.pasos_x_tramite.insert(objPaso);
                        List<Entities.sub_pasos> lstSubPasos =
                            Entities.sub_pasos.read(item.id);
                        foreach (var item2 in lstSubPasos)
                        {
                            Entities.sub_pasos_x_paso_x_tramite objSubPaso =
                                new sub_pasos_x_paso_x_tramite();
                            objSubPaso.id_paso = item.id;
                            objSubPaso.id_sub_paso = item.id;
                            objSubPaso.id_tramite = id;
                            Entities.sub_pasos_x_paso_x_tramite.insert(objSubPaso);
                        }
                    }
                    scope.Complete();
                    return id;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tramite> read(int idUnidadAdministrativa)
        {
            try
            {
                return Entities.tramite.read(idUnidadAdministrativa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void reordenar(List<tramite> lst)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        Entities.tramite.reordenarLista(lst[i].id,
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

        public void update(tramite obj)
        {
            try
            {
                Entities.tramite.update(obj);
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
                Entities.tramite.activaDesactiva(id, activa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
