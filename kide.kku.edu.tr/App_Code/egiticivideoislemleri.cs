using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for egiticivideoislemleri
/// </summary>
public class egiticivideoislemleri
{
    baglanti cnn = new baglanti();
	public List<egiticivideolar> videoGetirEgitmenId(int id)
	{
        List<egiticivideolar> gelenliste = new List<egiticivideolar>();
        SqlCommand cmd = new SqlCommand("select * from egiticivideolar where egitmenID=@ID order by id desc", cnn.baglan);
        cmd.Parameters.Add("@ID", id);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            egiticivideolar ev = new egiticivideolar()
            {
                id = rdr.GetInt32(0),
                egitmenID = rdr.GetInt32(1),
                bilgi = rdr.GetString(2),
                video = rdr.GetString(3)
            };
            gelenliste.Add(ev);
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
	}
}