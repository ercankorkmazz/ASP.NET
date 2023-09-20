using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Iletisim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            sayfaIslemleri si = new sayfaIslemleri();
            rptsayfa.DataSource = si.sayfaBilgileriGetir();
            rptsayfa.DataBind();
        }
    }
    protected void mesajGonderBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (adSoyadTXT.Text != string.Empty && ePostaTXT.Text != string.Empty && konuTXT.Text != string.Empty && mesajTXT.Text != string.Empty)
        {
            baglanti mesajGonder = new baglanti();
            if (mesajGonder.komutCalistir("insert into mesajKutusu (adSoyad,ePosta,konu,mesaj) values ('" + adSoyadTXT.Text + "', '" + ePostaTXT.Text + "', '" + konuTXT.Text + "', '" + mesajTXT.Text + "')") == "1")
            {
                mainMesaj.Text = mesaj.goster("1", "Mesajınız İletildi");
                adSoyadTXT.Text = string.Empty;
                ePostaTXT.Text = string.Empty;
                konuTXT.Text = string.Empty;
                mesajTXT.Text = string.Empty;
            }
            else
            {
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
            }
        }
        else
        {
            mainMesaj.Text = mesaj.goster("2", "İletişim formundaki tüm bilgiler eksiksiz doldurulmalıdır.");
        }
    }
}