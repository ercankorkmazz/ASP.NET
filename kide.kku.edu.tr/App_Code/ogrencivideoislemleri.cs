using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ogrencivideoislemleri
/// </summary>
public class ogrencivideoislemleri
{
    baglanti cnn = new baglanti();
    public List<ogrencivideo> VideoListele(int id)
    {
        List<ogrencivideo> gelenliste = new List<ogrencivideo>();
        SqlCommand cmd = new SqlCommand("Select * From ogrencivideo where ogrID=@ID", cnn.baglan);
        cmd.Parameters.Add("@ID", id);
        cnn.baglan.Open();
        
        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            ogrencivideo ov = new ogrencivideo() { id = rdr.GetInt32(0), ogrID = rdr.GetInt32(1), bilgi = rdr.GetString(2), video = rdr.GetString(3)
           
            };
            gelenliste.Add(ov);
            
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}