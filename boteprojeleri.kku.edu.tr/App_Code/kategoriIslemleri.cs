using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for sliderIslemleri
/// </summary>
public class kategoriIslemleri
{
    baglanti cnn = new baglanti();
    public List<Kategoriler> kategorileriGetir()
    {
        List<Kategoriler> gelenliste = new List<Kategoriler>();
        SqlCommand cmd = new SqlCommand("select * from kategoriler where id!='1'", cnn.baglan);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            Kategoriler op = new Kategoriler()
            {
                id = rdr.GetInt32(0),
                baslik = rdr.GetString(1),
                kontrol = rdr.GetString(2)
            };
            gelenliste.Add(op);
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}