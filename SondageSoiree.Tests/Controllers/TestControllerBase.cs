using Microsoft.AspNet.Identity;
using SondageSoiree.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SondageSoiree.Tests.Controllers
{
    public class TestControllerBase
    {
        public class TestableControllerContext : ControllerContext
        {
            public TestableHttpContext TestableHttpContext { get; set; }
        }
        public class TestableHttpContext : HttpContextBase
        {
            public override IPrincipal User { get; set; }
        }

        protected void FillControllerContext(Controller ctrl, Eleve eleve)
        {
            var claims = new List<Claim>();

            // create required claims
            claims.Add(new Claim(ClaimTypes.NameIdentifier, eleve.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, eleve.Nom));
            claims.Add(new Claim(ClaimTypes.Role, eleve.Role ?? ""));

            var controllerContext = new TestableControllerContext();
            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            var principal = new GenericPrincipal(identity, null);
            var testableHttpContext = new TestableHttpContext
            {
                User = principal
            };
            controllerContext.HttpContext = testableHttpContext;
            ctrl.ControllerContext = controllerContext;

        }
    }
}
