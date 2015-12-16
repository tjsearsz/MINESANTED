<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="templateApp.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Seccion de Inicio</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoCentral" runat="server">
    
    <div id="alert" runat="server">
    </div>
           <div class="intro">
        <div class="intro-body">
            <div class="container">
                <div class="row">
                    <div class="col-md-8 col-md-offset-2">
                        <h1 class="brand-heading">SA-KARATEDO</h1>
                        <p class="intro-text">Bienvenido a tu cuenta de SA-Karatedo<br></p>
                        <p class="Contenido">El Karate-Do (“Camino de la mano vacía”, Kara: Vacía, Te: mano, Do: Camino.) es un arte marcial tradicional originario de la Isla de Okinawa, conocida como islas RyuKyu de Japón. Este deporte es practicado en todo el mundo y está dirigido por la Federación Mundial de Karate (WKF, World Karate Federation).</p>
                      
                    </div>
                </div>
            </div>
        </div>
    </div>
          <div class="logoFederacion">
              <a href="http://www.wkf.net/"><img src="../../dist/img/logo-wkf.png"  alt="WKF"  longdesc="Federacion Mundial de Karate" height:"110" width="150"/></a>
          </div>

    

</asp:Content>