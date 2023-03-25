using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;

namespace BloodBankProjectMVCCore.Models
{
    public class StaffModel
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DQ4VN0E;Initial Catalog=BloodBankDb;Integrated Security=True;TrustServerCertificate=True;Encrypt=True;");

        [Key]
        public int StaffID { get; set; }

        [Required(ErrorMessage = "Please enter the first name.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The first name must be between 2 and 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the last name.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The last name must be between 2 and 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter the email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(50, ErrorMessage = "The email address cannot exceed 50 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the phone number.")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Please enter a valid phone number in the format XXX-XXX-XXXX.")]
        public string Phone { get; set; }

        [ForeignKey("BloodBank")]
        public string? BloodBankID { get; set; }
        public BloodBankModel BloodBank { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public UserModel User { get; set; }

        public List<StaffModel> getData()
        {
            List<StaffModel> lstStaff = new List<StaffModel>();
            SqlDataAdapter apt = new SqlDataAdapter("SELECT d.StaffID,d.FirstName,d.LastName,d.Email,d.Phone,u.Name,b.BloodBankID FROM [Staff] d INNER JOIN [User] u ON d.UserId = u.UserId INNER JOIN [BloodBank] b ON d.BloodBankID = b.BloodBankID ", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstStaff.Add(new StaffModel
                {
                    StaffID = Convert.ToInt32(dr["StaffID"].ToString()),
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    Email = dr["Email"].ToString(),
                    Phone = dr["Phone"].ToString(),
                    UserId = dr["Name"].ToString(),
                    BloodBankID = dr["BloodBankID"].ToString(),

                });
            }

            return lstStaff;
        }
        public bool insert(StaffModel staff)
        {
            SqlCommand cmd = new SqlCommand("insert into Staff(FirstName,LastName,Email,Phone,BloodBankID,UserId) values(@fn,@ln,@em,@ph,@bt,@us)", con);
            cmd.Parameters.AddWithValue("@fn", staff.FirstName);
            cmd.Parameters.AddWithValue("@ln", staff.LastName);
            cmd.Parameters.AddWithValue("@em", staff.Email);
            cmd.Parameters.AddWithValue("@ph", staff.Phone);
            cmd.Parameters.AddWithValue("@bt", staff.BloodBankID);
            cmd.Parameters.AddWithValue("@us", staff.UserId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        public StaffModel getData(string Id)
        {
            StaffModel NewStaff = new StaffModel();
            SqlCommand cmd = new SqlCommand("SELECT d.StaffID,d.FirstName,d.LastName,d.Email,d.Phone,u.Name,b.BloodBankID FROM [Staff] d INNER JOIN [User] u ON d.UserId = u.UserId INNER JOIN [BloodBank] b ON d.BloodBankID = b.BloodBankID where StaffID='" + Id + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    NewStaff.StaffID = Convert.ToInt32(dr["StaffID"].ToString());
                    NewStaff.FirstName = dr["FirstName"].ToString();
                    NewStaff.LastName = dr["LastName"].ToString();
                    NewStaff.Email = dr["Email"].ToString();
                    NewStaff.Phone = dr["Phone"].ToString();
                    NewStaff.BloodBankID = dr["BloodBankID"].ToString();
                    NewStaff.UserId = dr["Name"].ToString();
                }
            }
            con.Close();
            return NewStaff;
        }
        public bool update(StaffModel NewStaff)
        {
            SqlCommand cmd = new SqlCommand("update Staff set FirstName=@fn, LastName=@ln, Email=@em,Phone=@ph,BloodBankID=@bt,UserId=@us where StaffID = @id", con);
            cmd.Parameters.AddWithValue("@id", NewStaff.StaffID);
            cmd.Parameters.AddWithValue("@fn", NewStaff.FirstName);
            cmd.Parameters.AddWithValue("@ln", NewStaff.LastName);
            cmd.Parameters.AddWithValue("@em", NewStaff.Email);
            cmd.Parameters.AddWithValue("@ph", NewStaff.Phone);
            cmd.Parameters.AddWithValue("@bt", NewStaff.BloodBankID);
            cmd.Parameters.AddWithValue("@us", NewStaff.UserId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        public bool delete(StaffModel Staff)
        {
            SqlCommand cmd = new SqlCommand("delete from Staff where StaffID = @id", con);
            cmd.Parameters.AddWithValue("@id", Staff.StaffID);
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
