using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Xml.Linq;

namespace WebGentalPracticeInMVC5.Models
{
    public class StudentServices
    {
        private static SqlConnection _SqlConnection;
        private static SqlCommand _cmd;
        private SqlDataAdapter sda;
        private DataTable dt = new DataTable();

        public StudentServices()
        {
            string cons = "Data Source=DESKTOP-UL2SOTR;Initial Catalog=Class Work;Integrated Security=True";//"User ID=sa;Password=Alaska@123;";

            _SqlConnection = new SqlConnection(cons);
            _SqlConnection.Open();
        }

        public List<StudentModel> GetDataFromDB()
        {
            //List<StudentModel> list = new List<StudentModel>();
            var list = new List<StudentModel>();            
            _cmd = new SqlCommand("select * from StudentInfo", _SqlConnection);
            sda = new SqlDataAdapter(_cmd);
            sda.Fill(dt);
            _cmd.Dispose();

            _SqlConnection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new StudentModel
                {
                    Sid = Convert.ToInt32(dr["Sid"]),
                    Sname = Convert.ToString(dr["Sname"]),
                    Sage = Convert.ToInt32(dr["Sage"])
                });
            };
            return list;
        }
        public StudentModel GetStudentByID(int id)
        {
            StudentModel student = new StudentModel();
            
            _cmd = new SqlCommand("select * from StudentInfo where Sid ="+id, _SqlConnection);
            sda = new SqlDataAdapter(_cmd);

            sda.Fill(dt);
            _cmd.Dispose();

            _SqlConnection.Close();

            var DtRow = dt.Rows[0];
            student.Sid = Convert.ToInt32(DtRow[0]);
            student.Sname = Convert.ToString(DtRow[1]);
            student.Sage = Convert.ToInt32(DtRow[2]);
            
  
            return (student);

        }
        public void SetDataInDB(StudentModel obj)
        {
            
            obj.Sname = Convert.ToString(obj.Sname);
            obj.Sage = Convert.ToInt32(obj.Sage);
            _cmd = new SqlCommand("insert into StudentInfo (Sname,Sage) values ('" + obj.Sname + "','" + obj.Sage + "')", _SqlConnection);
            _cmd.ExecuteNonQuery();
            _cmd.Dispose();
            _SqlConnection.Close();
        }
        public void DeletDataFromDb(int id)
        {
           

            //id = Convert.ToInt32(id);
            _cmd = new SqlCommand("Delete  from StudentInfo where Sid= "+id, _SqlConnection);
            //_cmd.Parameters.AddWithValue("@Sid", id);
            
            _cmd.ExecuteNonQuery();
            _cmd.Dispose();

            _SqlConnection.Close();
        }
        public void EditDataInDB(int id,StudentModel obj)
        {
            obj.Sname = Convert.ToString(obj.Sname);
            obj.Sage = Convert.ToInt32(obj.Sage);

            _cmd = new SqlCommand("update StudentInfo Set Sname='"+obj.Sname +"', Sage= '"+obj.Sage+"' where Sid="+id, _SqlConnection);

            _cmd.ExecuteNonQuery();


            _cmd.Dispose();

            _SqlConnection.Close();
        }
    }
}