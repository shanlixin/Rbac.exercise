using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rbac.Application;
using Rbac.Entity;
using System.Collections.Generic;

namespace Rbac.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public RoleController(IRoleService role)
        {
            Role = role;
        }

        public IRoleService Role { get; }

        [HttpGet]
        public List<Role> GetRoleAll()
        {
            return Role.GetAll();
        }

        [HttpPost]
        public bool AddRole(Role role)
        {
            return Role.Add(role);
        }
    }
}
