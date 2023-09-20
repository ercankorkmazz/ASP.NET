using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for hastaIslemleri
/// </summary>
public class hastaIslemleri
{
    baglanti cnn = new baglanti();
    public List<hastalar> hastalariGetir(String gelenAdSoyad, String gelenTC)
    {
        List<hastalar> gelenliste = new List<hastalar>();

        String sql = "select * from hastalar order by id";
        if(gelenAdSoyad.ToString() == "" && gelenTC.ToString() != "")
            sql = "select * from hastalar where TC LIKE '%" + gelenTC.ToString() + "%' order by id";
        else if (gelenAdSoyad.ToString() != "" && gelenTC.ToString() == "")
            sql = "select * from hastalar where adSoyad LIKE '%" + gelenAdSoyad.ToString() + "%' order by id";
        else if (gelenAdSoyad.ToString() != "" && gelenTC.ToString() != "")
            sql = "select * from hastalar where adSoyad LIKE '%" + gelenAdSoyad.ToString() + "%' and TC LIKE '%" + gelenTC.ToString() + "%' order by id";

        SqlCommand cmd = new SqlCommand(sql, cnn.baglan);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            hastalar hst = new hastalar()
            {
                id = rdr.GetInt32(0),
                TC = rdr.GetString(1),
                adSoyad = rdr.GetString(2),
                yas = rdr.GetInt32(3),
                hastaninDurumu = rdr.GetString(4),
                asamaSayisi = rdr.GetInt32(5)
            };
            gelenliste.Add(hst);
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}