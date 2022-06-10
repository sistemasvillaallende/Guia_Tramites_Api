using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Guia_Tramites_Api.Entities
{
    public class sub_pasos : DALBase
    {
        public int id { get; set; }
        public string texto { get; set; }
        public int id_paso { get; set; }
        public int enlazado_a { get; set; }
        public int orden { get; set; }

        public sub_pasos()
        {
            id = 0;
            texto = string.Empty;
            id_paso = 0;
            enlazado_a = 0;
            orden = 0;
        }

        private static List<sub_pasos> mapeo(SqlDataReader dr)
        {
            List<sub_pasos> lst = new List<sub_pasos>();
            sub_pasos obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new sub_pasos();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.texto = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.id_paso = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.enlazado_a = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.orden = dr.GetInt32(4); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<sub_pasos> read(int idPaso)
        {
            try
            {
                List<sub_pasos> lst = new List<sub_pasos>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM sub_pasos WHERE id_paso=@id_paso";
                    cmd.Parameters.AddWithValue("@id_paso", idPaso);
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

        public static sub_pasos getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM sub_pasos WHERE");
                sql.AppendLine("id = @id");
                sub_pasos obj = null;
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<sub_pasos> lst = mapeo(dr);
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

        public static int insert(sub_pasos obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO sub_pasos(");
                sql.AppendLine("texto");
                sql.AppendLine(", id_paso");
                sql.AppendLine(", enlazado_a");
                sql.AppendLine(", orden");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@texto");
                sql.AppendLine(", @id_paso");
                sql.AppendLine(", @enlazado_a");
                sql.AppendLine(", @orden");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@texto", obj.texto);
                    cmd.Parameters.AddWithValue("@id_paso", obj.id_paso);
                    cmd.Parameters.AddWithValue("@enlazado_a", obj.enlazado_a);
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

        public static void update(sub_pasos obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  sub_pasos SET");
                sql.AppendLine("texto=@texto");
                sql.AppendLine(", id_paso=@id_paso");
                sql.AppendLine(", enlazado_a=@enlazado_a");
                sql.AppendLine(", orden=@orden");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@texto", obj.texto);
                    cmd.Parameters.AddWithValue("@id_paso", obj.id_paso);
                    cmd.Parameters.AddWithValue("@enlazado_a", obj.enlazado_a);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(sub_pasos obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  sub_pasos ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
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

    }
}

