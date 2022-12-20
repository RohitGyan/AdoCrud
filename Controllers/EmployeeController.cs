using CustomerDashBoardApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CustomerDashBoardApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        public CRUD db = new CRUD();
        public ActionResult Index()
        {
            List<Employee> employeeList = new List<Employee>();
            DataTable dtResult = db.GetAllEmployee();
            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                Employee employee = new Employee(); //model
                employee.student_id = Convert.ToInt32(dtResult.Rows[i]["Id"]);

                employee.student_name = dtResult.Rows[i]["FirstName"].ToString();
                employee.student_age = Convert.ToInt32(dtResult.Rows[i]["Age"]);
                employee.student_gender = dtResult.Rows[i]["Contact"].ToString();
               
                employeeList.Add(employee);
            }
            return View(employeeList);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {

            DataTable dt = db.GetEmployeeById(id);
            return View("Edit", dt);

            // //CRUD crud = new CRUD();
            // DataTable dt = db.GetEmployeeById(id);
            // return View("Edit", dt);



            // DataTable dtResult = db.GetEmployeeById(id);
            //// Employee employee = new Employee();
            // if (id == null)
            // {
            //     return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            // }
            // //Employee employee = db.GetEmployeeById(id);
            // if (dtResult == null)
            // {
            //     return HttpNotFound();
            //  }
           
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "students_id,students_name,students_age,students_gender")] Employee employee)
        {
     
            if (ModelState.IsValid)
            {
                employee.student_id = Convert.ToInt32(employee.student_id);

                

                employee.student_name = Convert.ToString(employee.student_name);
                employee.student_age = Convert.ToInt32(employee.student_age);
                employee.student_gender = Convert.ToString(employee.student_gender);
                int status = db.UpdateEmployee(employee.student_name, employee.student_age,employee.student_gender);



                return View(status);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DataTable dt = db.GetEmployeeById(id);
            Employee employee = new Employee();
            employee.student_id = Convert.ToInt32(dt.Rows[0]["student_id"]);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (employee.student_id == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Contact,Email")] Employee employee)
        {



            if (ModelState.IsValid)
            {
                employee.student_id = Convert.ToInt32(employee.student_id);



                employee.student_name = Convert.ToString(employee.student_name);
                employee.student_age = Convert.ToInt32(employee.student_age);
                employee.student_gender = Convert.ToString(employee.student_gender);
                int status = db.UpdateEmployee(employee.student_id, employee.student_name, employee.student_age, employee.student_gender);



                return View(employee);



            }
            return RedirectToAction("Index");



        }



        public ActionResult Delete(int student_id)
        {
            // CRUDModel model = new CRUDModel();
            db.Delete(student_id);
            return RedirectToAction("Index");
        }



        
    }
}

