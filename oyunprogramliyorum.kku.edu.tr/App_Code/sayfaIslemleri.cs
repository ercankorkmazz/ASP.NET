using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for sayfaIslemleri
/// </summary>
public class sayfaIslemleri
{
    baglanti cnn = new baglanti();
    public List<Sayfalar> sayfaBilgileriGetir()
    {
        List<Sayfalar> gelenliste = new List<Sayfalar>();
        SqlCommand cmd = new SqlCommand("select * from sayfalar where id=1", cnn.baglan);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            Sayfalar op = new Sayfalar()
            {
                id = rdr.GetInt32(0),
                title = rdr.GetString(1),
                bannerText = rdr.GetString(2),
                hakkinda = rdr.GetString(3),
                projeEkibi = rdr.GetString(4),
                etkinlikHakkinda = rdr.GetString(5),
                etkinlikKonusu = rdr.GetString(6),
                etkinlikTarihiYeri = rdr.GetString(7),
                etkinlikProgrami = rdr.GetString(8),
                katilimciKriterleri = rdr.GetString(9),
                katilimFormu = rdr.GetString(10),
                duyurular = rdr.GetString(11),
                yayinlar = rdr.GetString(12),
                iletisim = rdr.GetString(13)
            };
            gelenliste.Add(op);
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}