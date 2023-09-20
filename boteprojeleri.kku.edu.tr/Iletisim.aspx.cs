using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Iletisim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void gonderBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = Master.FindControl("mesajTXT") as Literal;

        if (adSoyadTXT.Value != "" && ePostaTXT.Value != "" && konuTXT.Value != "" && mesajTXT.InnerText != "")
        {
            baglanti mesajGonder = new baglanti();
            if (mesajGonder.komutCalistir("insert into iletisim (adSoyad,ePosta,konu,mesaj) values ('" + adSoyadTXT.Value + "', '" + ePostaTXT.Value + "', '" + konuTXT.Value + "', '" + mesajTXT.InnerText + "')") == "1")
            {
                adSoyadTXT.Value = string.Empty;
                ePostaTXT.Value = string.Empty;
                konuTXT.Value = string.Empty;
                mesajTXT.InnerText = string.Empty;
                mainMesaj.Text = mesaj.goster("1", "Mesajınız İletilmiştir");
            }
            else
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "* ile belirtilen alanlar boş bırakılamaz.");
    }
}