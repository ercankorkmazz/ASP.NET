using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for galeriIslemleri
/// </summary>
public class galeriIslemleri
{
    baglanti cnn = new baglanti();
    public List<Galeri> resimGetir()
    {
        List<Galeri> gelenliste = new List<Galeri>();
        SqlCommand cmd = new SqlCommand("select * from galeri", cnn.baglan);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            Galeri op = new Galeri()
            {
                id = rdr.GetInt32(0),
                img = rdr.GetString(1)
            };
            gelenliste.Add(op);
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}