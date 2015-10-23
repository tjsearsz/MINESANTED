<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M16_VerCarrito.aspx.cs" Inherits="templateApp.GUI.Modulo16.M16_VerCarrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server"> Carrito 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server"> Productos que posees:
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

     <div id="alert" runat="server">
    </div>
    
<!--MODAL PARA EL DETALLE-->
     <!-- general form elements -->
    <form runat="server" class="form-horizontal" method="POST">
              
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Subtotal 23.300 Bs.</h3>
                </div><!-- /.box-header -->
        <table id="example" class="table table-bordered table-striped dataTable">
        <thead>
            <tr>
                <th>Foto</th>
                <th>Producto</th>
                <th>Cantidad</th>
                <th>Precio (Bs.)</th>
                <th>Acciones</th>
            </tr>
        </thead>
 
        <tfoot>
            <tr>
                <th>Foto</th>
                <th>Producto</th>
                <th>Cantidad</th>
                <th>Precio (Bs.)</th>
                <th>Acciones</th>
            </tr>
        </tfoot>
<!--INFORMACION DEL MODAL PARA EL DETALLE-->
        <tbody>
           
            <tr>
                <td><img src="Imagenes/CintaBlanca.jpg" alt="" style="width:50px; height:auto;"></td>
                <td>Cinta Blanca</td>
                <td>
                     
                                 <div class="dropdown" runat="server" id="div3">
                                 <asp:DropDownList ID="DropDownList3"   class="btn btn-default dropdown-toggle"  runat="server" >
                                     
                                     <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                     <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                     <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                     <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                 </asp:DropDownList>
                                 </div> 
                                
                </td>
                <td>400</td>
                <td>
                    <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a>
                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                </td>
            </tr>
            <tr>
                <td><img src="Imagenes/Karategi.jpg" alt="" style="width:50px; height:auto;"></td>
                <td>Karategi</td>
                <td>
                     
                                 <div class="dropdown" runat="server" id="div4">
                                 <asp:DropDownList ID="DropDownList4"   class="btn btn-default dropdown-toggle"  runat="server" >
                                     
                                     <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                     <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                     <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                     <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                 </asp:DropDownList>
                                 </div> 
                                

                </td>
                <td>14000</td>
                 <td>
                     <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a>
                     <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                </td>
            </tr>
            <tr>
                <td><img src="Imagenes/Suspensorio.jpg" alt="" style="width:50px; height:auto;"></td>
                <td>Suspensorio</td>
                <td>
                    
                                 <div class="dropdown" runat="server" id="div5">
                                 <asp:DropDownList ID="DropDownList5"   class="btn btn-default dropdown-toggle"  runat="server" >
                                    
                                     <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                     <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                     <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                     <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                 </asp:DropDownList>
                                 </div> 
                        

                </td>
                <td>350</td>
                <td> 
                    <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a>
                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                </td>
            </tr>
             <tr>
                <td><img src="Imagenes/ProtectorBucal.jpg" alt="" style="width:50px; height:auto;"></td>
                <td>Proteccion bucal</td>
                <td>
                     <div class="dropdown" runat="server" id="div6">
                                 <asp:DropDownList ID="DropDownList6"   class="btn btn-default dropdown-toggle"  runat="server" >
                                     
                                     <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                     <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                     <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                     <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                 </asp:DropDownList>
                                 </div> 

                </td>
                <td>3200</td>
                <td>
                    <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a>
                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                </td>
            </tr>
            <tr>
                <td><img src="Imagenes/GuanteRojo.jpg" alt="" style="width:50px; height:auto;"></td>
                <td>Guantes rojos</td>
                <td>
                     <div class="dropdown" runat="server" id="div7">
                                 <asp:DropDownList ID="DropDownList7"   class="btn btn-default dropdown-toggle"  runat="server" >
                                    
                                     <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                     <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                     <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                     <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                 </asp:DropDownList>
                                 </div> 

                </td>
                <td>5000</td>
                <td>
                    <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"> </a>
                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                </td>
            </tr>
            
        </tbody>
    </table>

         <div id="modal-delete" class="modal" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Eliminar Producto</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>Seguro que desea eliminar el Producto:</p>
                    <p id="req"></p>
                </div>
              </div>
            </div>
            <div class="modal-footer">
                    <a id="btn-eliminar" type="button" class="btn btn-primary" href="#">Eliminar</a>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
           </div>
          </div><!-- /.modal-delete-content -->
        </div><!-- /.modal-delete-dialog -->
      </div><!-- /.modal-delete -->

    		<div id="modal-info1" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h2 class="modal-title">Información detallada del Producto</h2>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info1">
							<div class="row">
                                <img src="Imagenes/GuanteRojo.jpg" alt="">
								<h3>Nombre</h3>
								<p>
									Guantes Rojos
								</p>
								<h3>Cantidad disponible</h3>
								<p>
									7
								</p>
								<h3>Detalles</h3>
								<p>
									Guantes de color rojos diseñados para proteger las manos al momento de impactar
                                    golpes contra el contrincante o cuando se está practicando, con un diseño
                                    particular de color rojo a gusto del atleta.
								</p>
								
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
    </div>



