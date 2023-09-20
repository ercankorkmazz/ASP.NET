using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ogretmenKayit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bilgiIMG.Visible = false;
        bilgiTXT.Text = "";
    }
    protected void kullaniciGuncelleBTN_Click(object sender, EventArgs e)
    {
        if (mSifreTXT.Text != String.Empty)
        {
            baglanti mSifreGetir = new baglanti();
            mSifreGetir.verileriGetir("select * from uyelik where id='" + Session["oturum"] + "'");
            if (mSifreGetir.SQLTablo.Rows.Count > 0)
            {
                if (mSifreTXT.Text == mSifreGetir.SQLTablo.Rows[0][2].ToString())
                {
                    if (ySifreTXT.Text != String.Empty)
                    {
                        if (tSifreTXT.Text != String.Empty)
                        {
                            if (ySifreTXT.Text == tSifreTXT.Text)
                            {
                                baglanti kadiGetir = new baglanti();
                                if (kadiGetir.komutCalistir("update uyelik set kadi = '" + kadiTXT.Text + "' , sifre = '" + ySifreTXT.Text + "' where id='" + Session["oturum"] + "'") == "1")
                                {
                                    bilgiTXT.Text = "Kullanıcı adı ve şifre güncellendi.";
                                    bilgiIMG.Visible = true;
                                }

                            }
                            else
                            {
                                bilgiTXT.Text = "Yeni şifre ile şifre tekrarı aynı olmalıdır.";
                                bilgiIMG.Visible = true;
                            }

                        }
                        else
                        {
                            bilgiTXT.Text = "Şifre tekrarı boş bırakılamaz.";
                            bilgiIMG.Visible = true;
                        }
                    }
                    else
                    {
                        bilgiTXT.Text = "Yeni şifre boş bırakılamaz.";
                        bilgiIMG.Visible = true;
                    }
                }
                else
                {
                    bilgiTXT.Text = "Mevcut şifreyi yanlış girdiniz.";
                    bilgiIMG.Visible = true;
                }
            }
        }
        else
        {
            baglanti kadiGetir = new baglanti();
            if (kadiGetir.komutCalistir("update uyelik set kadi = '" + kadiTXT.Text + "' where id='" + Session["oturum"] + "'") == "1")
            {
                bilgiTXT.Text = "Kullanıcı adı güncellendi.";
                bilgiIMG.Visible = true;
            }
        }
    }
}
