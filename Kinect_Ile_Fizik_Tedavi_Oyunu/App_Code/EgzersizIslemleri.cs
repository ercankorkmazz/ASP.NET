using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for hastaIslemleri
/// </summary>
public class EgzersizIslemleri
{
    baglanti cnn = new baglanti();
    public List<Egzersiz> EgzersizGetir(int gelenHastaID, int gelenAsamaNO)
    {
        List<Egzersiz> gelenliste = new List<Egzersiz>();
        
        SqlCommand cmd = new SqlCommand("select * from egzersizProgramlari where hastaID=" + gelenHastaID.ToString() + " and asamaNO=" + gelenAsamaNO.ToString() + " order by id", cnn.baglan);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            int hareketNo = rdr.GetInt32(3);
            string gelenHareketTanimi = "";

            baglanti bilgiGetir = new baglanti();
            bilgiGetir.verileriGetir("select hareketADI from hareketler where hareketID='" + hareketNo.ToString() + "'");
            if (bilgiGetir.SQLTablo.Rows.Count > 0)
            {
                gelenHareketTanimi = bilgiGetir.SQLTablo.Rows[0][0].ToString();
            }

            Egzersiz egz = new Egzersiz()
            {
                id = rdr.GetInt32(0),
                hastaID = rdr.GetInt32(1),
                asamaNO = rdr.GetByte(2),
                hareketTanimi = gelenHareketTanimi,
                beklemeSuresi = rdr.GetInt32(4),
                hareketTekrari = rdr.GetInt32(5),
                aciklamalar = rdr.GetString(6)
            };
            gelenliste.Add(egz);
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}