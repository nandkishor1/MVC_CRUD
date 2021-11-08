using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Student
    {
        string conStr = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public DataTable GetState()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(conStr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("prc_GetState", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    string str = ex.Message.ToString();
                }
            }
            return dt;

        }

        public void InsertStudent(BO.Student objStudent)
        {
            int i = 0;

            using(SqlConnection cn = new SqlConnection(conStr))
            {
                using(SqlCommand cmd = new SqlCommand("prc_InsertStudent", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DepartmentID ", SqlDbType.Int, 0).Value = objStudent.DepartmentID;
                    cmd.Parameters.Add("@FName", SqlDbType.VarChar, 500).Value = objStudent.FName;
                    cmd.Parameters.Add("@LName", SqlDbType.VarChar, 500).Value = objStudent.LName;
                    cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = objStudent.DOB;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 500).Value = objStudent.Email;
                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 500).Value = objStudent.Phone;
                    cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 10).Value = objStudent.Gender;
                    cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = objStudent.Address;
                    cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = objStudent.CityID;
                    cmd.Parameters.Add("@StateID", SqlDbType.Int).Value = objStudent.StateID;
                    cmd.Parameters.Add("@UniversityName", SqlDbType.VarChar, 500).Value = objStudent.UniversityName;
                    cmd.Parameters.Add("@Hobbies", SqlDbType.VarChar, 500).Value = objStudent.Hobbies;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 10).Value = "Nandkishor Yadav";
                    cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar, 10).Value = "";
                    cmd.Parameters.Add("@ProfilePicturePath", SqlDbType.VarChar).Value = objStudent.ProfilePicPath;
                    cmd.Parameters.Add("@ResumePath", SqlDbType.VarChar).Value = objStudent.ResumePath;
                    cmd.Parameters.Add("@ProfilePictureName", SqlDbType.VarChar, 500).Value = objStudent.ProfilePicName;
                    cmd.Parameters.Add("@ResumeName", SqlDbType.VarChar, 500).Value = objStudent.ResumeName;

                    try
                    {
                        cn.Open(); 
                       i= cmd.ExecuteNonQuery();
                        cn.Close();

                    }
                    catch(Exception ex)
                    {
                        string str = ex.Message;
                    }
                    finally
                    {
                        if (cn.State == ConnectionState.Open)
                            cn.Close();

                    }

                }
            }
        }


        public List<BO.Student> GetStudents()
        {
            List<BO.Student> lstStudent = new List<BO.Student>();

            using(SqlConnection scn  = new SqlConnection(conStr))
            {
                using(SqlCommand cmd = new SqlCommand("prc_GetStudentList", scn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        scn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                BO.Student objStudent = new BO.Student();
                                objStudent.StudentID =Convert.ToInt32(dr["N_StudentID"]);
                                objStudent.DepName = Convert.ToString(dr["VC_DepartmentName"]);
                                objStudent.FName = Convert.ToString(dr["VC_FName"]);
                                objStudent.LName = Convert.ToString(dr["VC_LName"]);
                                objStudent.DOB = Convert.ToDateTime(dr["DOB"]);
                                objStudent.Email = Convert.ToString(dr["VC_Email"]);
                                objStudent.Phone = Convert.ToString(dr["VC_Phone"]);
                                objStudent.Gender = Convert.ToString(dr["VC_Gender"]);
                                objStudent.Address = Convert.ToString(dr["VC_Address"]);
                                objStudent.CityName = Convert.ToString(dr["VC_CityName"]);
                                objStudent.StateName = Convert.ToString(dr["VC_StateName"]);
                                objStudent.UniversityName = Convert.ToString(dr["VC_UniversityName"]);
                                objStudent.Hobbies = Convert.ToString(dr["VC_Hobbies"]);
                                objStudent.ProfilePicName = Convert.ToString(dr["VC_ProfilePictureName"]);
                                objStudent.ResumeName = Convert.ToString(dr["VC_ResumeName"]);


                                lstStudent.Add(objStudent);


                            }
                        }

                        dr.Close();
                        scn.Close();
                    }
                    catch(Exception ex)
                    {
                        string msg = ex.ToString();
                    }
                    finally
                    {
                        if (scn.State == ConnectionState.Open)
                            scn.Close();
                    }
                }
            }
            return lstStudent;
        }

        public BO.Student GetStudent(int id)
        {
            BO.Student obj = new BO.Student();
            using(SqlConnection scn = new SqlConnection(conStr))
            {
                using(SqlCommand cmd = new SqlCommand("prc_GetStudent", scn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    try
                    {
                        scn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while(dr.Read()){

                                obj.UniversityName = Convert.ToString(dr["VC_UniversityName"]);
                                obj.DepartmentID = Convert.ToInt32(dr["N_DepartmentID_FK"]);
                                obj.FName = Convert.ToString(dr["VC_FName"]);
                                obj.LName = Convert.ToString(dr["VC_LName"]);
                                obj.Gender = Convert.ToString(dr["VC_Gender"]);
                                obj.DOB = Convert.ToDateTime(dr["DT_DOB"]);
                                obj.Email = Convert.ToString(dr["VC_Email"]);
                                obj.Phone = Convert.ToString(dr["VC_Phone"]);
                                obj.StateID = Convert.ToInt32(dr["N_StateID"]);
                                obj.CityID = Convert.ToInt32(dr["N_CityID"]);
                                obj.Address = Convert.ToString(dr["VC_Address"]);
                                obj.Hobbies = Convert.ToString(dr["VC_Hobbies"]);
                                obj.ProfilePicName = Convert.ToString(dr["VC_ProfilePictureName"]);
                                obj.ResumeName = Convert.ToString(dr["VC_ResumeName"]);
                                obj.ProfilePicPath = Convert.ToString(dr["VC_ProfilePictureName"]);
                                obj.ResumePath = Convert.ToString(dr["VC_ResumeName"]);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string msg = ex.ToString();
                    }
                    finally
                    {

                    }
                }
            }
            return obj;
        }

        public void DeleteStudent(int id)
        {
            using(SqlConnection scn  = new SqlConnection(conStr))
            {
                using(SqlCommand cmd = new SqlCommand("prc_DeleteStudent", scn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    try
                    {
                        scn.Open();
                        cmd.ExecuteNonQuery();
                        scn.Close();

                    }
                    catch (Exception ex)
                    {
                        string msg = ex.ToString();
                    }
                    finally
                    {
                        if (scn.State == ConnectionState.Open)
                            scn.Close();
                    }
                }
            }
        }

        public void UpdateStudent(BO.Student objStudent, int id)
        {
            int i = 0;
            using (SqlConnection cn = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("prc_UpdateStudent", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    cmd.Parameters.Add("@DepartmentID ", SqlDbType.Int, 0).Value = objStudent.DepartmentID;
                    cmd.Parameters.Add("@FName", SqlDbType.VarChar, 500).Value = objStudent.FName;
                    cmd.Parameters.Add("@LName", SqlDbType.VarChar, 500).Value = objStudent.LName;
                    cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = objStudent.DOB;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 500).Value = objStudent.Email;
                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 500).Value = objStudent.Phone;
                    cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 10).Value = objStudent.Gender;
                    cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = objStudent.Address;
                    cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = objStudent.CityID;
                    cmd.Parameters.Add("@StateID", SqlDbType.Int).Value = objStudent.StateID;
                    cmd.Parameters.Add("@UniversityName", SqlDbType.VarChar, 500).Value = objStudent.UniversityName;
                    cmd.Parameters.Add("@Hobbies", SqlDbType.VarChar, 500).Value = objStudent.Hobbies;
                    //cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 10).Value = "Nandkishor Yadav";
                    cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar, 10).Value = "";
                    cmd.Parameters.Add("@ProfilePicturePath", SqlDbType.VarChar).Value = objStudent.ProfilePicPath;
                    cmd.Parameters.Add("@ResumePath", SqlDbType.VarChar).Value = objStudent.ResumePath;
                    cmd.Parameters.Add("@ProfilePictureName", SqlDbType.VarChar, 500).Value = objStudent.ProfilePicName;
                    cmd.Parameters.Add("@ResumeName", SqlDbType.VarChar, 500).Value = objStudent.ResumeName;

                    try
                    {
                        cn.Open();
                        i = cmd.ExecuteNonQuery();
                        cn.Close();

                    }
                    catch (Exception ex)
                    {
                        string str = ex.Message;
                    }
                    finally
                    {
                        if (cn.State == ConnectionState.Open)
                            cn.Close();

                    }

                }
            }

        }
    }
}
