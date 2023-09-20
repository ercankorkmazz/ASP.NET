using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for siteAyarlari
/// </summary>
public class siteAyarlari
{
    baglanti cnn = new baglanti();
    public List<Site> siteBilgileriniGetir()
    {
        List<Site> gelenliste = new List<Site>();
        SqlCommand cmd = new SqlCommand("select * from siteAyarlari where id=1", cnn.baglan);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            Site op = new Site()
            {
                id = rdr.GetInt32(0),
                title = rdr.GetString(1),
                anahtarKelimeler = rdr.GetString(2),
                aciklama = rdr.GetString(3),
                bizKimiz = rdr.GetString(4),
                adres = rdr.GetString(5),
                telefon = rdr.GetString(6),
                ePosta = rdr.GetString(7),
                facebookLink = rdr.GetString(8),
                twitterLink = rdr.GetString(9),
                flickrLink = rdr.GetString(10),
                googleLink = rdr.GetString(11),
                dribbbleLink = rdr.GetString(12)
            };
            gelenliste.Add(op);
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}