using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for dersNotuIslemleri
/// </summary>
public class dersNotuIslemleri
{
    baglanti cnn = new baglanti();
    public List<dersNotlari> dersNotuGetir()
    {
        List<dersNotlari> gelenliste = new List<dersNotlari>();
        SqlCommand cmd = new SqlCommand("select baslik,bilgi,dosya from notlar order by id desc", cnn.baglan);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            dersNotlari ev = new dersNotlari()
            {
                baslik = rdr.GetString(0),
                bilgi = rdr.GetString(1),
                dosya = rdr.GetString(2)
            };
            gelenliste.Add(ev);
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}