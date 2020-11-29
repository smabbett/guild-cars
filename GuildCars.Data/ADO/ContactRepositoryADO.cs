using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables;
using System.Data.SqlClient;
using System.Data;

namespace GuildCars.Data.ADO
{
    public class ContactRepositoryADO : IContactRepository
    {
        public List<Contact> GetAll()
        {
            List<Contact> contacts = new List<Contact>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Contact currentRow = new Contact();
                        currentRow.ContactID = (int)dr["ContactID"];
                        currentRow.FullName = dr["FullName"].ToString();
                        currentRow.Email = dr["Email"].ToString();
                        currentRow.Phone = dr["Phone"].ToString();
                        currentRow.Message = dr["Message"].ToString();
                        currentRow.Vin = dr["Vin"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];

                        contacts.Add(currentRow);
                    }
                }
            }
            return contacts;
        }       
        public void Insert(Contact contact)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("ContactID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@FullName", contact.FullName);
                cmd.Parameters.AddWithValue("@Message", contact.Message);

                if (string.IsNullOrEmpty(contact.Email))
                {
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Email", contact.Email);
                }

                if (string.IsNullOrEmpty(contact.Phone))
                {
                    cmd.Parameters.AddWithValue("@Phone", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Phone", contact.Phone);
                }

                if (string.IsNullOrEmpty(contact.Vin))
                {
                    cmd.Parameters.AddWithValue("@Vin", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Vin", contact.Vin);
                }

                cn.Open();

                cmd.ExecuteNonQuery();

                contact.ContactID = (int)param.Value;
            }
        }
    }
}
