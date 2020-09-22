using AppMarkom.Data.Services;
using AppMarkom.Web.Serialize;
using AppMarkom.Web.ViewModels;
using AppMarkom.Web.ViewModels.company;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMarkom.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompany _company;
        public CompanyController(ICompany company)
        {
            _company = company;
        }
        [HttpGet]
        public ActionResult GetCompanyId(int id)
        {
            var company = _company.GetCompanyById(id);
            var serializeCompany = CompanyMapper.SerializeCompany(company);
            return PartialView(serializeCompany);
        }
        [HttpGet]
        public ActionResult GetCompanies()
        {
            var company = _company.GetCompanies();
            var companyModel = company.Select(x => new companyViewModel
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Address = x.Address,
                Phone = x.Phone,
                Email = x.Email,
                IsDelete = x.IsDelete,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate
            }).ToList();
            var companies = new companyIndex
            {
                CompanyModel = companyModel
            };
            return View(companies);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create([FromBody] companyViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var serializeCompany = CompanyMapper.SerializeCompany(model);
            var newCompany = _company.CreateCompany(serializeCompany);
            return Ok(newCompany);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var company = _company.GetCompanyById(id);
            var serializeCompany = CompanyMapper.SerializeCompany(company);
            return PartialView(serializeCompany);
        }
        [HttpPut]
        public ActionResult Update([FromBody] companyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var serializeCompany = CompanyMapper.SerializeCompany(model);
            var newCompany = _company.EditCompany(serializeCompany);
            return Ok(newCompany);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var company = _company.GetCompanyById(id);
            var serializeCompany = CompanyMapper.SerializeCompany(company);
            return PartialView(serializeCompany);
        }
        [HttpDelete]
        public ActionResult DeleteCompany(int id)
        {
            var deleteCompany = _company.DeleteCompany(id);
            return Ok(deleteCompany);
        }
        [HttpGet]
        public ActionResult Search(string code="", string name="", DateTime? createdDate = null, string created = "")
        {
            var company = _company.GetCompanies(code, name, createdDate, created);
            var companyModel = company.Select(x => new companyViewModel
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Address = x.Address,
                Phone = x.Phone,
                Email = x.Email,
                IsDelete = x.IsDelete,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate
            }).ToList();
            var companies = new companyIndex
            {
                CompanyModel = companyModel
            };
            return PartialView(companies);
        }
    }
}
