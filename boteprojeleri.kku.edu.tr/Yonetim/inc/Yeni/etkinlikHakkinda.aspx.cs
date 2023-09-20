using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim_inc_etkinlikHakkinda : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            baglanti bilgiGetir = new baglanti();
            bilgiGetir.verileriGetir("select etkinlikHakkinda from sayfalar where id='1'");
            if (bilgiGetir.SQLTablo.Rows.Count > 0)
            {
                etkinlikHakkindaTXT.InnerText = bilgiGetir.SQLTablo.Rows[0][0].ToString();
            }
        }
    }
    protected void kaydetBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        baglanti sayfaGuncelle = new baglanti();
        if (sayfaGuncelle.komutCalistir("update sayfalar set etkinlikHakkinda='" + etkinlikHakkindaTXT.InnerText + "' where id='1'") == "1")
        {
            mainMesaj.Text = mesaj.goster("1", "Güncellene Yapıldı");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
    }
}