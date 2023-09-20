using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_yonetim_YeniHasta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "1")
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
    }

    protected void kaydetBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (tcNoTXT.Text != "" && adSoyadTXT.Text != "" && yasTXT.Text != "" && hastaDurumuTXT.Text != "")
        {
            baglanti HastaEkle = new baglanti();
            if (HastaEkle.komutCalistir("insert into hastalar (TC, adSoyad, yas, hastaninDurumu, asamaSayisi, asamaKontrolu) values ('" + tcNoTXT.Text + "', '" + adSoyadTXT.Text + "', '" + yasTXT.Text + "', '" + hastaDurumuTXT.Text + "', '0', '1')") == "1")
            {
                string hastaID = "0";
                string TCKimlikNo = "0";

                baglanti idGetir = new baglanti();
                idGetir.verileriGetir("select id, TC from hastalar order by id desc");
                if (idGetir.SQLTablo.Rows.Count > 0)
                {
                    hastaID = idGetir.SQLTablo.Rows[0][0].ToString();
                    TCKimlikNo = idGetir.SQLTablo.Rows[0][1].ToString();
                }
                baglanti KullaniciEkle = new baglanti();
                if (KullaniciEkle.komutCalistir("insert into kullanicilar (hastaID, adSoyad, kadi, sifre, KTuru, kontrol) values ('" + hastaID + "', '" + adSoyadTXT.Text + "', '" + TCKimlikNo + "', '" + TCKimlikNo + "', '2', '0')") == "1")
                {
                    tcNoTXT.Text = "";
                    adSoyadTXT.Text = "";
                    yasTXT.Text = "";
                    hastaDurumuTXT.Text = "";
                    mainMesaj.Text = mesaj.goster("1", "Hasta kaydı yapıldı.");
                }
                else
                {
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                }
            }
            else
            {
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
            }
        }
        else
        {
            mainMesaj.Text = mesaj.goster("2", "Tüm alanları doldurunuz.");
        }
    }

    protected void geriDonBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/inc/yonetim/Hastalar.aspx");
    }
}