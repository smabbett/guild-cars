using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.ADO
{
    public class CustomerRepositoryADO : ICustomerRepository
    {
        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CustomerSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Customer currentRow = new Customer();
                        currentRow.CustomerID = (int)dr["CustomerID"];
                        currentRow.FullName = dr["FullName"].ToString();
                        if (dr["Email"] != DBNull.Value)
                            currentRow.Email = dr["Email"].ToString();
                        if (dr["Phone"] != DBNull.Value)
                            currentRow.Phone = dr["Phone"].ToString();
                        currentRow.Street1 = dr["Street1"].ToString();
                        if (dr["Street2"] != DBNull.Value)
                            currentRow.Street2 = dr["Street2"].ToString();
                        currentRow.City = dr["City"].ToString();
                        currentRow.State = dr["State"].ToString();
                        currentRow.ZipCode = dr["ZipCode"].ToString();

                      

                        customers.Add(currentRow);
                    }
                }
            }
            return customers;
        }

        public void Insert(Customer customer)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CustomerInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("CustomerID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@FullName", customer.FullName);

                if (string.IsNullOrEmpty(customer.Email))
                {
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                }

                if (string.IsNullOrEmpty(customer.Phone))
                {
                    cmd.Parameters.AddWithValue("@Phone", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                }

                cmd.Parameters.AddWithValue("@Street1", customer.Street1);
                cmd.Parameters.AddWithValue("@City", customer.City);
                cmd.Parameters.AddWithValue("@State", customer.State);
                cmd.Parameters.AddWithValue("@ZipCode", customer.ZipCode);

                if (string.IsNullOrEmpty(customer.Street2))
                {
                    cmd.Parameters.AddWithValue("@Street2", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Street2", customer.Street2);
                }

                cn.Open();

                cmd.ExecuteNonQuery();

                customer.CustomerID = (int)param.Value;
            }
        }
    }
}
