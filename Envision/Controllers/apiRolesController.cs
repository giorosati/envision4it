using Envision.Adapters.Adapters;
using Envision.Adapters.Interfaces;
using Envision.Data.Model;
using Envision.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Envision.Controllers
{
    //[Authorize]
    public class apiRolesController : ApiController
    {
        private IAdminAdapter _adapter;

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public apiRolesController()
        {
            _adapter = new AdminAdapter();
        }

        public apiRolesController(IAdminAdapter a)
        {
            _adapter = a;
        }

        public IHttpActionResult Get()
        {
            string userId = User.Identity.GetUserId();
            var roles = UserManager.GetRoles(userId);
            return Ok(roles);
        }
    }
}