using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BloodBankProjectMVCCore.Models
{
    public class BloodTypeModel
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-4I63O79Q\SQL2022;Initial Catalog=BloodBankDb;Integrated Security=True;TrustServerCertificate=True;Encrypt=True;");
        [Key]
        public string? BloodTypeID { get; set; }

        [Required(ErrorMessage = "Blood Group is required")]
        [StringLength(10)]
        public string? BloodGroup { get; set; }

        [Required(ErrorMessage = "Rh Factor is required")]
        [StringLength(10)]
        public string? RhFactor { get; set; }
        public List<BloodTypeModel> getData()
        {
            List<BloodTypeModel> lstEmp = new List<BloodTypeModel>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from BloodType", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstEmp.Add(new BloodTypeModel {
                    BloodTypeID = dr["BloodTypeID"].ToString(),
                    BloodGroup = dr["BloodGroup"].ToString(),
                    RhFactor = dr["RhFactor"].ToString() });
            }
            return lstEmp;
        }
        public BloodTypeModel getData(string Id)
        {
            BloodTypeModel emp = new BloodTypeModel();
            SqlCommand cmd = new SqlCommand("select * from BloodType where id='" + BloodTypeID + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    emp.BloodTypeID = dr["BloodTypeID"].ToString();
                    emp.BloodGroup = dr["BloodGroup"].ToString();
                    emp.RhFactor = dr["RhFactor"].ToString();
                }
            }
            con.Close();
            return emp;
        }
        //Insert a record into a database table
        public bool insert(BloodTypeModel Emp)
        {
            SqlCommand cmd = new SqlCommand("insert into BloodType values(@BloodTypeID,@BloodGroup,@RhFactor)", con);
            cmd.Parameters.AddWithValue("@BloodTypeID", Emp.BloodTypeID);
            cmd.Parameters.AddWithValue("@BloodGroup", Emp.BloodGroup);
            cmd.Parameters.AddWithValue("@RhFactor", Emp.RhFactor);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
    }
}