<!--MODAL DE PAGO-->
    <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
         <button id="btn-agregarComp" style="align-content:flex-end" class="btn btn-primary" type="submit" data-toggle="modal" data-target="#modal-info"">Pagar</button>
          &nbsp;&nbsp
         <a class="btn btn-default" href="M12_ListarCompetencias.aspx">Cancelar</a>
    </div>

   <div id="modal-info" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h4 class="modal-title">Registrar Pago</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							
<!--INFORMACION DEL MODAL PARA EL PAGO-->
    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
          <div id="alert_nombre" runat="server">
         </div>
         <div id="alert_apellido" runat="server">
          </div>
          <div id="alert_username" runat="server">
          </div>
          <div id="alert_correo" runat="server">
          </div>
          <div id="alert_pregunta" runat="server">
          </div>
          <div id="alert_respuesta" runat="server">
           </div>
           <div id="alert_password" runat="server">
           </div>

        <div id="alertlocal" runat="server">
        </div>


        <h4 class="modal-title">Total: 26.096 Bs</h4>

    
         <div class="form-group">
        <!-- El form iba aqui -->
        

        <br />
        
            <div class="col-sm-10 col-md-10 col-lg-10">
                 <div class="dropdown" runat="server" id="div1">
                 <asp:DropDownList ID="DropDownList1"   class="btn btn-default dropdown-toggle"   onchange="example()"  runat="server" >
                     <asp:ListItem Enabled="true" Text="Seleccione" Value="-1"></asp:ListItem>
                     <asp:ListItem Text="Tarjeta" Value="1"></asp:ListItem>
                     <asp:ListItem Text="Deposito" Value="2"></asp:ListItem>
                     <asp:ListItem Text="Transferencia" Value="3"></asp:ListItem>
               </asp:DropDownList>
             </div> 
            </div>
        </div>
        <h4 class="modal-title">Tarjeta Credito/Debito</h4>
        <div class="form-group">
	        <div id="div_usuao" class="col-sm-10 col-md-10 col-lg-10">
		        <input id="Text1" Disabled="disabled" type="text" placeholder="Numero de la Tarjeta" class="form-control" name="Text1" runat="server"/>
		    </div>
	    </div>
        <div class="form-group">
	        <div id="div_uario" class="col-sm-10 col-md-10 col-lg-10">
		        <input id="Text2" Disabled="disabled" type="text" placeholder="Nombre del Tarjeta Habiente" class="form-control" name="Text2" runat="server"/>
		    </div>
	    </div>
        <div class="form-group">
	        <div id="div_usuario" class="col-sm-10 col-md-10 col-lg-10">
		        <input id="Text3" Disabled="disabled" type="text" placeholder="Fecha de Vencimiento" class="form-control" name="Text3" runat="server"/>
		    </div>
	    </div>
        <div class="form-group">
	        <div id="div_email" class="col-sm-5 col-md-5 col-lg-5">
		        <input id="Text4" Disabled="disabled" type="password" placeholder="Codigo de Seguridad" class="form-control" name="Text4" runat="server"/>
		    </div>
	    </div>
        
        <h4 class="modal-title">Deposito Bancario</h4>

        <div class="form-group">
			<div id="div_confirm_pswd" class="col-sm-10 col-md-10 col-lg-10">
				    <input id="Text5" Disabled="disabled" type="text" placeholder="Numero del Deposito" class="form-control" name="Text5" runat="server"/>
            </div>
		</div>
       
        <div class="form-group">
			<div id="div_pregunta" class="col-sm-10 col-md-10 col-lg-10">
				<input id="Text6" Disabled="disabled" type="text" placeholder="Banco Emisor" class="form-control" name="Text6"  runat="server"/>
			</div>
		</div>

        <div class="form-group">
			<div id="div_preg" class="col-sm-5 col-md-5 col-lg-5">
				<input id="Text7" Disabled="disabled" type="text" placeholder="Monto" class="form-control" name="Text7"  runat="server"/>
			</div>
		</div>

        <h4 class="modal-title">Transferencia</h4>

        <div class="form-group">
			<div id="div_respuesta" class="col-sm-10 col-md-10 col-lg-10">
				<input id="Text8" Disabled="disabled" type="text" placeholder="Codigo de Confirmacion" class="form-control" name="Text8"  runat="server"/>
			</div>
		</div>

        <div class="form-group">
			<div id="div_respuestas" class="col-sm-10 col-md-10 col-lg-10">
				<input id="Text9" Disabled="disabled" type="text" placeholder="Banco Emisor" class="form-control" name="Text9"  runat="server"/>
			</div>
		</div>
        <div class="form-group">
			<div id="div_respuess" class="col-sm-5 col-md-5 col-lg-5">
				<input id="Text10" Disabled="disabled" type="text" placeholder="Monto" class="form-control" name="Text10"  runat="server"/>
			</div>
		</div>

         <div class="form-group">
		    <div class="box-footer">
				<button id="Boton1" style="align-content:flex-end" runat="server" Disabled="disabled" class="btn btn-primary" type="submit" >Registrar</button>
                <a class="btn btn-default" href="ListarUsuarios.aspx">Cancelar</a>
			</div>
	    </div>


    </form>
        </div>

