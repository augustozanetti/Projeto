﻿using AZ.Projeto.Infra.CrossCutting.MvcFilters;
using System.Web;
using System.Web.Mvc;

namespace AZ.Projeto.Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalActionLogger());
        }
    }
}
