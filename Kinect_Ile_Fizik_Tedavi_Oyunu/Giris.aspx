<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Giris.aspx.cs" Inherits="Giris" %>

<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
	<title>Kinect ile Fizik Tedavi Oyunu</title>
	<meta name="viewport" content="width=device-width, initial-scale=1">

	<link rel="shortcut icon" href="favicon.ico">
	<link rel="stylesheet" href="~/css/font1.css">
	<link rel="stylesheet" href="~/css/animate.css">
	<link rel="stylesheet" href="~/css/icomoon.css">
	<link rel="stylesheet" href="~/css/simple-line-icons.css">
	<link rel="stylesheet" href="~/css/magnific-popup.css">
	<link rel="stylesheet" href="~/css/bootstrap.css">
	<link rel="stylesheet" href="~/css/style.css">
	<!-- Modernizr JS -->
	<script src="js/modernizr-2.6.2.min.js"></script>
	<!-- FOR IE9 below -->
	<!--[if lt IE 9]>
	<script src="js/respond.min.js"></script>
	<![endif]-->

    <script src="js/jquery-2.0.3.min.js" type="text/javascript"></script>
    <script src="js/notifIt.js" type="text/javascript"></script>
    <link href="css/notifIt.css" type="text/css" rel="stylesheet">

	<meta charset="iso-8859-9">
