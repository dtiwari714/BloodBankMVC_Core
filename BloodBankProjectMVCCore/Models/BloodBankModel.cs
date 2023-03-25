using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BloodBankProjectMVCCore.Models
{
    public class BloodBankModel
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-4I63O79Q\SQL2022;Initial Catalog=BloodBankDb;Integrated Security=True;TrustServerCertificate=True;Encrypt=True;");

        [Key]
        public int BloodBankID { get; set; }

        [Required(ErrorMessage = "Please enter the blood bank name")]
        [StringLength(50, ErrorMessage = "The name must be no more than 50 characters")]
        public string? BloodBankName { get; set; }

        [Required(ErrorMessage = "Please enter the blood bank address")]
        [StringLength(100, ErrorMessage = "The address must be no more than 100 characters")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Please enter the blood bank phone number")]
        [StringLength(20, ErrorMessage = "The phone number must be no more than 20 characters")]
        public string? Phone { get; set; }

        public List<BloodBankModel> getData()
        {
            List<BloodBankModel> lstEmp = new List<BloodBankModel>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from BloodBank", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstEmp.Add(new BloodBankModel
                {
                    BloodBankID = Convert.ToInt32(dr["BloodBankID"].ToString()),
                    BloodBankName = dr["BloodBankName"].ToString(),
                    Address = dr["Address"].ToString(),
                    Phone = dr["Phone"].ToString()
                });
            }
            return lstEmp;
        }
        public BloodBankModel getData(string BloodBankID)
        {
            BloodBankModel emp = new BloodBankModel();
            SqlCommand cmd = new SqlCommand("select * from BloodBank where BloodBankID='" + BloodBankID + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    emp.BloodBankID = Convert.ToInt32(dr["BloodBankID"].ToString());
                    emp.BloodBankName = dr["BloodBankName"].ToString();
                    emp.Address = dr["Address"].ToString();
                    emp.Phone = dr["Phone"].ToString();
                }
            }
            con.Close();
            return emp;
        }
        //Insert a record into a database table
        public bool insert(BloodBankModel Emp)
        {
            SqlCommand cmd = new SqlCommand("insert into BloodBank (BloodBankName, Address, Phone) values(@BloodBankName, @Address, @Phone)", con);
            cmd.Parameters.AddWithValue("@BloodBankName", Emp.BloodBankName);
            cmd.Parameters.AddWithValue("@Address", Emp.Address);
            cmd.Parameters.AddWithValue("@Phone", Emp.Phone);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
                //return true;
            }
            return false;
        }
        //Update a record into a database table
        public bool update(BloodBankModel Emp)
        {
            SqlCommand cmd = new SqlCommand("update BloodBank set BloodBankName=@BloodBankName, Address=@Address, Phone=@Phone where BloodBankID = @BloodBankID", con);
            cmd.Parameters.AddWithValue("@BloodBankID", Emp.BloodBankID);
            cmd.Parameters.AddWithValue("@BloodBankName", Emp.BloodBankName);
            cmd.Parameters.AddWithValue("@Address", Emp.Address);
            cmd.Parameters.AddWithValue("@Phone", Emp.Phone);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        //delete a record from a database table
        public bool delete(BloodBankModel Emp)
        {
            SqlCommand cmd = new SqlCommand("Delete BloodBank where BloodBankID = @BloodBankID", con);
            cmd.Parameters.AddWithValue("@BloodBankID", BloodBankID);
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
    

