﻿﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using OnBoardManagement.Models;

namespace OnBoardManagmentSystem.Controllers
{
    public class ProjectController : Controller
    {
        private OnBoardDb db = new OnBoardDb();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Projects_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Project> projects = db.Projects;
            DataSourceResult result = projects.ToDataSourceResult(request, project => new {
                P_Id = project.P_Id,
                P_Name = project.P_Name,
                P_Technology = project.P_Technology,
                M_Id = project.M_Id
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Projects_Create([DataSourceRequest]DataSourceRequest request, Project project)
        {
            if (ModelState.IsValid)
            {
                var entity = new Project
                {
                    P_Name = project.P_Name,
                    P_Technology = project.P_Technology,
                    M_Id = project.M_Id
                };

                db.Projects.Add(entity);
                db.SaveChanges();
                project.P_Id = entity.P_Id;
            }

            return Json(new[] { project }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Projects_Update([DataSourceRequest]DataSourceRequest request, Project project)
        {
            if (ModelState.IsValid)
            {
                var entity = new Project
                {
                    P_Id = project.P_Id,
                    P_Name = project.P_Name,
                    P_Technology = project.P_Technology,
                    M_Id = project.M_Id
                };

                db.Projects.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { project }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Projects_Destroy([DataSourceRequest]DataSourceRequest request, Project project)
        {
            if (ModelState.IsValid)
            {
                var entity = new Project
                {
                    P_Id = project.P_Id,
                    P_Name = project.P_Name,
                    P_Technology = project.P_Technology,
                    M_Id = project.M_Id
                };

                db.Projects.Attach(entity);
                db.Projects.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { project }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
