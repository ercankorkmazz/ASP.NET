using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sinifSil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bilgiIMG.Visible = false;
        bilgiTXT.Text = "";

        baglanti sinifListele = new baglanti();
        sinifListele.verileriGetir("select * from siniflar");
        if (sinifListele.SQLTablo.Rows.Count > 0)
        {
            if (siniflar.Items.Count == 0)
            {
                siniflar.Items.Add(new ListItem("Sınıf Seçiniz", "0"));

                for (int i = 0; i <= sinifListele.SQLTablo.Rows.Count - 1; i++)
                {
                    siniflar.Items.Add(new ListItem(sinifListele.SQLTablo.Rows[i][1].ToString(), sinifListele.SQLTablo.Rows[i][0].ToString()));
                }
            }
        }
        else
        {
            siniflar.Items.Clear();
            siniflar.Items.Add(new ListItem("Sınıf Bulunamadı.", "0"));
        }

    }
    protected void sinifSilBTN_Click(object sender, EventArgs e)
    {
        if (siniflar.SelectedValue == "0")
        {
            bilgiTXT.Text = "Sınıf Seçiniz.";
            bilgiIMG.Visible = true;
        }
        else
        { 
            baglanti sinifSil = new baglanti();
            if (sinifSil.komutCalistir("delete from siniflar where id='"+siniflar.SelectedValue+"'") == "1")
            {
                bilgiTXT.Text = "Sınıf Silindi.";
                bilgiIMG.Visible = true;
            }
            else
            {
                bilgiTXT.Text = "İşlem Başarısız. Lütfen Daha Sonra Tekrar Deneyiniz.";
                bilgiIMG.Visible = true;
            }

            siniflar.Items.Clear();
            baglanti sinifListele = new baglanti();
            sinifListele.verileriGetir("select * from siniflar");
            if (sinifListele.SQLTablo.Rows.Count > 0)
            {
                if (siniflar.Items.Count == 0)
                {
                    siniflar.Items.Add(new ListItem("Sınıf Seçiniz", "0"));

                    for (int i = 0; i <= sinifListele.SQLTablo.Rows.Count - 1; i++)
                    {
                        siniflar.Items.Add(new ListItem(sinifListele.SQLTablo.Rows[i][1].ToString(), sinifListele.SQLTablo.Rows[i][0].ToString()));
                    }
                }
            }
            else
            {
                siniflar.Items.Clear();
                siniflar.Items.Add(new ListItem("Sınıf Bulunamadı.", "0"));
            }
        }
    }
    protected void siniflar_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}