using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for coktanSecmeliSorulariGetir
/// </summary>
public class coktanSecmeliSorulariGetir
{
    baglanti cnn = new baglanti();
    public List<sorular> coktanSecmeliListele(int id)
    {
        List<sorular> gelenliste = new List<sorular>();
        SqlCommand cmd = new SqlCommand("Select * From sorular where turu='1' and testID=@ID", cnn.baglan);
        cmd.Parameters.Add("@ID", id);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            sorular ov = new sorular()
            {
                id = rdr.GetInt32(0),
                soru = rdr.GetString(2),
                yanit = rdr.GetByte(3)
            };
            gelenliste.Add(ov);
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}