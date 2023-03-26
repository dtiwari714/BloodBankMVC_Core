using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankProjectMVCCore.Models
{
    
    public class DonorModel
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-4I63O79Q\SQL2022;Initial Catalog=BloodBankDb;Integrated Security=True;TrustServerCertificate=True;Encrypt=True;");

        [Key]
        public int DonorID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50)]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(20)]
        public string? Phone { get; set; }

        [ForeignKey("BloodType")]
        public string? BloodTypeID { get; set; }
        //public BloodTypeModel BloodType { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        ///public UserModel User { get; set; }

        public List<DonorModel> getData()
        {
            List<DonorModel> lstEmp = new List<DonorModel>();
            SqlDataAdapter apt = new SqlDataAdapter("SELECT d.DonorID,d.FirstName,d.LastName,d.Email,d.Phone,u.Name,b.BloodGroup FROM [Donor] d INNER JOIN [User] u ON d.UserId = u.UserId INNER JOIN [BloodType] b ON d.BloodTypeID = b.BloodTypeID ", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstEmp.Add(new DonorModel
                {
                    DonorID = Convert.ToInt32(dr["DonorID"].ToString()),
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    Email = dr["Email"].ToString(),
                    Phone = dr["Phone"].ToString(),
                    UserId = dr["Name"].ToString(),
                    BloodTypeID = dr["BloodGroup"].ToString(),

                }) ;
            }
            
            return lstEmp;
        }
        public bool insert(DonorModel Emp)
        {
            SqlCommand cmd = new SqlCommand("insert into Donor(FirstName,LastName,Email,Phone,BloodTypeID,UserId) values(@fn,@ln,@em,@ph,@bt,@us)", con);
            cmd.Parameters.AddWithValue("@fn", Emp.FirstName);
            cmd.Parameters.AddWithValue("@ln", Emp.LastName);
            cmd.Parameters.AddWithValue("@em", Emp.Email);
            cmd.Parameters.AddWithValue("@ph", Emp.Phone);
            cmd.Parameters.AddWithValue("@bt", Emp.BloodTypeID);
            cmd.Parameters.AddWithValue("@us", Emp.UserId); 
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        public DonorModel getData(string Id)
        {
            DonorModel NewDonor = new DonorModel();
            SqlCommand cmd = new SqlCommand("SELECT d.DonorID,d.FirstName,d.LastName,d.Email,d.Phone,u.Name,b.BloodGroup FROM [Donor] d INNER JOIN [User] u ON d.UserId = u.UserId INNER JOIN [BloodType] b ON d.BloodTypeID = b.BloodTypeID where DonorID='" + Id +"'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    NewDonor.DonorID = Convert.ToInt32(dr["DonorID"].ToString());
                    NewDonor.FirstName = dr["FirstName"].ToString();
                    NewDonor.LastName = dr["LastName"].ToString();
                    NewDonor.Email = dr["Email"].ToString();
                    NewDonor.Phone = dr["Phone"].ToString();
                    NewDonor.BloodTypeID = dr["BloodGroup"].ToString();
                    NewDonor.UserId = dr["Name"].ToString();
                }
            }
            con.Close();
            return NewDonor;
        }
        public bool update(DonorModel Emp)
        {
            SqlCommand cmd = new SqlCommand("update Donor set FirstName=@fn, LastName=@ln, Email=@em,Phone=@ph,BloodTypeID=@bt,UserId=@us where DonorId = @id", con);
            cmd.Parameters.AddWithValue("@id", Emp.DonorID);
            cmd.Parameters.AddWithValue("@fn", Emp.FirstName);
            cmd.Parameters.AddWithValue("@ln", Emp.LastName);
            cmd.Parameters.AddWithValue("@em", Emp.Email);
            cmd.Parameters.AddWithValue("@ph", Emp.Phone);
            cmd.Parameters.AddWithValue("@bt", Emp.BloodTypeID);
            cmd.Parameters.AddWithValue("@us", Emp.UserId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        public bool delete(DonorModel Emp)
        {
            SqlCommand cmd = new SqlCommand("delete from Donor where DonorID = @id", con);
            cmd.Parameters.AddWithValue("@id", Emp.DonorID);
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
