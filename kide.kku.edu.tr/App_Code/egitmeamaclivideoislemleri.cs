using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for egitmeamaclivideoislemleri
/// </summary>
public class egitmeamaclivideoislemleri
{
    baglanti cnn = new baglanti();
    public List<egitmeamaclivideolar> videolariGetir()
    {
        List<egitmeamaclivideolar> gelenliste = new List<egitmeamaclivideolar>();
        SqlCommand cmd = new SqlCommand("select bilgi,video from egiticivideolar order by id desc", cnn.baglan);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            egitmeamaclivideolar eav = new egitmeamaclivideolar()
            {
                bilgi = rdr.GetString(0),
                video = rdr.GetString(1)
            };
            gelenliste.Add(eav);
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}