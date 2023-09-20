﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EtkinlikProgrami.aspx.cs" Inherits="inc_EtkinlikProgrami" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--=========== Yayınlar Başı =========-->

    <section id="service">
      <div class="container">
        <div class="row">
          <div class="col-lg-12 col-md-12">
            <div class="service-area">
              <!-- Start Service Title -->
              <div class="section-heading">
                <h2>ETKİNLİK PROGRAMI</h2>
                <div class="line" style="margin-top: 0;margin-bottom: 30px;"></div>
              </div>
              <!-- Start Service Content -->
              <div class="service-content">
                <div class="row">
                  <div class="col-lg-4 col-md-4">
                    <div class="single-service">
                        <asp:Repeater ID="rptsayfa" runat="server">
                            <ItemTemplate>
                                <%#Eval("etkinlikProgrami") %>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
    <!--=========== Yayınlar Sonu =========-->
</asp:Content>

