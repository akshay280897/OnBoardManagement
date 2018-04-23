﻿using System;
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
    public class OnboarderController : Controller
    {
        private OnBoardDb db = new OnBoardDb();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OnBoarders_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<OnBoarder> onboarders = db.OnBoarders;
            DataSourceResult result = onboarders.ToDataSourceResult(request, onBoarder => new {
                O_Id = onBoarder.O_Id,
                O_Name = onBoarder.O_Name,
                O_RotationNo = onBoarder.O_RotationNo,
                ReportingManager = onBoarder.ReportingManager,
                M_Id = onBoarder.M_Id
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OnBoarders_Create([DataSourceRequest]DataSourceRequest request, OnBoarder onBoarder)
        {
            if (ModelState.IsValid)
            {
                var entity = new OnBoarder
                {
                    O_Name = onBoarder.O_Name,
                    O_RotationNo = onBoarder.O_RotationNo,
                    ReportingManager = onBoarder.ReportingManager,
                    M_Id = onBoarder.M_Id
                };

                db.OnBoarders.Add(entity);
                db.SaveChanges();
                onBoarder.O_Id = entity.O_Id;
            }

            return Json(new[] { onBoarder }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OnBoarders_Update([DataSourceRequest]DataSourceRequest request, OnBoarder onBoarder)
        {
            if (ModelState.IsValid)
            {
                var entity = new OnBoarder
                {
                    O_Id = onBoarder.O_Id,
                    O_Name = onBoarder.O_Name,
                    O_RotationNo = onBoarder.O_RotationNo,
                    ReportingManager = onBoarder.ReportingManager,
                    M_Id = onBoarder.M_Id
                };

                db.OnBoarders.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { onBoarder }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OnBoarders_Destroy([DataSourceRequest]DataSourceRequest request, OnBoarder onBoarder)
        {
            if (ModelState.IsValid)
            {
                var entity = new OnBoarder
                {
                    O_Id = onBoarder.O_Id,
                    O_Name = onBoarder.O_Name,
                    O_RotationNo = onBoarder.O_RotationNo,
                    ReportingManager = onBoarder.ReportingManager,
                    M_Id = onBoarder.M_Id
                };

                db.OnBoarders.Attach(entity);
                db.OnBoarders.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { onBoarder }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
