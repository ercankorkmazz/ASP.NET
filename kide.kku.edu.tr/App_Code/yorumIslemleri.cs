using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for yorumIslemleri
/// </summary>
public class yorumIslemleri
{
    baglanti cnn = new baglanti();
    public List<yorumlar> yorumCekOgrenciID(int id)
    {
	    List<yorumlar> gelenliste = new List<yorumlar>();
        SqlCommand cmd = new SqlCommand("select * from yorumlar where ogrenciID=@ID", cnn.baglan);
        cmd.Parameters.Add("@ID", id);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            baglanti adSoyadGetir = new baglanti();
            string adSoyad = "";
            if (rdr.GetByte(5) == 1)
            {
                adSoyad = "Yönetici";
            }
            else if (rdr.GetByte(5) == 2)
            {
                adSoyadGetir.verileriGetir("select adSoyad from kullanici where id='" + rdr.GetInt32(2) + "'");

                if (adSoyadGetir.SQLTablo.Rows.Count > 0)
                    adSoyad = adSoyadGetir.SQLTablo.Rows[0][0].ToString();

            }
            else if (rdr.GetByte(5) == 3)
            {
                adSoyadGetir.verileriGetir("select adSoyad from ogrenciler where id='" + rdr.GetInt32(1) + "'");

                if (adSoyadGetir.SQLTablo.Rows.Count > 0)
                    adSoyad = adSoyadGetir.SQLTablo.Rows[0][0].ToString();
            }
            
            yorumlar ov = new yorumlar()
            {
                yorumID = rdr.GetInt32(0),
                ogrenciID = rdr.GetInt32(1),
                egitmenID = rdr.GetInt32(2),
                videoID = rdr.GetInt32(3),
                yorum = rdr.GetString(4),
                kontrol = rdr.GetByte(5),
                adSoyad = adSoyad
            };
            gelenliste.Add(ov);
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}