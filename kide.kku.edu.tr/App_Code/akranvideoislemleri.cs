using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for akranvideoislemleri
/// </summary>
public class akranvideoislemleri
{
    baglanti cnn = new baglanti();
    public List<akranvideo> digerVideoListeleOgrID(int id)
    {
        List<akranvideo> gelenliste = new List<akranvideo>();

        int ogrID = id;
        SqlCommand cmd = new SqlCommand("Select * From ogrencivideo where ogrID = " + ogrID.ToString(), cnn.baglan);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
                string adSoyad = "";
                baglanti adSoyadCek = new baglanti();
                adSoyadCek.verileriGetir("select adSoyad from ogrenciler where id='" + rdr.GetInt32(1) + "'");
                if (adSoyadCek.SQLTablo.Rows.Count > 0)
                    adSoyad = adSoyadCek.SQLTablo.Rows[0][0].ToString();

                akranvideo ov = new akranvideo()
                {
                    id = rdr.GetInt32(0),
                    ogrID = rdr.GetInt32(1),
                    bilgi = rdr.GetString(2)
                };
                gelenliste.Add(ov);

        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}