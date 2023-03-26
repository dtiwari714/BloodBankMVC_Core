using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace BloodBankProjectMVCCore.Models
{
    [Table("User")]
    public class UserModel
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-4I63O79Q\SQL2022;Initial Catalog=BloodBankDb;Integrated Security=True;TrustServerCertificate=True;Encrypt=True;");

        [Key]
        public string? UserId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(256)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [StringLength(50)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(256)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public List<UserModel> getData()
        {
            List<UserModel> lstbb = new List<UserModel>();
            SqlDataAdapter apt = new SqlDataAdapter("SELECT * from [User]", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstbb.Add(new UserModel
                {
                    UserId = dr["UserId"].ToString(),
                    Name = dr["Name"].ToString(),
                    PhoneNumber = dr["PhoneNumber"].ToString(),
                    Email = dr["Email"].ToString(),
                    Password = dr["Password"].ToString()

                });
            }

            return lstbb;
        }
        public bool insert(UserModel newUser)
        {
            SqlCommand cmd = new SqlCommand("insert into [User](UserId,Name,PhoneNumber,Email,Password) values(@id,@n,@pn,@em,@p)", con);
            cmd.Parameters.AddWithValue("@id", newUser.UserId);

            cmd.Parameters.AddWithValue("@n", newUser.Name);
            cmd.Parameters.AddWithValue("@pn", newUser.PhoneNumber);
            cmd.Parameters.AddWithValue("@em", newUser.Email);
            cmd.Parameters.AddWithValue("@p", newUser.Password);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        public UserModel getData(string Id)
        {
            UserModel newUser = new UserModel();
            SqlCommand cmd = new SqlCommand("select * from [User] where UserId = '" + Id + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    newUser.UserId = dr["UserId"].ToString();
                    newUser.Name = dr["Name"].ToString();
                    newUser.PhoneNumber = dr["PhoneNumber"].ToString();
                    newUser.Email = dr["Email"].ToString();
                    newUser.Password = dr["Password"].ToString();
                }
            }
            con.Close();
            return newUser;
        }
        public bool update(UserModel newUser)
        {
            SqlCommand cmd = new SqlCommand("update [User] set Name=@n, PhoneNumber=@ph, Email=@em,Password=@pa where UserId = @id", con);
            cmd.Parameters.AddWithValue("@id", newUser.UserId);
            cmd.Parameters.AddWithValue("@n", newUser.Name);
            cmd.Parameters.AddWithValue("@ph", newUser.PhoneNumber);
            cmd.Parameters.AddWithValue("@em", newUser.Email);
            cmd.Parameters.AddWithValue("@pa", newUser.Password);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        public bool delete(UserModel newUser)
        {
            SqlCommand cmd = new SqlCommand("delete from [User] where UserId = @id", con);
            cmd.Parameters.AddWithValue("@id", newUser.UserId);
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
