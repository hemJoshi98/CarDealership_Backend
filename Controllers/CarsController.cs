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
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;

namespace UsedCarDashboard.Controllers
{
    public class CarsController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    SELECT CarID, Color,Make,Model,Year,Mileage,Price,PreviousOwners from dbo.Car ";
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

        public HttpResponseMessage Get(int id)
        {
            string query = @"
                    SELECT Color,Make,Model,Year,Mileage,Price,PreviousOwners from dbo.Car c INNER JOIN dbo.Preferences p on c.CarID = p.CarID WHERE p.BuyerID = " + id + @"";
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

        public string Post(Cars cars)
        {
            try
            {
                string query = @"insert into dbo.Car (Color, Make, Model, Year, Mileage, Price, PreviousOwners) values('" + cars.Color + "','" + cars.Make + "','" + cars.Model + "'," + cars.Year + "," + cars.Mileage + "," + cars.Price + "," + cars.PreviousOwners + ")";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsedCarDashboard"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    da.SelectCommand = cmd;
                    da.Fill(table);
                }
                return "Car was added successfully";
            }
            catch (Exception)
            {

                return "Failed to add new Car";
            }
        }

        public string Put(Cars cars)
        {
            try
            {
                string query = @"UPDATE dbo.Car SET Color = '" + cars.Color + "' ,Make = '" + cars.Make + "', Model ='" + cars.Model + "', Year =" + cars.Year + ", Mileage =" + cars.Mileage + ", Price =" + cars.Price + ", PreviousOwners =" + cars.PreviousOwners + " WHERE CarID=" + cars.CarID + @"";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsedCarDashboard"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    da.SelectCommand = cmd;
                    da.Fill(table);
                }
                return "Car detail was updated successfully";
            }
            catch (Exception)
            {

                return "Failed to update car detail.";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"delete from dbo.Car WHERE CarID=" + id + @"";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsedCarDashboard"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    da.SelectCommand = cmd;
                    da.Fill(table);
                }
                return "Car was deleted successfully";
            }
            catch (Exception)
            {

                return "Failed to delete car.";
            }
        }
    }
}
