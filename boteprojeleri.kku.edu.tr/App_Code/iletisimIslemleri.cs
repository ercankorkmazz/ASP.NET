using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for sliderIslemleri
/// </summary>
public class iletisimIslemleri
{
    baglanti cnn = new baglanti();
    public List<Iletisim> mesajGetir()
    {
        List<Iletisim> gelenliste = new List<Iletisim>();
        SqlCommand cmd = new SqlCommand("select * from iletisim", cnn.baglan);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            Iletisim op = new Iletisim()
            {
                id = rdr.GetInt32(0),
                adSoyad = rdr.GetString(1),
                ePosta = rdr.GetString(2),
                konu = rdr.GetString(3),
                mesaj = rdr.GetString(4)
            };
            gelenliste.Add(op);
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}