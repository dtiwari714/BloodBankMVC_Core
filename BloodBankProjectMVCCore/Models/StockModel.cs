using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;

namespace BloodBankProjectMVCCore.Models
{
    public class StockModel
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-4I63O79Q\SQL2022;Initial Catalog=BloodBankDb;Integrated Security=True;TrustServerCertificate=True;Encrypt=True;");

        [Key]
        public int StockID { get; set; }

        public string? BloodTypeID { get; set; }

        public string? BloodBankID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey("BloodTypeID")]
        public virtual BloodTypeModel BloodType { get; set; }

        [ForeignKey("BloodBankID")]
        public virtual BloodBankModel BloodBank { get; set; }
        public List<StockModel> getData()
        {
            List<StockModel> lstStock = new List<StockModel>();
            SqlDataAdapter apt = new SqlDataAdapter("SELECT d.StockID,d.Quantity,u.BloodBankName,b.BloodGroup FROM [Stock] d INNER JOIN [BloodBank] u ON d.BloodBankID = u.BloodBankID INNER JOIN [BloodType] b ON d.BloodTypeID = b.BloodTypeID ", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstStock.Add(new StockModel
                {
                    StockID = Convert.ToInt32(dr["StockID"].ToString()),
                    BloodBankID = dr["BloodBankName"].ToString(),
                    BloodTypeID = dr["BloodGroup"].ToString(),
                    Quantity = Convert.ToInt32(dr["Quantity"].ToString())

                }); ;
            }

            return lstStock;
        }
        public bool insert(StockModel stock)
        {
            SqlCommand cmd = new SqlCommand("insert into Stock(BloodTypeID,BloodBankID,Quantity) values(@bti,@bbi,@q)", con);
            cmd.Parameters.AddWithValue("@bti", stock.BloodTypeID);
            cmd.Parameters.AddWithValue("@bbi", stock.BloodBankID);
            cmd.Parameters.AddWithValue("@q", stock.Quantity);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        public StockModel getData(string Id)
        {
            StockModel NewStock = new StockModel();
            SqlCommand cmd = new SqlCommand("SELECT d.StockID,d.Quantity,u.BloodBankName,b.BloodGroup FROM [Stock] d INNER JOIN [BloodBank] u ON d.BloodBankID = u.BloodBankID INNER JOIN [BloodType] b ON d.BloodTypeID = b.BloodTypeID where StockID='" + Id + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    NewStock.StockID = Convert.ToInt32(dr["StockID"].ToString());
                    NewStock.BloodBankID = dr["BloodBankName"].ToString();
                    NewStock.BloodTypeID = dr["BloodGroup"].ToString();
                    NewStock.Quantity = Convert.ToInt32(dr["Quantity"].ToString());
                    
                }
            }
            con.Close();
            return NewStock;
        }
        public bool update(StockModel stock)
        {
            SqlCommand cmd = new SqlCommand("update Stock set BloodTypeID=@bti, BloodBankID=@bbi, Quantity=@q where StockID = @id", con);
            cmd.Parameters.AddWithValue("@id", stock.StockID);

            cmd.Parameters.AddWithValue("@bti", stock.BloodTypeID);
            cmd.Parameters.AddWithValue("@bbi", stock.BloodBankID);
            cmd.Parameters.AddWithValue("@q", stock.Quantity);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        public bool delete(StockModel stock)
        {
            SqlCommand cmd = new SqlCommand("delete from Stock where StockID = @id", con);
            cmd.Parameters.AddWithValue("@id", stock.StockID);
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
