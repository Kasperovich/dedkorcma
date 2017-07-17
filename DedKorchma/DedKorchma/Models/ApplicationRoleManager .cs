using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DedKorchma.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace DedKorchma.Models
{
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(RoleStore<IdentityRole> store)
        : base(store)
        { }
        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options,
        IOwinContext context)
        {
            return new ApplicationRoleManager(new
            RoleStore<IdentityRole>(context.Get<ContextDb>()));
        }
    }
}