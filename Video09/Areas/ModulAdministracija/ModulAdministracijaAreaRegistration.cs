﻿using System.Web.Mvc;

namespace MVC.Areas.ModulAdministracija
{
    public class ModulAdministracijaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ModulAdministracija";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ModulAdministracija_default",
                "ModulAdministracija/{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional }

            );
        }
    }
}