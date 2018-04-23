using System;
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
using OnBoardManagmentSystem.Models;

namespace OnBoardManagmentSystem.Controllers
{

    public class MentorController : Controller
    {
        private OnBoardDb db = new OnBoardDb();
        OnBoardDb ctx = new OnBoardDb();
        public ActionResult Index(int id)
        {
            return View();
        }

        public ActionResult View(int id)
        {
            Mentor mentor = ctx.Mentors.FirstOrDefault(m => m.M_Id == id);
           Project project= ctx.Projects.FirstOrDefault(m => m.M_Id == mentor.M_Id);
            
            ViewBag.mentor = mentor;
            ViewBag.project = project;
            List<OnBoarder> OnBoarders = ctx.OnBoarders.Where(m => m.M_Id == id).ToList();
            List<Models.OnBoarderDetailModel> details = new List<OnBoarderDetailModel>();
            foreach (OnBoarder ob in OnBoarders)
            {
                OnBoarderDetailModel obm = new OnBoarderDetailModel();
                obm.Name = ob.O_Name;
                obm.OnboarderId = ob.O_Id;
                List<ProjectAssignment> rotations = ctx.ProjectAssignments.Where(m => m.O_Id == ob.O_Id).ToList();

                foreach (ProjectAssignment r in rotations)
                {
                    if (obm.Rotation1.Equals("---"))
                    {
                        obm.Rotation1 = GetProject(r.P_Id);
                    }
                    else if (obm.Rotation2.Equals("---"))
                    {
                        obm.Rotation2 = GetProject(r.P_Id);
                    }
                    else if (obm.Rotation3.Equals("---"))
                    {
                        obm.Rotation3 = GetProject(r.P_Id);
                    }
                    else if (obm.Rotation4.Equals("---"))
                    {
                        obm.Rotation4 = GetProject(r.P_Id);
                    }

                }
                details.Add(obm);

            }


            return View(details);

        }
        public String GetProject(int ProjectId)
        {
            Project project = ctx.Projects.FirstOrDefault(m => m.P_Id == ProjectId);
            return project.P_Name;
        }
        public JsonResult RemoteDataSource_GetProducts(string text)
        {

            var products = db.Mentors.Select(product => new Mentor
            {
                M_Id=product.M_Id,
                M_Name=product.M_Name
               
            });



            if (!string.IsNullOrEmpty(text))
            {
                products = products.Where(p => p.M_Name.Contains(text));
            }

            return Json(db.Mentors.ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Mentors_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Mentor> mentors = db.Mentors;
            DataSourceResult result = mentors.ToDataSourceResult(request, mentor => new {
                M_Id = mentor.M_Id,
                M_Name = mentor.M_Name
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Mentors_Create([DataSourceRequest]DataSourceRequest request, Mentor mentor)
        {
            if (ModelState.IsValid)
            {
                var entity = new Mentor
                {
                    M_Name = mentor.M_Name
                };

                db.Mentors.Add(entity);
                db.SaveChanges();
                mentor.M_Id = entity.M_Id;
            }

            return Json(new[] { mentor }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Mentors_Update([DataSourceRequest]DataSourceRequest request, Mentor mentor)
        {
            if (ModelState.IsValid)
            {
                var entity = new Mentor
                {
                    M_Id = mentor.M_Id,
                    M_Name = mentor.M_Name
                };

                db.Mentors.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { mentor }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Mentors_Destroy([DataSourceRequest]DataSourceRequest request, Mentor mentor)
        {
            if (ModelState.IsValid)
            {
                var entity = new Mentor
                {
                    M_Id = mentor.M_Id,
                    M_Name = mentor.M_Name
                };

                db.Mentors.Attach(entity);
                db.Mentors.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { mentor }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
