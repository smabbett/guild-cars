using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables;
using System.Data.SqlClient;
using System.Data;
using GuildCars.Models.Queries;

namespace GuildCars.Data.ADO
{
    public class SpecialRepositoryADO : ISpecialRepository
    {
        public void Delete(int specialID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SpecialID", specialID);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public Special Get(int specialID)
        {
            Special special = new Special();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialSelectByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@specialID", specialID);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        special.SpecialDescription = dr["SpecialDescription"].ToString();
                        special.Title = dr["Title"].ToString();
                        special.SpecialID = (int)dr["SpecialID"];                   
                    }
                }
            }
            return special;
        }

        public List<Special> GetAll()
        {
            List<Special> specials = new List<Special>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Special currentRow = new Special();
               
                        currentRow.SpecialDescription = dr["SpecialDescription"].ToString();
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.SpecialID = (int)dr["SpecialID"];
                        currentRow.UserID = dr["UserID"].ToString();

                        specials.Add(currentRow);
                    }
                }
            }
            return specials;
        }

        public void Insert(Special special)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("SpecialID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Title", special.Title);
                cmd.Parameters.AddWithValue("@SpecialDescription", special.SpecialDescription);
                cmd.Parameters.AddWithValue("@UserID", special.UserID);

                cn.Open();

                cmd.ExecuteNonQuery();

                special.SpecialID = (int)param.Value;
            }
        }
    }
}
