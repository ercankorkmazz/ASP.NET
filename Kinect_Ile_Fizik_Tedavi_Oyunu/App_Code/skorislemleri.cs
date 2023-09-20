using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for hastaIslemleri
/// </summary>
public class skorislemleri
{
    baglanti cnn = new baglanti();
    public List<skorlar> skorGetir(int gelenHastaID)
    {
        List<skorlar> gelenliste = new List<skorlar>();

        SqlCommand cmd = new SqlCommand("select * from skorlar where hastaID=" + gelenHastaID + " order by id desc", cnn.baglan);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            skorlar skr = new skorlar()
            {
                id = rdr.GetInt32(0),
                hastaID = rdr.GetInt32(1),
                asamaNO = rdr.GetByte(2).ToString() + ". Seviye",
                basari = rdr.GetString(3),
                tarih = rdr.GetString(4)
            };
            gelenliste.Add(skr);
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}