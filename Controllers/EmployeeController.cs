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
                employee.student_id = Convert.ToInt32(dtResult.Rows[i]["student_id"]);
                employee.student_name = dtResult.Rows[i]["student_name"].ToString();
                employee.student_age = Convert.ToInt32(dtResult.Rows[i]["student_age"]);
                employee.student_gender = dtResult.Rows[i]["student_gender"].ToString();
                employeeList.Add(employee);
            }
            return View(employeeList);
        }


        // GET: Employee/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "student_name,student_age,student_gender")] Employee employee)
        {

            if (ModelState.IsValid)
            {
               // employee.student_id = Convert.ToInt32(employee.student_id);



                //employee.student_name = Convert.ToString(employee.student_name);
                //employee.student_age = Convert.ToInt32(employee.student_age);
               // employee.student_gender = Convert.ToString(employee.student_gender);
                int status = db.CreateEmployee(employee.student_name, employee.student_age, employee.student_gender);
                ViewBag.StatusMessage = "Employeee Created sucessfully";
            }
            return RedirectToAction("Index");
        }


        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {

            DataTable dt = db.GetEmployeeById(id);
            Employee employee = new Employee();
            employee.student_id = Convert.ToInt32(dt.Rows[0]["student_id"]);
            employee.student_name = Convert.ToString(dt.Rows[0]["student_name"]);
            employee.student_age = Convert.ToInt32(dt.Rows[0]["student_age"]);
            employee.student_gender = Convert.ToString(dt.Rows[0]["student_gender"]);
            // employee.Id = Convert.ToInt32(employee.Id);

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


       

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DataTable dt = db.GetEmployeeById(id);
            Employee employee = new Employee();
            employee.student_id = Convert.ToInt32(dt.Rows[0]["student_id"]);
            employee.student_name = Convert.ToString(dt.Rows[0]["student_name"]);
            employee.student_age = Convert.ToInt32(dt.Rows[0]["student_age"]);
            employee.student_gender = Convert.ToString(dt.Rows[0]["student_gender"]);

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
        public ActionResult Edit([Bind(Include = "student_name,student_age,student_gender")] Employee employee)
        {

            if (ModelState.IsValid)
            {
                //employee.student_id = Convert.ToInt32(employee.student_id);
                //employee.student_name = Convert.ToString(employee.student_name);
                //employee.student_age = Convert.ToInt32(employee.student_age);
                //employee.student_gender = Convert.ToString(employee.student_gender);
                int status = db.UpdateEmployee(employee.student_id,employee.student_name, employee.student_age, employee.student_gender);

                ViewBag.Status = "Updated Employee Details Sucessfully";
            }
            return RedirectToAction("Index");
        }



        public ActionResult Delete(int id)
        {
            //CRUDModel model = new CRUDModel();
            db.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int student_id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private class CRUDModel
        {
        }
    }
}

