using AppMarkom.Data.Services;
using AppMarkom.Web.Serialize;
using AppMarkom.Web.ViewModels.role;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMarkom.Web.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRole _role;

        public RoleController(IRole role)
        {
            _role = role;
        }
        public ActionResult Index()
        {
            return PartialView();
        }
        public ActionResult GetRoles()
        {
            var role = _role.GetRoles();
            var roleModel = role.Select(x => new roleViewModel{
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                IsDelete = x.IsDelete,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate
            }).ToList();
            var roles_Model = new roleIndex
            {
                roles = roleModel
            };
            return PartialView(roles_Model);
        }
        [HttpGet]
        public ActionResult GetRoleId(int id)
        {
            var role = _role.GetRoleById(id);
            var serializeRole = RoleMapper.SerializeRole(role);
            return PartialView(serializeRole);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create([FromForm] roleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var serializeRole = RoleMapper.SerializeRole(model);
            var newRole = _role.CreateRole(serializeRole);
            return Ok(newRole);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var role = _role.GetRoleById(id);
            var serializeRole = RoleMapper.SerializeRole(role);
            return PartialView(serializeRole);
        }
        [HttpPut]
        public ActionResult Update([FromForm] roleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var serializeRole = RoleMapper.SerializeRole(model);
            var newRole = _role.EditRole(serializeRole);
            return Ok(newRole);
        }
        public ActionResult Delete(int id)
        {
            var role = _role.GetRoleById(id);
            var serializeRole = RoleMapper.SerializeRole(role);
            return PartialView(serializeRole);
        }
        [HttpDelete]
        public ActionResult DeleteRole(int id)
        {
            var role = _role.DeleteRole(id);
            return Ok(role);
        }
        [HttpGet]
        public ActionResult Search(string code = "", string name = "", DateTime? createdDate = null, string created = "")
        {
            var role = _role.GetRoles(code, name, createdDate, created);
            var roleModel = role.Select(x => new roleViewModel
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                IsDelete = x.IsDelete,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate
            }).ToList();
            var roles_Model = new roleIndex
            {
                roles = roleModel
            };
            return PartialView(roles_Model);
        }
    }
}
