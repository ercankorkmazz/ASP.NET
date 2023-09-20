using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for yorumlar
/// </summary>
public class yorumlar
{
    public int yorumID { get; set; }
    public int ogrenciID { get; set; }
    public int egitmenID { get; set; }
    public int videoID { get; set; }
    public string yorum { get; set; }
    public int kontrol { get; set; }
    public string adSoyad { get; set; }
}