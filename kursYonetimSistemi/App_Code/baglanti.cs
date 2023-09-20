using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public class baglanti
{
    SqlConnection baglan = new SqlConnection();
    public DataTable SQLTablo = new DataTable();
    
    public baglanti()
    {
        baglan.ConnectionString = ConfigurationManager.ConnectionStrings["baglantiString"].ConnectionString;
    }
    public void verileriGetir(String command)
    {
        try
        {
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter(command, baglan);
            da.Fill(SQLTablo);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write("<script>alert('Bağlantı yapılamadı." + ex.Message + "');</script>");
        }
        finally { baglan.Close(); }
    }
    public String komutCalistir(String command)
    {
        try
        {
            string sonuc = "";
            baglan.Open();
            SqlCommand sqlcomm = new SqlCommand(command,baglan);
            
            int satirSay = sqlcomm.ExecuteNonQuery();
            if (satirSay > 0)
            {
                sonuc = "1";
            }
            else
            {
                sonuc = "0";
            }
            return sonuc.ToString();
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write("<script>alert('Bağlantı yapılamadı." + ex.Message + "');</script>");
            return "";
        }
        finally { baglan.Close(); }
        
    }
}