</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal runat="server" ID="mesajTXT" />
        <header role="banner" id="fh5co-header">
		    <div class="container">
			    <!-- <div class="row"> -->
			        <nav class="navbar navbar-default">
		            <div class="navbar-header">
		        	    <!-- Mobile Toggle Menu Button -->
					    <a href="#" class="js-fh5co-nav-toggle fh5co-nav-toggle" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar"><i></i></a>
		                <span class="navbar-brand">Kinect ile Fizik Tedavi Oyunu</span> 
		            </div>
		            <div id="navbar" class="navbar-collapse collapse">
		              <ul class="nav navbar-nav navbar-right">
		                <li class="active"><a href="#" data-nav-section="home"><span>Anasayfa</span></a></li>
		                <li><a href="#" data-nav-section="giris"><span>Üye Girişi</span></a></li>
		                <li><a href="#" data-nav-section="hakkinda"><span>Proje Hakında</span></a></li>
		                <li><a href="#" data-nav-section="ekip"><span>Proje Ekibi</span></a></li>
		              </ul>
		            </div>
			        </nav>
			    <!-- </div> -->
		    </div>
	    </header>
	    <section id="fh5co-home" data-section="home" style="background-image: url(images/full_image_2.jpg);" data-stellar-background-ratio="0.5">
		    <div class="gradient"></div>
		    <div class="container">
			    <div class="text-wrap">
				    <div class="text-inner">
					    <div class="row">
						    <div class="col-md-8 col-md-offset-2">
                        	    <img src="images/logo.png" style="margin-top:-180px;"><br>
							    <h1 class="to-animate">Kinect İle Fizik Tedavi Oyunu<br> yönetim portalına hoşgeldiniz.</h1>
                                <hr>
							    <h2 class="to-animate">Fizyoterapist ve hastalarımız giriş panelini kullanarak sisteme giriş yapabilirler.</h2>
						    </div>
					    </div>
				    </div>
			    </div>
		    </div>
		    <div class="slant" data-section="giris"></div>
	    </section>

	    <section id="fh5co-intro" style="margin-top:120px;">
		    <div class="container">
			    <div class="row watch-video text-center to-animate">
            	    <div class="col-md-3 to-animate"></div>
				    <div class="col-md-6 to-animate">
                        <div class="col-md-12 section-heading text-center" style="height:80px;">
					        <h2 class="to-animate">ÜYE GİRİŞİ</h2>
				        </div>
					    <div class="form-group">
                            <asp:TextBox ID="kadiTXT" class="form-control" placeholder="Kullanıcı Adı" style="text-align:center;" runat="server"></asp:TextBox>
					    </div>
					    <div class="form-group ">
                            <asp:TextBox ID="sifreTXT" class="form-control" placeholder="Şifre" style="text-align:center;" runat="server" TextMode="Password"></asp:TextBox>
					    </div>
					    <div class="form-group ">
                            <asp:Button ID="girisYapBTN" class="btn btn-primary btn-lg" runat="server" Text="GİRİŞ YAP" OnClick="girisYapBTN_Click" />
					    </div>
					    </div>
            	    <div class="col-md-3 to-animate"></div>
			    </div>
		    </div>
	    </section>
	    <section id="fh5co-services" data-section="hakkinda">
		    <div class="container">
			    <div class="row" style="height:auto; padding:0;">
				    <div class="col-md-12 section-heading text-left" style="height:70px;">
					    <h2 class=" left-border to-animate">PROJE HAKKINDA</h2>
				    </div>
			    </div>
			    <div class="row">
            
				    <div class="col-md-6 col-sm-6 fh5co-service to-animate" style="text-align:justify;">
					    <p>Fizyoterapi ve Rehabilitasyon çocuk, genç, yetişkin veya yaşlı, sağlıklı, hasta ve engellilere tedavi amacıyla uygulanan, bu kişilerin yaşam kalitelerinin artırılmasında uygulanan fonksiyonel aktivite eğitiminin yanı sıra çok sayıda tedavi yaklaşımının uygulanmasını kapsayan ve sorunlara çözüm getiren bir bilimdir (Algun, 2013). Bu yazılım çalışmasının amacı, fizik tedavi ve rehabilitasyona ihtiyaç duyan her yaştan bireye üç boyutlu interaktif bir ortamda, doktor tarafından, hasta bazlı hazırlanabilen egzersiz programları ile hastaların evde veya hastanelerde kendi başlarına yaptıkları egzersizleri doktor kontrolünde tutmak, bu egzersizlerin hastaya hatasız ve eğlenceli bir şekilde yaptırılmasını sağlamaktır.</p>
				    </div>
                
				    <div class="col-md-6 col-sm-6 fh5co-service to-animate">
					    <img src="images/F1.jpg" style="width:100%;"></div>
				    </div>

				    <div class="clearfix visible-sm-block"></div>
				
			    </div>
		    </div>
	    </section>
	    <section id="fh5co-about" data-section="ekip">
		    <div class="container">
			    <div class="row">
				    <div class="col-md-12 section-heading text-center">
					    <h2 class="to-animate">PROJE EKİBİ</h2>
				    </div>
			    </div>
			    <div class="row">
                <div class="col-md-2"></div>
				    <div class="col-md-4">
					    <div class="fh5co-person text-center to-animate">
						    <figure><img src="images/person3.png" alt="Image"></figure>
						    <h3>Anıl Batu Han ÜNVER</h3>
						    <span class="fh5co-position">Proje Yürütücüsü</span>
						    <p>Kırıkkale Üniversitesi<br> Bilgisayar ve Öğretim Teknolojileri Eğitimi<br> Lisans Öğrencisi</p>
						    <ul class="social social-circle">
							    <li><a href="#"><i class="icon-twitter"></i></a></li>
							    <li><a href="#"><i class="icon-facebook"></i></a></li>
							    <li><a href="#"><i class="icon-dribbble"></i></a></li>
						    </ul>
					    </div>
				    </div>
				    <div class="col-md-4">
					    <div class="fh5co-person text-center to-animate">
						    <figure><img src="images/person3.png" alt="Image"></figure>
						    <h3>Doç. Dr. Erman YÜKSELTÜRK</h3>
						    <span class="fh5co-position">Proje Danışmanı</span>
						    <p>Kırıkkale Üniversitesi<br> Bilgisayar ve Öğretim Teknolojileri Eğitimi<br> Bölüm Başkanı</p>
						    <ul class="social social-circle">
							    <li><a href="#"><i class="icon-twitter"></i></a></li>
							    <li><a href="#"><i class="icon-facebook"></i></a></li>
							    <li><a href="#"><i class="icon-dribbble"></i></a></li>
						    </ul>
					    </div>
				    </div>
                    <div class="col-md-2"></div>
			    </div>
		    </div>
	    </section>
        <!--Proje Ekibi Bitimi-->
	    <footer id="footer" role="contentinfo">
		    <a href="#" class="gotop js-gotop"><i class="icon-arrow-up2"></i></a>
            <div class="clear">&nbsp;</div>
            <div style="width:100%; max-width:950px; margin:auto; font-size:17px; text-align:center;">
        	    1139B421700278 nolu yazılım projesi, <strong>TUBİTAK 2242 - Üniversite Öğrencileri Yazılım Projeleri Yarışması</strong> tarafından desteklenmektir.<br>
                2017 © Tüm hakları Kırıkkale Üniversitesi Bilgisayar ve Öğretim Teknolojileri Eğitimi Bölümüne aittir.

            </div>
	    </footer>
	<!-- jQuery -->
	<script src="js/jquery.min.js"></script>
	<!-- jQuery Easing -->
	<script src="js/jquery.easing.1.3.js"></script>
	<!-- Bootstrap -->
	<script src="js/bootstrap.min.js"></script>
	<!-- Waypoints -->
	<script src="js/jquery.waypoints.min.js"></script>
	<!-- Stellar Parallax -->
	<script src="js/jquery.stellar.min.js"></script>
	<!-- Counter -->
	<script src="js/jquery.countTo.js"></script>
	<!-- Magnific Popup -->
	<script src="js/jquery.magnific-popup.min.js"></script>
	<script src="js/magnific-popup-options.js"></script>
	<!-- Google Map -->
	<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCefOgb1ZWqYtj7raVSmN4PL2WkTrc-KyA&sensor=false"></script>
	<script src="js/google_map.js"></script>

	<!-- For demo purposes only styleswitcher ( You may delete this anytime ) -->
	<script src="js/jquery.style.switcher.js"></script>
	<script>
		$(function(){
			$('#colour-variations ul').styleSwitcher({
				defaultThemeId: 'theme-switch',
				hasPreview: false,
				cookie: {
		          	expires: 30,
		          	isManagingLoad: true
		      	}
			});	
			$('.option-toggle').click(function() {
				$('#colour-variations').toggleClass('sleep');
			});
		});
	</script>
	<!-- End demo purposes only -->

	<!-- Main JS (Do not remove) -->
	<script src="js/main.js"></script>
    </form>
</body>
</html>
