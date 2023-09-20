using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for coktanSecmeliCevaplari
/// </summary>
public class coktanSecmeliCevaplari
{
    baglanti cnn = new baglanti();
    public List<cokranSCevaplar> cevaplariListele(int id)
    {
        List<cokranSCevaplar> gelenliste = new List<cokranSCevaplar>();
        SqlCommand cmd = new SqlCommand("Select yanit From cevaplar where soruID=@ID", cnn.baglan);
        cmd.Parameters.Add("@ID", id);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            cokranSCevaplar ov = new cokranSCevaplar()
            {
                yanit = rdr.GetString(0)
            };
            gelenliste.Add(ov);
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}