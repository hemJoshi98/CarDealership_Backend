using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsedCarDashboard.Models
{
    public class Users
    {
        public int UserID  {get; set;}
        public string LoginName {get; set;}
        public string PasswordHash {get; set;}
        public string? FirstName {get; set;}
        public string? LastName {get; set;}
	    public string? EmpType {get; set;}
    }
}
