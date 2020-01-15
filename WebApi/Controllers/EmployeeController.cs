using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class EmployeeController : ApiController
    {
        public List<Employee> Get()
        {
            using (EmployeeEntities DBContext = new EmployeeEntities())
            {
                return DBContext.Employees.ToList();
            }
        }

        public Employee Get(int id)
        {
            using (EmployeeEntities DBContext = new EmployeeEntities())
            {
                return DBContext.Employees.FirstOrDefault(e=>e.ID==id);
            }
        }


        public HttpResponseMessage Post(Employee employee)
        {
            using (EmployeeEntities DBContext = new EmployeeEntities())
            {
                DBContext.Employees.Add(employee);
                DBContext.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                message.Headers.Location = new Uri(Request.RequestUri + employee.ID.ToString());
                return message;
            }
        }
     
        [Route("api/Employee/getSalary")]
        [HttpGet]
        public IEnumerable<string> SalaryData()
        {
            using (EmployeeEntities DBContext = new EmployeeEntities())
            {
                IEnumerable<string> salaryList = DBContext.Employees.Select(e => e.Salary.ToString()).ToList();
                return salaryList;
            }

        }


    }
}
