<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Galeri.aspx.cs" Inherits="Galeri" %>

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
	<link href="css/main.css" rel="stylesheet">  

        <!-- Load player theme -->
        <link rel="stylesheet" href="~/css/themes/maccaco/projekktor.style.css" type="text/css" media="screen" />

        <!-- Load jquery -->
        <script type="text/javascript" src="../../js/jquery-1.9.1.min.js"></script>

        <!-- load projekktor -->
        <script type="text/javascript" src="../../js/projekktor-1.3.09.min.js"></script>
    
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <link rel="stylesheet" href="css/lightbox.css" type="text/css" media="all" />
    <link href="css/galeri.css" rel="stylesheet" type="text/css" media="all" />
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
    
    
    <section id="services">
        <div class="container">
            <div class="row" style="padding-top:20px; padding-bottom:20px;">
                <div style="margin:auto; width:992px;">
                <script src="js/lightbox.js"></script>
                    <span class="active total" style="display:block;">
    	                <strong>Derslerden Video Görüntüleri</strong>
	                </span>
                    <div id="player_a" class="projekktor"></div>

                    <script type="text/javascript">
                        $(document).ready(function () {
                            projekktor('#player_a', {
                                poster: 'images/videoBG.jpg',
                                title: 'this is projekktor',
                                playerFlashMP4: 'video/swf/StrobeMediaPlayback/StrobeMediaPlayback.swf',
                                playerFlashMP3: 'video/swf/StrobeMediaPlayback/StrobeMediaPlayback.swf',
                                width: 992,
                                height: 558,
                                playlist: [
                                    {
                                        0: { src: "video/etkinlikler.mp4", type: "video/mp4" }
                                    }
                                ]
                            }, function (player) { } // on ready 
                            );
                        });
                    </script>

	                <span class="active total" style="display:block;">
    	                <strong>Derslerden Görüntüler</strong>
	                </span>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/Dersler/1.jpg' data-lightbox="example-1" data-title='Derslerden Görüntüler'>
                            <img src='images/galeri/Dersler/1.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/Dersler/2.jpg' data-lightbox="example-1" data-title='Derslerden Görüntüler'>
                            <img src='images/galeri/Dersler/2.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/Dersler/3.jpg' data-lightbox="example-1" data-title='Derslerden Görüntüler'>
                            <img src='images/galeri/Dersler/3.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/Dersler/4.jpg' data-lightbox="example-1" data-title='Derslerden Görüntüler'>
                            <img src='images/galeri/Dersler/4.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/Dersler/5.jpg' data-lightbox="example-1" data-title='Derslerden Görüntüler'>
                            <img src='images/galeri/Dersler/5.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/Dersler/6.jpg' data-lightbox="example-1" data-title='Derslerden Görüntüler'>
                            <img src='images/galeri/Dersler/6.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/Dersler/7.jpg' data-lightbox="example-1" data-title='Derslerden Görüntüler'>
                            <img src='images/galeri/Dersler/7.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/Dersler/8.jpg' data-lightbox="example-1" data-title='Derslerden Görüntüler'>
                            <img src='images/galeri/Dersler/8.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/Dersler/9.jpg' data-lightbox="example-1" data-title='Derslerden Görüntüler'>
                            <img src='images/galeri/Dersler/9.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/Dersler/10.jpg' data-lightbox="example-1" data-title='Derslerden Görüntüler'>
                            <img src='images/galeri/Dersler/10.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/Dersler/11.jpg' data-lightbox="example-1" data-title='Derslerden Görüntüler'>
                            <img src='images/galeri/Dersler/11.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/Dersler/12.jpg' data-lightbox="example-1" data-title='Derslerden Görüntüler'>
                            <img src='images/galeri/Dersler/12.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
                <div class="clearfix"> </div>
                    <span class="active total" style="display:block;">
    	                <strong>Oyun 1</strong>
	                </span>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O1/0.jpg' data-lightbox="example-1" data-title='Oyun 1'>
                            <img src='images/galeri/O1/0.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O1/1.jpg' data-lightbox="example-1" data-title='Oyun 1'>
                            <img src='images/galeri/O1/1.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O1/2.jpg' data-lightbox="example-1" data-title='Oyun 1'>
                            <img src='images/galeri/O1/2.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O1/3.jpg' data-lightbox="example-1" data-title='Oyun 1'>
                            <img src='images/galeri/O1/3.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O1/4.jpg' data-lightbox="example-1" data-title='Oyun 1'>
                            <img src='images/galeri/O1/4.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O1/5.jpg' data-lightbox="example-1" data-title='Oyun 1'>
                            <img src='images/galeri/O1/5.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O1/6.jpg' data-lightbox="example-1" data-title='Oyun 1'>
                            <img src='images/galeri/O1/6.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O1/7.jpg' data-lightbox="example-1" data-title='Oyun 1'>
                            <img src='images/galeri/O1/7.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O1/8.jpg' data-lightbox="example-1" data-title='Oyun 1'>
                            <img src='images/galeri/O1/8.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
                <div class="clearfix"> </div>
                    <span class="active total" style="display:block;">
    	                <strong>Oyun 2</strong>
	                </span>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O1/0.jpg' data-lightbox="example-1" data-title='Oyun 2'>
                            <img src='images/galeri/O1/0.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O2/1.jpg' data-lightbox="example-1" data-title='Oyun 2'>
                            <img src='images/galeri/O2/1.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O2/2.jpg' data-lightbox="example-1" data-title='Oyun 2'>
                            <img src='images/galeri/O2/2.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O2/3.jpg' data-lightbox="example-1" data-title='Oyun 2'>
                            <img src='images/galeri/O2/3.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O2/4.jpg' data-lightbox="example-1" data-title='Oyun 2'>
                            <img src='images/galeri/O2/4.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O2/5.jpg' data-lightbox="example-1" data-title='Oyun 2'>
                            <img src='images/galeri/O2/5.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O2/6.jpg' data-lightbox="example-1" data-title='Oyun 2'>
                            <img src='images/galeri/O2/6.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O2/7.jpg' data-lightbox="example-1" data-title='Oyun 2'>
                            <img src='images/galeri/O2/7.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O2/8.jpg' data-lightbox="example-1" data-title='Oyun 2'>
                            <img src='images/galeri/O2/8.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O2/9.jpg' data-lightbox="example-1" data-title='Oyun 2'>
                            <img src='images/galeri/O2/9.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O2/10.jpg' data-lightbox="example-1" data-title='Oyun 2'>
                            <img src='images/galeri/O2/10.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
                <div class="clearfix"> </div>
                    <span class="active total" style="display:block;">
    	                <strong>Oyun 3</strong>
	                </span>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O1/0.jpg' data-lightbox="example-1" data-title='Oyun 3'>
                            <img src='images/galeri/O1/0.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O3/1.jpg' data-lightbox="example-1" data-title='Oyun 3'>
                            <img src='images/galeri/O3/1.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O3/2.jpg' data-lightbox="example-1" data-title='Oyun 3'>
                            <img src='images/galeri/O3/2.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O3/3.jpg' data-lightbox="example-1" data-title='Oyun 3'>
                            <img src='images/galeri/O3/3.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O3/4.jpg' data-lightbox="example-1" data-title='Oyun 3'>
                            <img src='images/galeri/O3/4.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O3/5.jpg' data-lightbox="example-1" data-title='Oyun 3'>
                            <img src='images/galeri/O3/5.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O3/6.jpg' data-lightbox="example-1" data-title='Oyun 3'>
                            <img src='images/galeri/O3/6.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O3/7.jpg' data-lightbox="example-1" data-title='Oyun 3'>
                            <img src='images/galeri/O3/7.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O3/8.jpg' data-lightbox="example-1" data-title='Oyun 3'>
                            <img src='images/galeri/O3/8.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O3/9.jpg' data-lightbox="example-1" data-title='Oyun 3'>
                            <img src='images/galeri/O3/9.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/O3/10.jpg' data-lightbox="example-1" data-title='Oyun 3'>
                            <img src='images/galeri/O3/10.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
                <div class="clearfix"> </div>
                    <span class="active total" style="display:block;">
    	                <strong>WEB Sayfasından Görüntüler</strong>
	                </span>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/WEB/1.jpg' data-lightbox="example-1" data-title='Default Page'>
                            <img src='images/galeri/WEB/1.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/WEB/2.jpg' data-lightbox="example-1" data-title='Eğitmen Kayıt'>
                            <img src='images/galeri/WEB/2.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/WEB/3.jpg' data-lightbox="example-1" data-title='Öğrenci ve Grup İşlemleri'>
                            <img src='images/galeri/WEB/3.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/WEB/4.jpg' data-lightbox="example-1" data-title='Öğrenci ve Grup İşlemleri'>
                            <img src='images/galeri/WEB/4.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/WEB/5.jpg' data-lightbox="example-1" data-title='Öğrenci ve Grup İşlemleri'>
                            <img src='images/galeri/WEB/5.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/WEB/6.jpg' data-lightbox="example-1" data-title='Öğrenci ve Grup İşlemleri'>
                            <img src='images/galeri/WEB/6.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/WEB/7.jpg' data-lightbox="example-1" data-title='Öğrenci Bilgileri'>
                            <img src='images/galeri/WEB/7.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/WEB/8.jpg' data-lightbox="example-1" data-title='Öğrenci Bilgileri'>
                            <img src='images/galeri/WEB/8.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/WEB/9.jpg' data-lightbox="example-1" data-title='Öğrenci Bilgileri'>
                            <img src='images/galeri/WEB/9.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/WEB/10.jpg' data-lightbox="example-1" data-title='Öğrenci Bilgileri'>
                            <img src='images/galeri/WEB/10.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/WEB/11.jpg' data-lightbox="example-1" data-title='Proje Bilgi Sayfası'>
                            <img src='images/galeri/WEB/11.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/WEB/12.jpg' data-lightbox="example-1" data-title='Proje Bilgi Sayfası'>
                            <img src='images/galeri/WEB/12.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/WEB/13.jpg' data-lightbox="example-1" data-title='Proje Bilgi Sayfası'>
                            <img src='images/galeri/WEB/13.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/WEB/14.jpg' data-lightbox="example-1" data-title='Video ve Değerlendirmeler'>
                            <img src='images/galeri/WEB/14.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/WEB/15.jpg' data-lightbox="example-1" data-title='Video ve Değerlendirmeler'>
                            <img src='images/galeri/WEB/15.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/WEB/16.jpg' data-lightbox="example-1" data-title='Video ve Değerlendirmeler'>
                            <img src='images/galeri/WEB/16.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
	                </div>
	                <div class="gallery-img">
		                <a class="example-image-link b-link-stripe b-animate-go" href='images/galeri/WEB/17.jpg' data-lightbox="example-1" data-title='Video ve Değerlendirmeler'>
                            <img src='images/galeri/WEB/17.jpg' alt=" " class="img-responsive" />
                            <span class="zoom-icon"> </span> 
		                </a>
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
    </form>
</body>
</html>

