﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Yonetim.master" AutoEventWireup="true" CodeFile="Ekip.aspx.cs" Inherits="Yonetim_inc_Ekip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section id="main-content">
        <section class="wrapper site-min-height">
            <table style="width:100%;" border="0">
                <tr>
                    <td><h3><i class="fa fa-angle-right"></i> Proje Ekibi</h3></td>
                    <td style="text-align:right;">
                        <asp:Button ID="kaydetBTN" class="btn btn-success" runat="server" Text="Güncelle" OnClick="kaydetBTN_Click" />
                    </td>
                </tr>
            </table>
            
          	<div class="row mt">
          	    <div class="col-lg-12">
          		    <textarea id="projeEkibiTXT" name="hakkinda" class="ckeditor" runat="server"></textarea>
          		</div>
          	</div>
		 </section>
    </section>
</asp:Content>

