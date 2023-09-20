using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for sliderIslemleri
/// </summary>
public class projeIslemleri
{
    baglanti cnn = new baglanti();
    public List<Proje> projeleriGetir()
    {
        List<Proje> gelenliste = new List<Proje>();
        SqlCommand cmd = new SqlCommand("select projeler.id,projeler.projeBasligi,kategoriler.baslik from kategoriler INNER JOIN projeler ON projeler.kategoriID = kategoriler.id", cnn.baglan);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            Proje op = new Proje()
            {
                id = rdr.GetInt32(0),
                projeBasligi = rdr.GetString(1),
                baslik = rdr.GetString(2)
            };
            gelenliste.Add(op);
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}