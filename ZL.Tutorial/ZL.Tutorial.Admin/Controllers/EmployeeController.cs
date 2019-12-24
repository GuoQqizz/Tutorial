using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZL.Tutorial.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        private static readonly string connStr = "server=.;database=tutorial;uid=sa;pwd=123456";
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "select *from Employee";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
            string json = JsonConvert.SerializeObject(dt);
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(json);
            return View();
        }
    }

    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Account { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public int Sex { get; set; }

        public string Email { get; set; }

        public int Status { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public int Editor { get; set; }
    }
}