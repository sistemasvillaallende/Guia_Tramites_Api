using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Guia_Tramites_Api.Entities
{
    public class unidad_administrativa : DALBase
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string icono { get; set; }
        public string imagen { get; set; }
        public string color { get; set; }
        public int cod_oficina { get; set; }
        public bool activa { get; set; }
        public bool deleted { get; set; }
        public DateTime fecha_deleted { get; set; }
        public int usuario_deleted { get; set; }
        public int orden { get; set; }
        public unidad_administrativa()
        {
            id = 0;
            nombre = string.Empty;
            icono = string.Empty;
            imagen = string.Empty;
            color = string.Empty;
            cod_oficina = 0;
            activa = false;
            deleted = false;
            orden = 0;
        }

        private static List<unidad_administrativa> mapeo(SqlDataReader dr)
        {
            List<unidad_administrativa> lst = new List<unidad_administrativa>();
            unidad_administrativa obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new unidad_administrativa();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.nombre = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.icono = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.imagen = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.color = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.cod_oficina = dr.GetInt32(5); }
                    if (!dr.IsDBNull(6)) { obj.activa = dr.GetBoolean(6); }
                    if (!dr.IsDBNull(7)) { obj.deleted = dr.GetBoolean(7); }
                    if (!dr.IsDBNull(8)) { obj.fecha_deleted = dr.GetDateTime(8); }
                    if (!dr.IsDBNull(9)) { obj.usuario_deleted = dr.GetInt32(9); }
                    if (!dr.IsDBNull(10)) { obj.orden = dr.GetInt32(10); }

                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static int maxOrden()
        {
            try
            {
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        @"SELECT ISNULL(MAX(orden), 0) FROM unidad_administrativa";
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<unidad_administrativa> read()
        {
            try
            {
                List<unidad_administrativa> lst = new List<unidad_administrativa>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM unidad_administrativa WHERE deleted=0 ORDER BY orden";
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
        public static List<unidad_administrativa> readActivas()
        {
            try
            {
                List<unidad_administrativa> lst = new List<unidad_administrativa>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM unidad_administrativa WHERE activa=1 AND deleted=0 ORDER BY orden";
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
        public static unidad_administrativa getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM unidad_administrativa WHERE");
                sql.AppendLine("id = @id");
                unidad_administrativa obj = null;
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<unidad_administrativa> lst = mapeo(dr);
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

        public static int insert(unidad_administrativa obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO unidad_administrativa(");
                sql.AppendLine("nombre");
                sql.AppendLine(", icono");
                sql.AppendLine(", color");
                sql.AppendLine(", orden");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@nombre");
                sql.AppendLine(", @icono");
                sql.AppendLine(", @color");
                sql.AppendLine(", @orden");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@icono", obj.icono);
                    cmd.Parameters.AddWithValue("@color", obj.color);
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

        public static void update(unidad_administrativa obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE unidad_administrativa SET");
                sql.AppendLine("nombre=@nombre");
                sql.AppendLine(", icono=@icono");
                sql.AppendLine(", color=@color");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@icono", obj.icono);
                    cmd.Parameters.AddWithValue("@color", obj.color);
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void updateActiva(int id, bool activa)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE unidad_administrativa SET");
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
                sql.AppendLine("UPDATE unidad_administrativa ");
                sql.AppendLine("SET deleted=1, fecha_deleted=GETDATE() WHERE");
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
        public static void reordenarLista(int id, int orden)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE unidad_administrativa");
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

