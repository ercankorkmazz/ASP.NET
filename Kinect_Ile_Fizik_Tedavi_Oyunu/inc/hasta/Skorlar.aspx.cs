using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_hasta_Skorlar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "2")
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }

        if (Page.IsPostBack == false)
        {
            baglanti bilgiGetir = new baglanti();

            bilgiGetir.verileriGetir("select adSoyad from hastalar where id='" + Session[Request.Url.Authority + "hastaID"].ToString() + "'");
            if (bilgiGetir.SQLTablo.Rows.Count > 0)
            {
                hastaAdiTXT.Text = bilgiGetir.SQLTablo.Rows[0][0].ToString();
            }

            skorislemleri vi = new skorislemleri();
            RPTHastaTakibi.DataSource = vi.skorGetir(Convert.ToInt32(Session[Request.Url.Authority + "hastaID"].ToString()));
            RPTHastaTakibi.DataBind();
        }
    }
}