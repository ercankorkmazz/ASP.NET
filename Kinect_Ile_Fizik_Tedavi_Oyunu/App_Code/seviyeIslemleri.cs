using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for hastaIslemleri
/// </summary>
public class seviyeIslemleri
{
    baglanti cnn = new baglanti();
    public List<Seviyeler> seviyeGetir(int gelenHastaID, int gelenSeviyeSayisi)
    {
        List<Seviyeler> gelenliste = new List<Seviyeler>();
        
        for (int i=1; i <= gelenSeviyeSayisi; i++)
        {
            Seviyeler svy = new Seviyeler()
            {
                hastaID = gelenHastaID,
                seviye = i
            };
            gelenliste.Add(svy);
        }
        return gelenliste;
    }
}