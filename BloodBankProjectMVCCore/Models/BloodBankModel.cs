
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;


namespace BloodBankProjectMVCCore.Models
{
    public class BloodBankModel
    {

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-4I63O79Q\SQL2022;Initial Catalog=BloodBankDb;Integrated Security=True;TrustServerCertificate=True;Encrypt=True;");


        [Key]
        public string BloodBankID { get; set; }

        [Required(ErrorMessage = "Please enter the blood bank name")]
        [StringLength(50, ErrorMessage = "The name must be no more than 50 characters")]
        public string? BloodBankName { get; set; }

        [Required(ErrorMessage = "Please enter the blood bank address")]
        [StringLength(100, ErrorMessage = "The address must be no more than 100 characters")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Please enter the blood bank phone number")]
        [StringLength(20, ErrorMessage = "The phone number must be no more than 20 characters")]

        public string Phone { get; set; }

        public List<BloodBankModel> getData()
        {
            List<BloodBankModel> lstbb = new List<BloodBankModel>();
            SqlDataAdapter apt = new SqlDataAdapter("SELECT * from BloodBank", con);

            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                lstbb.Add(new BloodBankModel
                {
                    BloodBankID = dr["BloodBankID"].ToString(),

                    BloodBankName = dr["BloodBankName"].ToString(),
                    Address = dr["Address"].ToString(),
                    Phone = dr["Phone"].ToString()
                });
            }

            return lstbb;
        }
        public bool insert(BloodBankModel NewBB)
        {
            SqlCommand cmd = new SqlCommand("insert into BloodBank(BloodBankName,Address,Phone) values(@bbn,@ad,@ph)", con);
            cmd.Parameters.AddWithValue("@bbn", NewBB.BloodBankName);
            cmd.Parameters.AddWithValue("@ad", NewBB.Address);
            cmd.Parameters.AddWithValue("@ph", NewBB.Phone);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        public BloodBankModel getData(string Id)
        {
            BloodBankModel NewBB = new BloodBankModel();
            SqlCommand cmd = new SqlCommand("select * from BloodBank where BloodBankID='" + Id + "'", con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    NewBB.BloodBankID = dr["BloodBankID"].ToString();
                    NewBB.BloodBankName =dr["BloodBankName"].ToString();
                    NewBB.Address = dr["Address"].ToString();
                    NewBB.Phone = dr["Phone"].ToString();
                }
            }
            con.Close();
            return NewBB;
        }
        public bool update(BloodBankModel newBB)
        {
            SqlCommand cmd = new SqlCommand("update BloodBank set BloodBankName=@bbn, Address=@ad, Phone=@ph where BloodBankID = @id", con);
            cmd.Parameters.AddWithValue("@id", newBB.BloodBankID);
            cmd.Parameters.AddWithValue("@bbn", newBB.BloodBankName);
            cmd.Parameters.AddWithValue("@ad", newBB.Address);
            cmd.Parameters.AddWithValue("@ph", newBB.Phone);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }

        public bool delete(BloodBankModel newBB)
        {
            SqlCommand cmd = new SqlCommand("delete from BloodBank where BloodBankID = @id", con);
            cmd.Parameters.AddWithValue("@id", newBB.BloodBankID);

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
    

