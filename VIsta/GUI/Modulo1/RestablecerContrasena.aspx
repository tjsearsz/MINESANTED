<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RestablecerContrasena.aspx.cs" Inherits="templateApp.GUI.Modulo1.RestablecerContraseña" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head id="Head1" runat="server">
      <meta http-equiv="content-type" content="text/html; charset=UTF-8"/>
      <meta charset="utf-8"/>
      <title>SKD - Restablecer Contrasena</title>
      <meta name="generator" content="Bootply" />
      <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>
      <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
      <!--[if lt IE 9]>
      <script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script>
      <![endif]-->
      <link href="css/styles.css" rel="stylesheet" />
   </head>
   <body>
      <div class="container">
         <div class="row" id="pwd-container">
            <div class="col-md-4"></div>
            <div class="col-md-4">
               <section class="login-form">
                  <form  method="post" role="login" id="loginUser" runat="server" >
                                
                      <div>         
                            <img src="../../dist/img/logofinal.png" class="img-responsive" alt=""/>
                      
                            <h3>Restablecer Contraseña</h3>
                      </div>
                      <div class="alert alert-warning" id="warningCaracteres" runat="server" visible="false">

                      </div>
                        <div class="alert alert-info" id="infoRestablecer" runat="server">
                                La contraseña debe poseer de <strong>8-30 caracteres</strong> e incluir al menos <strong>una letra mayúscula </strong> ,
                         <strong> una letra minúscula</strong> y <strong>un número.</strong>
                       </div>
                      
                    <hr />
                      <div id="p1" class="form-group">
                      <input runat="server" type="password"  maxlength="30" class="input-lg form-control" name="password1"  id="password3" placeholder="Contraseña nueva"  />
                          <span class="glyphicon glyphicon-ok form-control-feedback" ></span>
                      </div>
                      <div id="p2" class="form-group">
                     <input type="password" class="form-control input-lg" maxlength="30" name="password2" id="password4" runat="server"  placeholder="Repetir Contraseña" />
                        <span class="glyphicon glyphicon-ok form-control-feedback" ></span>
                      </div>
                     <div class="pwstrength_viewport_progress"></div>
                     <button id="Button1" type="submit" name="go" class="btn btn-lg btn-primary btn-block"  runat="server" onServerClick="redireccionarInicio" disabled><span class="glyphicon glyphicon-refresh" aria-hidden="true"   > Restablecer </span></button>
                    </form>  
                </section>
            </div>
            <div class="col-md-4"></div>
         </div>
      </div>
      <!-- script references -->
      <script src="//ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js"></script>
      <script src="../../bootstrap/js/bootstrap.min.js"></script>
      <script src="js/RestablecerContraseña.js"></script>
   </body>
</html>