using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for akranvideoislemleri
/// </summary>
public class akranvideogetir
{
    baglanti cnn = new baglanti();
    public List<akranvideo> akranVideoListeleVideoID(int id)
    {
        int videoID = id;

        List<akranvideo> gelenliste = new List<akranvideo>();

        SqlCommand cmd = new SqlCommand("Select * From ogrencivideo where id=" + videoID, cnn.baglan);
            cnn.baglan.Open();

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string adSoyad = "";
                string aciklamalar = "";

                baglanti adSoyadCek = new baglanti();
                adSoyadCek.verileriGetir("select adSoyad,aciklamalar from ogrenciler where id='" + rdr.GetInt32(1) + "'");
                if (adSoyadCek.SQLTablo.Rows.Count > 0)
                {
                    adSoyad = adSoyadCek.SQLTablo.Rows[0][0].ToString();
                    aciklamalar = adSoyadCek.SQLTablo.Rows[0][1].ToString();
                }

                akranvideo ov = new akranvideo()
                {
                    id = rdr.GetInt32(0),
                    ogrID = rdr.GetInt32(1),
                    bilgi = rdr.GetString(2),
                    video = rdr.GetString(3),
                    adSoyad = adSoyad,
                    aciklamalar = aciklamalar
                };
                gelenliste.Add(ov);

            }
            rdr.Close();

        cnn.baglan.Close();
        return gelenliste;
    }
}