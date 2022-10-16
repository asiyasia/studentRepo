using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentProject.Models
{
    public class StudentModelManager
    {
        public List<StudentModel> GetstudentInfo()
        {
          string scn=  ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            List<StudentModel> OstudentModels = new List<StudentModel>();
            using(SqlConnection cn = new SqlConnection(scn) )
            {
                using (SqlCommand cmd = new SqlCommand("sp_getstudentinfo", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while(dr.Read())
                        {
                            StudentModel studentModel = new StudentModel();

                            studentModel.StudentId = Convert.ToInt32(dr["StudentId"]);
                            studentModel.StudentName = Convert.ToString(dr["StudentName"]);
                            studentModel.StudentEmail = Convert.ToString(dr["StudentEmail"]);
                            studentModel.StudentMobile = Convert.ToString(dr["StudentMobile"]);
                            studentModel.StudentAge = Convert.ToInt32(dr["StudentAge"]);

                            OstudentModels.Add(studentModel);




                        }
                        dr.Close();
                    }
                    catch(Exception ex)
                    {
                        var exception = ex;
                    }
                    finally
                    {
                        if(cn.State==System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                    return OstudentModels;


                }
            }
          

        }
    }
}