using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UsedCarDashboard.Models;
using System.Web.UI.WebControls;
using System.Web.Routing;

namespace UsedCarDashboard.Controllers
{
    public class UsersController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    SELECT FirstName,LastName,EmpType from dbo.Users 
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

        public string Post(Users users)
        {
            try
            {
                string query = @"DECLARE @responseMessage NVARCHAR(250) EXEC dbo.AddUser @pLogin = N'"+users.LoginName+"', @pPassword = N'"+users.PasswordHash+"', @pFirstName = N'"+users.FirstName+"', @pLastName = N'"+users.LastName+"', @pEmpType = N'"+users.EmpType+ "', @responseMessage=@responseMessage OUTPUT\r\n\r\nSELECT\t@responseMessage as N'@responseMessage'";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsedCarDashboard"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    da.SelectCommand = cmd;
                    da.Fill(table);
                }
                return table.Rows[0].Field<string>(0).ToString();
            }
            catch (Exception)
            {
                return "Error Adding";
            }
        }

        public string Put(Users users)
        {
            try
            {
                string query = @"update dbo.Users set FirstName = '" + users.FirstName + "' ,LastName = '" + users.LastName + "', EmpType ='" + users.EmpType + "' WHERE UserID=" + users.UserID + @"";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsedCarDashboard"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    da.SelectCommand = cmd;
                    da.Fill(table);
                }
                return "Added";
            }
            catch (Exception)
            {
                return "Failed";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"delete from dbo.Users WHERE UserID=" + id + @"";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsedCarDashboard"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    da.SelectCommand = cmd;
                    da.Fill(table);
                }
                return "Deleted";
            }
            catch (Exception)
            {

                return "Failed";
            }
        }

        [Route("api/users/login")]
        [HttpPost]
        public string Post(LoginUsers login)
        {
            try
            {
                string query = @"DECLARE	@responseMessage nvarchar(250) EXEC	dbo.VerifyLogin @pLoginName = N'" + login.LoginName + "', @pPassword = N'" + login.PasswordHash + "', @responseMessage = @responseMessage OUTPUT SELECT	@responseMessage as N'@responseMessage'  ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsedCarDashboard"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    da.SelectCommand = cmd;
                    da.Fill(table);
                }
                return table.Rows[0].Field<string>(0).ToString();
            }
            catch (Exception)
            {
                return "Error Adding";
            }
        }
    }
}
