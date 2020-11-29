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
    public class TransmissionRepositoryADO : ITransmissionRepository
    {
        public List<Transmission> GetAll()
        {
            List<Transmission> transmissions = new List<Transmission>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransmissionSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Transmission currentRow = new Transmission();
                        currentRow.TransmissionID = (int)dr["TransmissionID"];
                        currentRow.Gears = dr["Gears"].ToString();

                        transmissions.Add(currentRow);
                    }
                }
            }
            return transmissions;
        }
    }
}
