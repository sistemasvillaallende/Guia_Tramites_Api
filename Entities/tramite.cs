using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Guia_Tramites_Api.Entities
{
    public class tramite : DALBase
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int id_unidad_administrativa { get; set; }
        public bool activa { get; set; }
        public bool deleted { get; set; }
        public bool fecha_deleted { get; set; }
        public int usuario_deleted { get; set; }
        public int orden { get; set; }
        public tramite()
        {
            id = 0;
            nombre = string.Empty;
            descripcion = string.Empty;
            id_unidad_administrativa = 0;
            activa = false;
        }

        private static List<tramite> mapeo(SqlDataReader dr)
        {
            List<tramite> lst = new List<tramite>();
            tramite obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new tramite();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.nombre = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.descripcion = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.id_unidad_administrativa = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.activa = dr.GetBoolean(4); }

                    if (!dr.IsDBNull(5)) { obj.deleted = dr.GetBoolean(5); }
                    if (!dr.IsDBNull(6)) { obj.fecha_deleted = dr.GetBoolean(6); }
                    if (!dr.IsDBNull(7)) { obj.usuario_deleted = dr.GetInt32(7); }
                    if (!dr.IsDBNull(8)) { obj.orden = dr.GetInt32(8); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<tramite> read(int idUnidadOrganizativa)
        {
            try
            {
                List<tramite> lst = new List<tramite>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT *FROM tramite 
                                        WHERE deleted=0 
                                        AND id_unidad_administrativa=@id_unidad_administrativa
                                        ORDEN BY orden";
                    cmd.Parameters.AddWithValue("@id_unidad_administrativa", idUnidadOrganizativa);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<tramite> readActivas(int idUnidadOrganizativa)
        {
            try
            {
                List<tramite> lst = new List<tramite>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT *FROM tramite 
                                        WHERE deleted=0 
                                        AND activa=1
                                        AND id_unidad_administrativa=@id_unidad_administrativa
                                        ORDEN BY orden";
                    cmd.Parameters.AddWithValue("@id_unidad_administrativa", idUnidadOrganizativa);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static tramite getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM tramite WHERE");
                sql.AppendLine("id = @id");
                tramite obj = null;
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<tramite> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int insert(tramite obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO tramite(");
                sql.AppendLine("nombre");
                sql.AppendLine(", descripcion");
                sql.AppendLine(", id_unidad_administrativa");
                sql.AppendLine(", activa");
                sql.AppendLine(", deleted");
                sql.AppendLine(", orden");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@nombre");
                sql.AppendLine(", @descripcion");
                sql.AppendLine(", @id_unidad_administrativa");
                sql.AppendLine(", false");
                sql.AppendLine(", 0");
                sql.AppendLine(", @orden");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("@id_unidad_administrativa", obj.id_unidad_administrativa);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(tramite obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  tramite SET");
                sql.AppendLine("nombre=@nombre");
                sql.AppendLine(", descripcion=@descripcion");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void activaDesactiva(int id, bool activa)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE tramite SET");
                sql.AppendLine("activa=@activa");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@activa", activa);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void delete(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE tramite SET");
                sql.AppendLine("deleted=1, fecha_deleted=GETDATE()");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int maxOrden(int idUnidadAdministrativa)
        {
            try
            {
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        @"SELECT ISNULL(MAX(orden), 0) FROM tramite 
                        WHERE id_unidad_administrativa=@id_unidad_administrativa";
                    cmd.Parameters.AddWithValue("@id_unidad_administrativa", idUnidadAdministrativa);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void reordenarLista(int id, int orden)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE tramite");
                sql.AppendLine("SET orden=@orden");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@orden", orden);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

