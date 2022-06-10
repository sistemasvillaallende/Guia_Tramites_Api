using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Guia_Tramites_Api.Entities
{
    public class sub_pasos_x_paso_x_tramite : DALBase
    {
        public int id { get; set; }
        public int id_tramite { get; set; }
        public int id_paso { get; set; }
        public int id_sub_paso { get; set; }
        public bool activo { get; set; }

        public sub_pasos_x_paso_x_tramite()
        {
            id = 0;
            id_tramite = 0;
            id_paso = 0;
            id_sub_paso = 0;
            activo = false;
        }

        private static List<sub_pasos_x_paso_x_tramite> mapeo(SqlDataReader dr)
        {
            List<sub_pasos_x_paso_x_tramite> lst = new List<sub_pasos_x_paso_x_tramite>();
            sub_pasos_x_paso_x_tramite obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new sub_pasos_x_paso_x_tramite();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.id_tramite = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.id_paso = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.id_sub_paso = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.activo = dr.GetBoolean(4); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<sub_pasos_x_paso_x_tramite> read()
        {
            try
            {
                List<sub_pasos_x_paso_x_tramite> lst = new List<sub_pasos_x_paso_x_tramite>();
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM sub_pasos_x_paso_x_tramite";
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

        public static sub_pasos_x_paso_x_tramite getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM sub_pasos_x_paso_x_tramite WHERE");
                sub_pasos_x_paso_x_tramite obj = null;
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<sub_pasos_x_paso_x_tramite> lst = mapeo(dr);
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

        public static int insert(sub_pasos_x_paso_x_tramite obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO sub_pasos_x_paso_x_tramite(");
                sql.AppendLine("id");
                sql.AppendLine(", id_tramite");
                sql.AppendLine(", id_paso");
                sql.AppendLine(", id_sub_paso");
                sql.AppendLine(", activo");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id");
                sql.AppendLine(", @id_tramite");
                sql.AppendLine(", @id_paso");
                sql.AppendLine(", @id_sub_paso");
                sql.AppendLine(", @activo");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@id_tramite", obj.id_tramite);
                    cmd.Parameters.AddWithValue("@id_paso", obj.id_paso);
                    cmd.Parameters.AddWithValue("@id_sub_paso", obj.id_sub_paso);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(sub_pasos_x_paso_x_tramite obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  sub_pasos_x_paso_x_tramite SET");
                sql.AppendLine("id=@id");
                sql.AppendLine(", id_tramite=@id_tramite");
                sql.AppendLine(", id_paso=@id_paso");
                sql.AppendLine(", id_sub_paso=@id_sub_paso");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine("WHERE");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@id_tramite", obj.id_tramite);
                    cmd.Parameters.AddWithValue("@id_paso", obj.id_paso);
                    cmd.Parameters.AddWithValue("@id_sub_paso", obj.id_sub_paso);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(sub_pasos_x_paso_x_tramite obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  sub_pasos_x_paso_x_tramite ");
                sql.AppendLine("WHERE");
                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
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

