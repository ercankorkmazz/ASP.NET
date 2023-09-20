using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for boslukDoldurmaSorusuGetir
/// </summary>
public class boslukDoldurmaSorusuGetir
{
    baglanti cnn = new baglanti();
    public List<sorular> boslukDoldurmaListele(int id)
    {
        List<sorular> gelenliste = new List<sorular>();
        SqlCommand cmd = new SqlCommand("Select * From sorular where turu='2' and testID=@ID", cnn.baglan);
        cmd.Parameters.Add("@ID", id);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            sorular ov = new sorular()
            {
                id = rdr.GetInt32(0),
                soru = rdr.GetString(2),
                cevap = rdr.GetString(4)
            };
            gelenliste.Add(ov);
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}