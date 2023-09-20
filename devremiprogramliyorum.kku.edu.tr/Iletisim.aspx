<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Iletisim.aspx.cs" Inherits="Iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--=========== İletişim Başı ================--> 
    
    <section id="contact">
      <div class="container">
        <div class="row">
          <div class="col-lg-7 col-md-7 col-sm-6">
        	<div class="section-heading">
                <h2 style="font-size:22px;">İLETİŞİM FORMU</h2>
                <div class="line"></div>
              </div>
            <div class="contact-form">
                <asp:TextBox ID="adSoyadTXT" class="wp-form-control wpcf7-text" placeholder="Adınızı yazınız." runat="server"></asp:TextBox>
                <asp:TextBox ID="ePostaTXT" class="wp-form-control wpcf7-email" placeholder="E-Posta adresini yazınız." runat="server"></asp:TextBox>
                <asp:TextBox ID="konuTXT" class="wp-form-control wpcf7-text" placeholder="Konu başlığını yazınız." runat="server"></asp:TextBox>
                <asp:TextBox ID="mesajTXT" class="wp-form-control wpcf7-textarea" placeholder="Mesajınızı yazınız." runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:Button ID="mesajGonderBTN" class="wpcf7-submit button--itzel" runat="server" Text="Mesaj Gönder" OnClick="mesajGonderBTN_Click" />          
              </form>
            </div>
          </div>
          <div class="col-lg-5 col-md-5 col-sm-6">
            <div class="contact-address">
              <div class="section-heading">
                <h2 style="font-size:22px;">İLETİŞİM BİLGİLERİ</h2>
                <div class="line"></div>
              </div>
              <asp:Repeater ID="rptsayfa" runat="server">
                <ItemTemplate>
                    <%#Eval("iletisim") %>
                </ItemTemplate>
              </asp:Repeater>
            </div>
          </div>
        </div>
      </div>
    </section>
    
    <!--===== İletişim Sonu =====-->
</asp:Content>

