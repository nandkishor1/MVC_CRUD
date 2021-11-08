using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;
using BL;
using System.Data;
using System.IO;

namespace MVC_CRUD.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            BO.Student objStudent = new BO.Student();
            DataTable dt = new DataTable();
            BL.Student objStudentBL = new BL.Student();

            #region GetState

            dt = objStudentBL.GetState();

            foreach (DataRow dr in dt.Rows)
            {
                objStudent.lstState.Add(new SelectListItem
                {
                    Text = Convert.ToString(dr["VC_StateName"]),
                    Value = Convert.ToString(dr["N_StateID"])
                });


            }


            #endregion


            #region GetDepartment

            BL.Department objDepartment = new BL.Department();

            objStudent.lstDepartment = objDepartment.GetDepartments();




            #endregion
            return View(objStudent);
        }
        [HttpPost]
        public string Index(BO.Student modelStudent)
        {
            if (ModelState.IsValid)
            {
                if (modelStudent.Image_File != null && modelStudent.Resume_File != null)
                {
                    try
                    {
                        string ImageName = Path.GetFileNameWithoutExtension(modelStudent.Image_File.FileName);
                        string ImageExt = Path.GetExtension(modelStudent.Image_File.FileName);
                        Guid objGuid = Guid.NewGuid();
                        ImageName = ImageName + "_" + objGuid.ToString().Trim('_') + ImageExt;
                        modelStudent.ProfilePicName = ImageName;
                        // string ServerPathImage = @"E:\My Projects\DotNet\ASP.NET\MVC\MVC_CRUD\MVC_CRUD\ProfilePics\";
                        string ServerPathImage = Server.MapPath("~//ProfilePics//");
                        modelStudent.ProfilePicPath = ServerPathImage;
                        string FileNameImage = modelStudent.Image_File.FileName;
                        modelStudent.Image_File.SaveAs(ServerPathImage + ImageName);


                        string ResumeName = Path.GetFileNameWithoutExtension(modelStudent.Resume_File.FileName);
                        string ResumeExt = Path.GetExtension(modelStudent.Resume_File.FileName);
                        Guid objGuid1 = Guid.NewGuid();
                        ResumeName = ResumeName + "_" + objGuid.ToString().Replace("_", "") + ResumeExt;
                        modelStudent.ResumeName = ResumeName;
                        // string ServerPathResume = @"E:\My Projects\DotNet\ASP.NET\MVC\MVC_CRUD\MVC_CRUD\StudentResume\";
                        string ServerPathResume = Server.MapPath("~//StudentResume//");

                        modelStudent.ResumePath = ServerPathResume;
                        string FileNameResume = modelStudent.Resume_File.FileName;
                        modelStudent.Resume_File.SaveAs(ServerPathResume + ResumeName);
                    }
                    catch (Exception ex)
                    {
                        string msg = ex.ToString();
                    }
                }






                //foreach (SelectListItem obj in modelStudent.Hoby)
                //          {
                //              if (obj.Selected)
                //              {
                //                  modelStudent.Hobbies = modelStudent.Hobbies + "," + obj.Text;
                //              //}
                //          }

                modelStudent.Hobbies = String.Join(",", modelStudent.Hoby.Where(x => x.Selected == true).Select(x => x.Text));

                //if (modelStudent.Hobbies == "")
                //{
                //    modelStudent.Hobbies = modelStudent.Hobbies.TrimStart(',');

                //}

                //if (modelStudent.Hobbies == ",")
                //{
                //    modelStudent.Hobbies = modelStudent.Hobbies.TrimStart(',');

                //}

                BL.Student obj1 = new BL.Student();
                obj1.InsertStudent(modelStudent);
            }
          

            //  return null;
            return "Welcome " + modelStudent.FName + " " + modelStudent.LName;
        }

        public ActionResult DisplayStudent()
        {

            BL.Student obj = new BL.Student();
            List<BO.Student> lstStudent = new List<BO.Student>();
            lstStudent = obj.GetStudents();
            return View(lstStudent);
        }

        public ActionResult Edit(string id)
        {
            BO.Student objStudent = new BO.Student();
            BL.Student obj = new BL.Student();
            objStudent = obj.GetStudent(Convert.ToInt32(id));
            DataTable dt = new DataTable();

            #region GetState

            dt = obj.GetState();

            foreach (DataRow dr in dt.Rows)
            {
                objStudent.lstState.Add(new SelectListItem
                {
                    Text = Convert.ToString(dr["VC_StateName"]),
                    Value = Convert.ToString(dr["N_StateID"])
                });


            }


            #endregion
            #region GetDepartment

            BL.Department objDepartment = new BL.Department();

            objStudent.lstDepartment = objDepartment.GetDepartments();

            foreach (var i in objStudent.Hoby)
            {
                if (objStudent.Hobbies.Contains(i.Text))
                {
                    i.Selected = true;
                }
            }


            #endregion
            
            return View(objStudent);
        }

        [HttpPost]
        public ActionResult Edit(BO.Student modelStudent,string id)
        {
            Guid objGuid = Guid.NewGuid();
            if (modelStudent.Image_File != null)
            {
                try
                {
                    string ImageName = Path.GetFileNameWithoutExtension(modelStudent.Image_File.FileName);
                    string ImageExt = Path.GetExtension(modelStudent.Image_File.FileName);
                    
                    ImageName = ImageName + "_" + objGuid.ToString().Trim('_') + ImageExt;
                    modelStudent.ProfilePicName = ImageName;
                    // string ServerPathImage = @"E:\My Projects\DotNet\ASP.NET\MVC\MVC_CRUD\MVC_CRUD\ProfilePics\";
                    string ServerPathImage = Server.MapPath("~//ProfilePics//");
                    modelStudent.ProfilePicPath = ServerPathImage;
                    string FileNameImage = modelStudent.Image_File.FileName;
                    modelStudent.Image_File.SaveAs(ServerPathImage + ImageName);

                }
                catch (Exception ex)
                {
                    string msg = ex.ToString();
                }

            }
            if (modelStudent.Resume_File != null)
            {
                try
                {
                    string ResumeName = Path.GetFileNameWithoutExtension(modelStudent.Resume_File.FileName);
                    string ResumeExt = Path.GetExtension(modelStudent.Resume_File.FileName);
                    Guid objGuid1 = Guid.NewGuid();
                    ResumeName = ResumeName + "_" + objGuid.ToString().Replace("_", "") + ResumeExt;
                    modelStudent.ResumeName = ResumeName;
                    // string ServerPathResume = @"E:\My Projects\DotNet\ASP.NET\MVC\MVC_CRUD\MVC_CRUD\StudentResume\";
                    string ServerPathResume = Server.MapPath("~//StudentResume//");

                    modelStudent.ResumePath = ServerPathResume;
                    string FileNameResume = modelStudent.Resume_File.FileName;
                    modelStudent.Resume_File.SaveAs(ServerPathResume + ResumeName);
                }
                catch(Exception ex)
                {
                    string msg = ex.ToString();
                }
            }

            modelStudent.Hobbies = String.Join(",", modelStudent.Hoby.Where(x => x.Selected == true).Select(x => x.Text));

            BL.Student obj = new BL.Student();
            obj.UpdateStudent(modelStudent,Convert.ToInt32(id));

            return RedirectToAction("DisplayStudent", "Home");
        }

        public ActionResult Delete(string id)
        {
            BL.Student obj = new BL.Student();
            obj.DeleteStudent(Convert.ToInt32(id));
            return RedirectToAction("DisplayStudent", "Home", null);
        }


        [HttpGet]
        public JsonResult GetCities(int StateID)
        {
            List<BO.City> lstCity = new List<BO.City>();
            BL.City objCity = new BL.City();
            lstCity = objCity.GetCities(StateID);

            return Json(lstCity, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}