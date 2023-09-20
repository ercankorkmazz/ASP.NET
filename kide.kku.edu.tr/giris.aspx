<%@ Page Language="C#" AutoEventWireup="true" CodeFile="giris.aspx.cs" Inherits="giris" %>

<html>
<head id="Head1" runat="server">
    <meta charset="iso-8859-9">
    <title>Kinect ile Dil Eğitimi</title>
    <script src="js/jquery-2.0.3.min.js" type="text/javascript"></script>
    <script src="js/notifIt.js" type="text/javascript"></script>
    <script src="js/jquery-2.0.3.min.js" type="text/javascript"></script>
    <script src="js/notifIt.js" type="text/javascript"></script>
    <link href="~/css/notifIt.css" type="text/css" rel="stylesheet" />

    <style type="text/css">
		@import url(http://fonts.googleapis.com/css?family=Lato:100,300,400,700);
  		@import url(http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,400,300,600,700);
  		@import url(http://fonts.googleapis.com/css?family=Noto+Sans:400,700);
	</style>
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/animate.min.css" rel="stylesheet"> 
	<link href="css/main.css" rel="stylesheet">   
</head><!--/head-->

<body>
    <form id="Form1" runat="server">
    <asp:Literal runat="server" ID="mesajTXT" />
    <header id="header">
      <div class="container" style="padding-top:10px; width:100%;">
        <div class="navbar-header" style="margin:auto; padding-right:20px; width:100%;">
            <table border="0" style="margin:auto; width:1150px;">
            	<tr>
                	<td rowspan="3" style="vertical-align:top;"><img src="images/KKU_logo.png" /></td>
                    <td style="width:55px; padding:0; text-align:center;"><img src="images/logo_giris.png" alt="logo"></td>
                	<td rowspan="3" style="text-align:right; vertical-align:top;"><img src="images/TUBITAK_logo.png" /></td>
                </tr>
                <tr>
                    <td class="logoBaslik" style="font-size:20px; padding:5px; padding-bottom:0; text-align:center;">İLE</td>
                </tr>
                <tr>
                    <td class="logoBaslik" style="padding:0; text-align:center;">DİL EĞİTİMİ</td>
                </tr>
            </table>
        </div>
     </div>
    </header>
    <!--/#header-->
    <section id="home-slider">
        <div class="container">
            <div class="row">
                <div class="main-slider">
                    <div class="slide-text">
                    <div class="contact-form bottom" style="margin-top:80px;">
                      <h2 align="center">KULLANICI GIRISI</h2>
                            <div class="form-group">
                                <asp:TextBox ID="kadiTXT" runat="server" class="form-control" style="text-align:center;"
                                    required placeholder="Kullanıcı Adı Giriniz" ValidationGroup="girisFormu"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="sifreTXT" runat="server" class="form-control" style="text-align:center;"
                                        TextMode="Password" required placeholder="Şifre Giriniz" 
                                        ValidationGroup="girisFormu"></asp:TextBox>
                            </div>                      
                            <div class="form-group">
                                <asp:Button ID="girisBTN" runat="server" Text="GIRIS YAP" class="btn btn-submit" onclick="girisBTN_Click" ValidationGroup="girisFormu" />
                            </div>
                    </div> 
                    </div>
                    <div style="margin-top:-20px;">
                        <img src="images/slider/xbox.png" class="slider-hill" alt="slider image">
                        <img src="images/slider/tv.png" class="slider-house" alt="slider image">
                        <img src="images/slider/spor.png" class="slider-sun" alt="slider image">
                        <img src="images/slider/english.png" class="slider-birds1" alt="slider image">
                        <img src="images/slider/ok1.png" class="slider-birds2" alt="slider image">
                        <img src="images/slider/ok2.png" class="slider-birds3" alt="slider image">
                        <img src="images/slider/ok3.png" class="slider-birds4" alt="slider image">
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!--/#home-slider-->
    
    <section id="services">
        <div class="container">
            <div class="row">
                <div class="col-sm-4 text-center padding wow fadeIn" data-wow-duration="1000ms" data-wow-delay="300ms">
                    <div class="single-service">
                        <div class="wow scaleIn" data-wow-duration="500ms" data-wow-delay="300ms">
                            <img src="images/icon_hakkinda.png" alt="">
                        </div>
                        <h2>PROJE HAKKINDA</h2>
                        <asp:Label ID="hakkindaTXT" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="col-sm-4 text-center padding wow fadeIn" data-wow-duration="1000ms" data-wow-delay="600ms">
                    <div class="single-service">
                        <div class="wow scaleIn" data-wow-duration="500ms" data-wow-delay="600ms">
                            <img src="images/icon_ekip.png" alt="">
                        </div>
                        <h2>PROJE EKİBİ</h2>
                        <asp:Label ID="ekipTXT" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="col-sm-4 text-center padding wow fadeIn" data-wow-duration="1000ms" data-wow-delay="900ms">
                    <div class="single-service">
                        <div class="wow scaleIn" data-wow-duration="500ms" data-wow-delay="900ms">
                            <img src="images/icon_yayinlar.png" alt="">
                        </div>
                        <h2>YAYINLAR</h2>
                        <asp:Label ID="yayinlarTXT" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!--/#services-->


    <footer id="footer">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div class="copyright-text text-center">
                        <p style="color:#025; text-align:center;">2016 &copy;  Tüm hakları saklıdır.  </p>
                    </div>
                </div>
            </div>
        </div>
    </footer>
    <!--/#footer-->
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/wow.min.js"></script>
    <script type="text/javascript" src="js/main.js"></script>                      
    </form>
</body>
</html>

