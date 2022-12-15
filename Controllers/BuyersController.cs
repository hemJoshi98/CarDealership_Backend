using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using UsedCarDashboard.Models;

namespace UsedCarDashboard.Controllers
{
    public class BuyersController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    SELECT BuyerID, FirstName, LastName, Age from dbo.Buyer 
            ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsedCarDashboard"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.Text;
                da.SelectCommand = cmd;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Buyers buyers)
        {
            try
            {
                string query = @"insert into dbo.Buyer (FirstName ,LastName, Age ) values('" + buyers.FirstName + "','" + buyers.LastName + "'," + buyers.Age + ")";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsedCarDashboard"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    da.SelectCommand = cmd;
                    da.Fill(table);
                }
                return "Buyer was added successfully";
            }
            catch (Exception)
            {

                return "Failed to Add Buyer";
            }
        }

        public string Put(Buyers buyers)
        {
            try
            {
                string query = @"update dbo.Buyer set FirstName = '" + buyers.FirstName + "' ,LastName = '" + buyers.LastName + "', Age =" + buyers.Age +" WHERE BuyerID="+buyers.BuyerID+@"";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsedCarDashboard"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    da.SelectCommand = cmd;
                    da.Fill(table);
                }
                return "Buyer detail was updated successfully";
            }
            catch (Exception)
            {

                return "Failed to update buyer detail.";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"delete from dbo.Buyer WHERE BuyerID=" + id + @"";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsedCarDashboard"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    da.SelectCommand = cmd;
                    da.Fill(table);
                }
                return "Buyer was deleted successfully";
            }
            catch (Exception)
            {

                return "Failed to delete buyer.";
            }
        }
    }
}
