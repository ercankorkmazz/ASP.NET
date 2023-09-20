using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        baglanti bilgiGetir = new baglanti();
        bilgiGetir.verileriGetir("select anasayfa from bilgiler where id='1'");
        if (bilgiGetir.SQLTablo.Rows.Count > 0)
        {
            anasayfaTXT.Text = bilgiGetir.SQLTablo.Rows[0][0].ToString();
        }
    }
}