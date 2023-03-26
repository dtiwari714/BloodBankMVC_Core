using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;

namespace BloodBankProjectMVCCore.Models
{
    public class RecipientModel
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-4I63O79Q\SQL2022;Initial Catalog=BloodBankDb;Integrated Security=True;TrustServerCertificate=True;Encrypt=True;");

        [Key]
        public int RecipientID { get; set; }

        [Required(ErrorMessage = "Please enter the recipient's first name")]
        [StringLength(50, ErrorMessage = "The first name must be no more than 50 characters")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the recipient's last name")]
        [StringLength(50, ErrorMessage = "The last name must be no more than 50 characters")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Please enter the recipient's email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [StringLength(50, ErrorMessage = "The email address must be no more than 50 characters")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter the recipient's phone number")]
        [StringLength(20, ErrorMessage = "The phone number must be no more than 20 characters")]
        public string? Phone { get; set; }

        [ForeignKey("BloodType")]
        public string? BloodTypeID { get; set; }
        //public BloodTypeModel BloodType { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        //public UserModel User { get; set; }

        public List<RecipientModel> getData()
        {
            List<RecipientModel> lstEmp = new List<RecipientModel>();
            SqlDataAdapter apt = new SqlDataAdapter("SELECT d.RecipientID,d.FirstName,d.LastName,d.Email,d.Phone,u.Name,b.BloodGroup FROM [Recipient] d INNER JOIN [User] u ON d.UserId = u.UserId INNER JOIN [BloodType] b ON d.BloodTypeID = b.BloodTypeID ", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstEmp.Add(new RecipientModel
                {
                    RecipientID = Convert.ToInt32(dr["RecipientID"].ToString()),
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    Email = dr["Email"].ToString(),
                    Phone = dr["Phone"].ToString(),
                    UserId = dr["Name"].ToString(),
                    BloodTypeID = dr["BloodGroup"].ToString(),

                });
            }

            return lstEmp;
        }
        public bool insert(RecipientModel rec)
        {
            SqlCommand cmd = new SqlCommand("insert into Recipient(FirstName,LastName,Email,Phone,BloodTypeID,UserId) values(@fn,@ln,@em,@ph,@bt,@us)", con);
            

            cmd.Parameters.AddWithValue("@fn", rec.FirstName);
            cmd.Parameters.AddWithValue("@ln", rec.LastName);
            cmd.Parameters.AddWithValue("@em", rec.Email);
            cmd.Parameters.AddWithValue("@ph", rec.Phone);
            cmd.Parameters.AddWithValue("@bt", rec.BloodTypeID);
            cmd.Parameters.AddWithValue("@us", rec.UserId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        public RecipientModel getData(string Id)
        {
            RecipientModel NewRecipient = new RecipientModel();
            SqlCommand cmd = new SqlCommand("SELECT d.RecipientID,d.FirstName,d.LastName,d.Email,d.Phone,u.Name,b.BloodGroup FROM [Recipient] d INNER JOIN [User] u ON d.UserId = u.UserId INNER JOIN [BloodType] b ON d.BloodTypeID = b.BloodTypeID where RecipientID='" + Id + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    NewRecipient.RecipientID = Convert.ToInt32(dr["RecipientID"].ToString());
                    NewRecipient.FirstName = dr["FirstName"].ToString();
                    NewRecipient.LastName = dr["LastName"].ToString();
                    NewRecipient.Email = dr["Email"].ToString();
                    NewRecipient.Phone = dr["Phone"].ToString();
                    NewRecipient.BloodTypeID = dr["BloodGroup"].ToString();
                    NewRecipient.UserId = dr["Name"].ToString();
                }
            }
            con.Close();
            return NewRecipient;
        }
        public bool update(RecipientModel rec)
        {
            SqlCommand cmd = new SqlCommand("update Recipient set FirstName=@fn, LastName=@ln, Email=@em,Phone=@ph,BloodTypeID=@bt,UserId=@us where RecipientID = @id", con);
            cmd.Parameters.AddWithValue("@id", rec.RecipientID);
            cmd.Parameters.AddWithValue("@fn", rec.FirstName);
            cmd.Parameters.AddWithValue("@ln", rec.LastName);
            cmd.Parameters.AddWithValue("@em", rec.Email);
            cmd.Parameters.AddWithValue("@ph", rec.Phone);
            cmd.Parameters.AddWithValue("@bt", rec.BloodTypeID);
            cmd.Parameters.AddWithValue("@us", rec.UserId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        public bool delete(RecipientModel rec)
        {
            SqlCommand cmd = new SqlCommand("delete from Recipient where RecipientID = @id", con);
            cmd.Parameters.AddWithValue("@id", rec.RecipientID);
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
