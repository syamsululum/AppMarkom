using AppMarkom.Data.Services;
using AppMarkom.Web.Serialize;
using AppMarkom.Web.ViewModels.company;
using AppMarkom.Web.ViewModels.employee;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMarkom.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;
        private readonly ICompany _company;

        public EmployeeController(IEmployee employee, ICompany company)
        {
            _employee = employee;
            _company = company;
        }
        public ActionResult GetEmployees()
        {
            var employee = _employee.GetEmployees();
            var employeeModel = employee.Select(x => new employeeViewModel
            {
                Id = x.Id,
                Code = x.Code,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MCompany = CompanyMapper.SerializeCompany(_company.GetCompanyById(x.MCompany.Id)),
                Email = x.Email,
                IsDelete = x.IsDelete,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate
            }).ToList();
            var employes = new employeeIndex
            {
                employees = employeeModel
            };
            return PartialView(employes);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create([FromBody] employeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var serializeEmployee = EmployeeMapper.SerializeEmployee(model);
            var newEmployee = _employee.CreateEmployee(serializeEmployee);
            return Ok(newEmployee);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var employee = _employee.GetEmployeeById(id);
            var serializeEmployee = EmployeeMapper.SerializeEmployee(employee);
            return PartialView(serializeEmployee);
        }
        [HttpPut]
        public ActionResult Update(employeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var serializeEmployee = EmployeeMapper.SerializeEmployee(model);
            var newEmployee = _employee.EditEmployee(serializeEmployee);
            return Ok(newEmployee);
        }
        [HttpPatch]
        public ActionResult Delete(int id)
        {
            var deleteEmpoyee = _employee.DeleteEmployee(id);
            return Ok(deleteEmpoyee);
        }
        [HttpGet]
        public ActionResult Show(int id)
        {
            var employee = _employee.GetEmployeeById(id);
            var serializeEmployee = EmployeeMapper.SerializeEmployee(employee);
            return PartialView(serializeEmployee);
        }
    }
}
