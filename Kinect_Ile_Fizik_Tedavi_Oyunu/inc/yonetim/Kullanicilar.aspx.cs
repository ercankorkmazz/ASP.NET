using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_yonetim_Kullanicilar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "1")
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }

        if (Page.IsPostBack == false)
        {
            baglanti bilgiGetir = new baglanti();

            bilgiGetir.verileriGetir("select adSoyad, kadi from kullanicilar where id='" + Session[Request.Url.Authority + "oturum"] + "'");
            if (bilgiGetir.SQLTablo.Rows.Count > 0)
            {
                uyeAdSoyadTXT.Text = bilgiGetir.SQLTablo.Rows[0][0].ToString();
                uyeKadiTXT.Text = bilgiGetir.SQLTablo.Rows[0][1].ToString();
                uyeSifreTXT.Text = "";
            }

            fizyoterapistIslemleri vi = new fizyoterapistIslemleri();
            RPTFizyoterapistler.DataSource = vi.fizyoterapistGetir();
            RPTFizyoterapistler.DataBind();
        }
    }

    protected void GuncelleBtn_Click(object sender, EventArgs e)
    {
        
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (uyeSifreTXT.Text != "" && uyeKadiTXT.Text != "" && uyeAdSoyadTXT.Text != "")
        {
            baglanti KullaniciGuncelle = new baglanti();

            if (KullaniciGuncelle.komutCalistir("update kullanicilar set adSoyad='" + uyeAdSoyadTXT.Text + "', kadi='" + uyeKadiTXT.Text + "', sifre='" + uyeSifreTXT.Text + "', kontrol='1' where id='" + Session[Request.Url.Authority + "oturum"] + "'") == "1")
            {
                mainMesaj.Text = mesaj.goster("1", "Güncelleme Yapıldı");

                fizyoterapistIslemleri vi = new fizyoterapistIslemleri();
                RPTFizyoterapistler.DataSource = vi.fizyoterapistGetir();
                RPTFizyoterapistler.DataBind();
            }
            else
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "Tüm alanları doldurunuz.");
    }

    protected void btnfizyoekle_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (txtfizyoadi.Text != "" && txtfizyokadi.Text != "" && txtfizyosifre.Text != "")
        {
            baglanti KSorgula = new baglanti();
            KSorgula.verileriGetir("select kadi from kullanicilar where kadi='" + txtfizyokadi.Text + "'");
            if (KSorgula.SQLTablo.Rows.Count > 0)
            {
                mainMesaj.Text = mesaj.goster("2", "&#8220;" + txtfizyokadi.Text + "&#8221; kullanıcısı zaten mevcut.");
            }
            else
            {
                baglanti HastaEkle = new baglanti();
                if (HastaEkle.komutCalistir("insert into kullanicilar (hastaID, adSoyad, kadi, sifre, KTuru, kontrol) values ('0', '" + txtfizyoadi.Text + "', '" + txtfizyokadi.Text + "', '" + txtfizyosifre.Text + "', '1', '0')") == "1")
                {
                    mainMesaj.Text = mesaj.goster("1", "Fizyoterapist Eklendi");

                    fizyoterapistIslemleri vi = new fizyoterapistIslemleri();
                    RPTFizyoterapistler.DataSource = vi.fizyoterapistGetir();
                    RPTFizyoterapistler.DataBind();
                }
                else
                {
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                }
            }
        }
        else   
        {
            mainMesaj.Text = mesaj.goster("2", "Tüm alanları doldurunuz.");
        }
    }

    protected void RPTFizyoterapistler_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (e.CommandName == "silButonlari")
        {
            int silinecekID = Convert.ToInt32(e.CommandArgument.ToString());

            baglanti fizyoterapistSil = new baglanti();
            if (fizyoterapistSil.komutCalistir("delete from kullanicilar where id=" + silinecekID) == "1")
            {
                mainMesaj.Text = mesaj.goster("1", "Fizyoterapist Kaydı Silindi");

                fizyoterapistIslemleri vi = new fizyoterapistIslemleri();
                RPTFizyoterapistler.DataSource = vi.fizyoterapistGetir();
                RPTFizyoterapistler.DataBind();
            }
            else
            {
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
            }
        }
    }
}