using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for hastaIslemleri
/// </summary>
public class fizyoterapistIslemleri
{
    baglanti cnn = new baglanti();
    public List<fizyoterapistler> fizyoterapistGetir()
    {
        List<fizyoterapistler> gelenliste = new List<fizyoterapistler>();

        SqlCommand cmd = new SqlCommand("select id, adSoyad, kadi, sifre, kontrol from kullanicilar where KTuru='1' order by id", cnn.baglan);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            string gelenSifre = rdr.GetString(3);

            if (rdr.GetByte(4) == 1)
                gelenSifre = "Güncellendi";

            fizyoterapistler fzt = new fizyoterapistler()
            {
                id = rdr.GetInt32(0),
                adSoyad = rdr.GetString(1),
                kadi = rdr.GetString(2),
                sifre = gelenSifre
            };
            gelenliste.Add(fzt);
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}