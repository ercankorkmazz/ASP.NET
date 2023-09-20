using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for sliderIslemleri
/// </summary>
public class sliderIslemleri
{
    baglanti cnn = new baglanti();
    public List<Slider> resimGetir()
    {
        List<Slider> gelenliste = new List<Slider>();
        SqlCommand cmd = new SqlCommand("select * from slider", cnn.baglan);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            Slider op = new Slider()
            {
                id = rdr.GetInt32(0),
                img = rdr.GetString(1),
                baslik = rdr.GetString(2),
                aciklama = rdr.GetString(3)
            };
            gelenliste.Add(op);
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}