<!--VALIDACION PARA EL MODAL DE PAGO-->
    <script src="js/Validacion.js"></script>
    <script>

        function example() {
            if ($('#<%=DropDownList1.ClientID %>').val() == -1) {

                $('#<%=Text1.ClientID %>').attr("disabled", "disabled");
                $('#<%=Text2.ClientID %>').attr("disabled", "disabled");
                $('#<%=Text3.ClientID %>').attr("disabled", "disabled");
                $('#<%=Text4.ClientID %>').attr("disabled", "disabled");
                $('#<%=Text5.ClientID %>').attr("disabled", "disabled");
                $('#<%=Text6.ClientID %>').attr("disabled", "disabled");
                $('#<%=Text7.ClientID %>').attr("disabled", "disabled");
                $('#<%=Text8.ClientID %>').attr("disabled", "disabled");
                $('#<%=Text9.ClientID %>').attr("disabled", "disabled");
                $('#<%=Text10.ClientID %>').attr("disabled", "disabled");
                $('#<%=Text1.ClientID %>').val('');
                $('#<%=Text2.ClientID %>').val('');
                $('#<%=Text3.ClientID %>').val('');
                $('#<%=Text4.ClientID %>').val('');
                $('#<%=Text5.ClientID %>').val('');
                $('#<%=Text6.ClientID %>').val('');
                $('#<%=Text7.ClientID %>').val('');
                $('#<%=Text8.ClientID %>').val('');
                $('#<%=Text9.ClientID %>').val('');
                $('#<%=Text10.ClientID %>').val('');
            }
            else
                if ($('#<%=DropDownList1.ClientID %>').val() == 1) {
                    $('#<%=Text1.ClientID %>').attr("disabled", false);
                    $('#<%=Text2.ClientID %>').attr("disabled", false);
                    $('#<%=Text3.ClientID %>').attr("disabled", false);
                    $('#<%=Text4.ClientID %>').attr("disabled", false);

                    //Deshabilitamos los campos y limpiamos
                    $('#<%=Text5.ClientID %>').attr("disabled", "disabled");
                    $('#<%=Text6.ClientID %>').attr("disabled", "disabled");
                    $('#<%=Text7.ClientID %>').attr("disabled", "disabled");
                    $('#<%=Text8.ClientID %>').attr("disabled", "disabled");
                    $('#<%=Text9.ClientID %>').attr("disabled", "disabled");
                    $('#<%=Text10.ClientID %>').attr("disabled", "disabled");
                    $('#<%=Text5.ClientID %>').val('');
                    $('#<%=Text6.ClientID %>').val('');
                    $('#<%=Text7.ClientID %>').val('');
                    $('#<%=Text8.ClientID %>').val('');
                    $('#<%=Text9.ClientID %>').val('');
                    $('#<%=Text10.ClientID %>').val('');

                    $('#<%=Boton1.ClientID %>').attr("disabled", false);
                }

                else
                    if ($('#<%=DropDownList1.ClientID %>').val() == 2) {

                        //Deshabilitamos los campos y limpiamos
                        $('#<%=Text1.ClientID %>').attr("disabled", "disabled");
                        $('#<%=Text2.ClientID %>').attr("disabled", "disabled");
                        $('#<%=Text3.ClientID %>').attr("disabled", "disabled");
                        $('#<%=Text4.ClientID %>').attr("disabled", "disabled");
                        $('#<%=Text1.ClientID %>').val('');
                        $('#<%=Text2.ClientID %>').val('');
                        $('#<%=Text3.ClientID %>').val('');
                        $('#<%=Text4.ClientID %>').val('');

                        $('#<%=Text5.ClientID %>').attr("disabled", false);
                        $('#<%=Text6.ClientID %>').attr("disabled", false);
                        $('#<%=Text7.ClientID %>').attr("disabled", false);

                        //Deshabilitamos los campos y limpiamos
                        $('#<%=Text8.ClientID %>').attr("disabled", "disabled");
                        $('#<%=Text9.ClientID %>').attr("disabled", "disabled");
                        $('#<%=Text10.ClientID %>').attr("disabled", "disabled");
                        $('#<%=Text8.ClientID %>').val('');
                        $('#<%=Text9.ClientID %>').val('');
                        $('#<%=Text10.ClientID %>').val('');

                        $('#<%=Boton1.ClientID %>').attr("disabled", false);
                    }
                    else
                        if ($('#<%=DropDownList1.ClientID %>').val() == 3) {

                            //Deshabilitamos los campos y limpiamos
                            $('#<%=Text1.ClientID %>').attr("disabled", "disabled");
                            $('#<%=Text2.ClientID %>').attr("disabled", "disabled");
                            $('#<%=Text3.ClientID %>').attr("disabled", "disabled");
                            $('#<%=Text4.ClientID %>').attr("disabled", "disabled");
                            $('#<%=Text5.ClientID %>').attr("disabled", "disabled");
                            $('#<%=Text6.ClientID %>').attr("disabled", "disabled");
                            $('#<%=Text7.ClientID %>').attr("disabled", "disabled");
                            $('#<%=Text1.ClientID %>').val('');
                            $('#<%=Text2.ClientID %>').val('');
                            $('#<%=Text3.ClientID %>').val('');
                            $('#<%=Text4.ClientID %>').val('');
                            $('#<%=Text5.ClientID %>').val('');
                            $('#<%=Text6.ClientID %>').val('');
                            $('#<%=Text7.ClientID %>').val('');

                            $('#<%=Text8.ClientID %>').attr("disabled", false);
                            $('#<%=Text9.ClientID %>').attr("disabled", false);
                            $('#<%=Text10.ClientID %>').attr("disabled", false);
                            $('#<%=Boton1.ClientID %>').attr("disabled", false);
                        }
        }
    </script>
						</div>
					</div>
				</div>
			</div>
		</div>


    <script type="text/javascript">
        $(document).ready(function () {

            var table = $('#example').DataTable({
                "language": {
                    "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                }
            });
            var req;
            var tr;

                $('#example tbody').on('click', 'a', function () {
                    if ($(this).parent().hasClass('selected')) {
                        req = $(this).parent().prev().prev().prev().text();
                        tr = $(this).parents('tr');//se guarda la fila seleccionada
                        $(this).parent().removeClass('selected');

                    }
                    else {
                        req = $(this).parent().prev().prev().prev().text();
                        tr = $(this).parents('tr');//se guarda la fila seleccionada
                        table.$('tr.selected').removeClass('selected');
                        $(this).parent().addClass('selected');
                    }

                });

                $('#modal-delete').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-title').text('Eliminar requerimiento:  ' + req)
                    modal.find('#req').text(req)
                })
                $('#btn-eliminar').on('click', function () {
                    table.row(tr).remove().draw();//se elimina la fila de la tabla
                    $('#modal-delete').modal('hide');//se esconde el modal
                    
                });
              

           });

        </script>

</asp:Content>
