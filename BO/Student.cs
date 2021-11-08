using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BO
{
   public class Student
    {
        public Student()
        {
            //lststate = new list<selectlistitem>();
            //lstdepartment = new list<selectlistitem>();

            Hoby.Add(new SelectListItem { Text = "Swiming", Value = "Swiming" });
            Hoby.Add(new SelectListItem { Text = "Coding", Value = "Coding" });
            Hoby.Add(new SelectListItem { Text = "Sleeping", Value = "Sleeping" });
            Hoby.Add(new SelectListItem { Text = "Playing", Value = "Playing" });

        }
        public int StudentID { get; set; }
        [Required(ErrorMessage = "Department  is required")]
        [DisplayName("Department")]
        public int DepartmentID { get; set; }
        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name  is required")]
        [RegularExpression(pattern: @"^[a-zA-Z ]*$", ErrorMessage = "only Alphabets Allowed")]
        public string FName { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name  is required")]
        [RegularExpression(pattern: @"^[a-zA-Z ]*$", ErrorMessage = "only Alphabets Allowed")]
        public string LName { get; set; }
        [Required(ErrorMessage = "DOB  is required")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Email  is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number  is required")]
        [RegularExpression("[1-9]{1}[0-9]{9}", ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Gender  is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Address  is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City name  is required")]
        public int CityID { get; set; }
        [Required(ErrorMessage = "State name  is required")]
        public int StateID { get; set; }
        [DisplayName("City")]
        
        public string CityName { get; set; }
        [DisplayName("State")]
        
        public string StateName { get; set; }
        [DisplayName("Dep.")]
        public string DepName { get; set; }
        [DisplayName("University")]
        [Required(ErrorMessage = "University  name  is required")]
        [RegularExpression(pattern:@"^[a-zA-Z ]*$", ErrorMessage = "only Alphabets Allowed")]
        public string UniversityName { get; set; }
        public string Hobbies { get; set; }
        public string ProfilePicPath { get; set; }
        public string ResumePath { get; set; }
        [DisplayName("Profile Picture")]
        public string ProfilePicName { get; set; }
        [DisplayName("Resume")]
        public string ResumeName { get; set; }
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.jpeg)$", ErrorMessage ="Only Image files allowed.")]
        public HttpPostedFileBase Image_File { get; set; }
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.pdf|.docx|.doc)$", ErrorMessage = "Only document files allowed.")]
        public HttpPostedFileBase Resume_File { get; set; }

        public List<SelectListItem> lstState { get; set; } = new List<SelectListItem>();

       
        public List<SelectListItem> lstDepartment { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> Hoby { get; set; } = new List<SelectListItem>();

    }
}
