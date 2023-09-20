using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for egitmeamaclivideoislemleri
/// </summary>
public class ogrenciperformansislemleri
{
    baglanti cnn = new baglanti();
    public List<ogrenciperformansi> performansGetir(string tcNo)
    {
        List<ogrenciperformansi> gelenliste = new List<ogrenciperformansi>();
        SqlCommand cmd = new SqlCommand("select * from PerformanceTable where IDNumber = @TC order by PerformaneID desc", cnn.baglan);
        cmd.Parameters.Add("@TC", tcNo);
        cnn.baglan.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            ogrenciperformansi op = new ogrenciperformansi()
            {
                PerformaneID = rdr.GetInt32(0),
                UserName = rdr.GetString(1),
                ProgramName = rdr.GetString(2),
                InstructorUserName = rdr.GetString(3),
                OverallPerformance = rdr.GetFloat(4),
                Date = rdr.GetDateTime(5),
                IDNumber = rdr.GetDecimal(6)
            };
            gelenliste.Add(op);
        }
        rdr.Close();
        cnn.baglan.Close();
        return gelenliste;
    }
}