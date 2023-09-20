using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_ogrenci_testler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "oturum"] == null || Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "3")
        {
            Response.Redirect("~/Default.aspx");
        }
        GridView_testler.Visible = false;
        if (Page.IsPostBack == false)
        {
            tabloListele();
        }
    }
    protected void GridView_testler_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRowIndex = GridView_testler.SelectedIndex;
        GridViewRow row = GridView_testler.Rows[selectedRowIndex];
        int testID = Convert.ToInt32(row.Cells[0].Text);

        Session[Request.Url.Authority + "testCozID"] = testID;
        Response.Redirect("~/inc/ogrenci/test.aspx");
    }
    public void tabloListele()
    {
        int grupID = Convert.ToInt32(Session[Request.Url.Authority + "grupID"].ToString());
        string testIDler = "";

        baglanti gruplarSorgu = new baglanti();
        gruplarSorgu.verileriGetir("select id,gruplar from testler where kontrol='1'");
        if (gruplarSorgu.SQLTablo.Rows.Count > 0)
        {
            for (int i = 0; i < gruplarSorgu.SQLTablo.Rows.Count; i++)
            {
                if (gruplarSorgu.SQLTablo.Rows[i][1] != "")
                {
                    String grpIdler = gruplarSorgu.SQLTablo.Rows[i][1].ToString();
                    string[] grupIdler = grpIdler.Split('.');

                    for (int k = 0; k < grupIdler.Count(); k++)
                    {
                        if (grupIdler[k].ToString() == grupID.ToString())
	                    {
                            testIDler += "id=" + gruplarSorgu.SQLTablo.Rows[i][0] + " or ";
	                    }
                    }
                }
            }
        }
        int kontrol = 0;
        if (testIDler != String.Empty)
        {
            kontrol = 1; 
            GridView_testler.Visible = true;
            sorguSonucu.Visible = false;
        }
        else
        {
            kontrol = 0;
            GridView_testler.Visible = false;
            sorguSonucu.Visible = true;
        }

        if (kontrol == 1)
        {
            baglanti Listele = new baglanti();
            Listele.verileriGetir("select id,testadi from testler where " + testIDler.Remove(testIDler.Length - 4, 4));
            if (Listele.SQLTablo.Rows.Count > 0)
            {
                GridView_testler.DataSource = Listele.SQLTablo;
                GridView_testler.DataBind();
            }
        }
    }
}