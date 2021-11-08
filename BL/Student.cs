using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BO;
using System.Data;

namespace BL
{
    public class Student
    {
        public DataTable GetState()
        {
            DataTable dt = new DataTable();
            DAL.Student objStudent = new DAL.Student();
            dt= objStudent.GetState();

            return dt;
        }

        public void InsertStudent(BO.Student objStudent)
        {
            DAL.Student obj = new DAL.Student();
            obj.InsertStudent(objStudent);
        }

        public List<BO.Student> GetStudents()
        {
            DAL.Student obj = new DAL.Student();
            return obj.GetStudents();
        }

        public void DeleteStudent(int id)
        {
            DAL.Student obj = new DAL.Student();
            obj.DeleteStudent(id);

        }

        public BO.Student GetStudent(int id)
        {
            DAL.Student obj = new DAL.Student();
            BO.Student objStudent = new BO.Student();
            objStudent = obj.GetStudent(id);
            // return obj.GetStudent(id);
            return objStudent;
        }

        public void UpdateStudent(BO.Student updateModel,int id)
        {
            DAL.Student obj = new DAL.Student();
            obj.UpdateStudent(updateModel, id);
        }
    }
}
