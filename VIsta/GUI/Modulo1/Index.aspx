<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="templateApp.GUI.Modulo1.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head id="Head1" runat="server">
      <meta http-equiv="content-type" content="text/html; charset=UTF-8"/>
      <meta charset="utf-8"/>
      <title>SAKARATEDO - Inicio de Sesión</title>
      <meta name="generator" content="Bootply" />
      <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>
      <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
      <!--[if lt IE 9]>
      <script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script>
      <![endif]-->
      <link href="css/styles.css" rel="stylesheet" />
   </head>
   <body >
      <!--login-->
      <div class="container">
         <div class="row" id="pwd-container">
            <div class="col-md-4"></div>
            <div class="col-md-4">
               <section class="login-form">
                  <form  method="post" action="#" role="login" id="loginUser" runat="server">
                     <img src="../../dist/img/logofinal.png" class="img-responsive" alt=""/>
                     <div>
                        <h1 >SA-KARATEDO</h1>
                     </div>

                       <div class="alert alert-danger" id="errorLogin" runat="server">
                       </div>
                       <div class="alert alert-warning" id="warningLog" runat="server">
                       </div>
                      <div class="alert alert-info" id="infoLog" runat="server">
                       </div>
                       <div class="alert alert-success" id="successLog" runat="server">
                       </div>

                     <input type="text" id="userIni" maxlength="254" placeholder="Usuario" runat="server" class="form-control input-lg"  />         
                     <input type="password" maxlength="30" class="form-control input-lg" id="passwordIni" runat="server"  placeholder="Contraseña"/>                    
                     <div class="pwstrength_viewport_progress"></div>
                     <button type="button"  id="LoginButton" runat="server" name="go" class="btn btn-lg btn-primary btn-block" onserverclick="ValidarUsuario">Entrar</button>
                     <div>
                        <a data-toggle="modal" data-target="#modalform" href="#" >¿Olvidaste tu contraseña?</a>
                     </div>
                     <div class="modal fade" id="modalform"  tabindex="-1" role="dialog" aria-labelledby="ModalLabel" aria-hidden="true">
                        <div id="modalid" class="modal-dialog">
                           <div class="modal-content" id="ModalCont">
                              <div class="modal-header">
                                 <button type="button" class="close icon-white" id="closeModal" data-dismiss="modal" aria-hidden="true" >&times;</button>
                                 <h3>Restablecer contraseña</h3>
                              </div>
                                  <div class="modal-body">
                                     <p>Introduzca el correo asociado a su cuenta, de no conocerlo contacte a su dojo</p>
                                      <div id="mail" class="form-group">
                                        <input type="email" name="correo" id="RestablecerCorreo" runat="server" placeholder="Correo" class="form-control input-lg" value="" />   
                                        <span class="glyphicon glyphicon-ok form-control-feedback" ></span>
                                      </div>      
                                  </div>
                                  <div class="modal-footer">
                                   <button type="button"  id="restab" runat="server"  class="btn btn-lg btn-primary btn-block"  data-dismiss="modal"  
                                    onserverclick="EnvioCorreo" attr="disabled">Restablecer</button>
                                      
                                     <!--  <asp:Button runat="server"  Text="Save Image" CssClass="Greengradiant btn- large" OnClick="EnvioCorreo" UseSubmitBehavior="false" data-dismiss="modal" />
-->
                                  </div>
                           </div>
                        </div>
                     </div>
                  </form>
                  <div class="form-links">
                        <a href="<%=Page.ResolveUrl("~/GUI/Modulo6/M6_SolicitudInscripcionPre.aspx") %>">
                            <strong>
                                   Si desea solicitar inscripción a un dojo, click aquí
                            </strong>
                        </a>
                    
                         <a>Copyright © 2015-2016 SA-Karatedo.</a>
                  </div>
                </section>
            </div>
            <div class="col-md-4"></div>
         </div>
      </div>
      <!-- script references -->
      <script src="//ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js"></script>
      <script src="../../bootstrap/js/bootstrap.min.js"></script>
       <script src="js/ValidarCorreo.js"></script>
       <script src="js/Login.js"></script>
   </body>
</html>
