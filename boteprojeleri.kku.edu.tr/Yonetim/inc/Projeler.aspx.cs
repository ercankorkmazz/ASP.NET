using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim_inc_Projeler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            projeIslemleri ki = new projeIslemleri();
            rptProjeler.DataSource = ki.projeleriGetir();
            rptProjeler.DataBind();
            kategoriListele();
        }
    }
    protected void kaydetBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (baslikTXT.Text != string.Empty)
        {
            if (kategorilerDropDownList.SelectedIndex != 0)
            {
                baglanti sayfaGuncelle = new baglanti();
                if (sayfaGuncelle.komutCalistir("insert into projeler (kategoriID,projeBasligi,kisaAciklama,projeHakkinda,projeEkibi,yayinlar,duyurular,img,url,kontrol) values ('" + kategorilerDropDownList.SelectedValue + "', '" + baslikTXT.Text + "', '', '', '', '', '', '', '', '0')") == "1")
                {
                    baslikTXT.Text = string.Empty;
                    kategorilerDropDownList.SelectedIndex = 0;
                    mainMesaj.Text = mesaj.goster("1", "Proje Oluşturuldu");
                    projeIslemleri ki = new projeIslemleri();
                    rptProjeler.DataSource = ki.projeleriGetir();
                    rptProjeler.DataBind();
                }
                else
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
            }
            else
                mainMesaj.Text = mesaj.goster("2", "Kategori seçiniz.");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "Proje başlığı yazınız.");
    }
    public void kategoriListele()
    {
        baglanti gruplariGetir = new baglanti();
        gruplariGetir.verileriGetir("select * from kategoriler");
        if (gruplariGetir.SQLTablo.Rows.Count > 0)
        {
            if (kategorilerDropDownList.Items.Count == 0)
            {
                kategorilerDropDownList.Items.Add(new ListItem("Kategori Seçiniz", "0"));

                for (int i = 0; i <= gruplariGetir.SQLTablo.Rows.Count - 1; i++)
                {
                    kategorilerDropDownList.Items.Add(new ListItem(gruplariGetir.SQLTablo.Rows[i][1].ToString(), gruplariGetir.SQLTablo.Rows[i][0].ToString()));
                }
            }
        }
        else
        {
            kategorilerDropDownList.Items.Clear();
            kategorilerDropDownList.Items.Add(new ListItem("Kategori ekleyiniz.", "0"));
        }
    }
    protected void rptKategoriler_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (e.CommandName == "GuncelleBTN")
        {
            int projeID = Convert.ToInt32(e.CommandArgument.ToString());
            Session[Request.Url.Authority + "projeID"] = projeID;
            Response.Redirect("~/Yonetim/inc/Proje.aspx");
        }
        if (e.CommandName == "SilBTN")
        {
            int projeID = Convert.ToInt32(e.CommandArgument.ToString());

            baglanti projeGetir = new baglanti();
            projeGetir.verileriGetir("select img from projeler where id='" + projeID.ToString() + "'");
            if (projeGetir.SQLTablo.Rows.Count > 0)
                File.Delete(Server.MapPath("~/img/projeler/" + projeGetir.SQLTablo.Rows[0][0].ToString()));

            baglanti sil = new baglanti();
            if (sil.komutCalistir("delete from projeler where id='" + projeID.ToString() + "'") == "1")
            {
                projeIslemleri ki = new projeIslemleri();
                rptProjeler.DataSource = ki.projeleriGetir();
                rptProjeler.DataBind();
                mainMesaj.Text = mesaj.goster("1", "Silindi");
            }
            else
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
        }
    }
}
