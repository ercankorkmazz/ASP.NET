using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for sliderIslemleri
/// </summary>
public class projeListele
{
    baglanti cnn = new baglanti();
    public List<Projeler> projeleriGetir(int id)
    {
        List<Projeler> gelenliste = new List<Projeler>();
        SqlCommand cmd = new SqlCommand("select id,kategoriID,projeBasligi,kisaAciklama,img,url,kontrol from projeler where kategoriID=@ID", cnn.baglan);
        cmd.Parameters.Add("@ID", id);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            Projeler op = new Projeler()
            {
                id = rdr.GetInt32(0),
                kategoriID = rdr.GetInt32(1),
                projeBasligi = rdr.GetString(2),
                kisaAciklama = rdr.GetString(3),
                img = rdr.GetString(4),
                url = rdr.GetString(5),
                kontrol = rdr.GetString(6)
            };
            gelenliste.Add(op);
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}