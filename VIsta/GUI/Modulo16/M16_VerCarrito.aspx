<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M16_VerCarrito.aspx.cs" Inherits="templateApp.GUI.Modulo16.M16_VerCarrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Inicio</a>
		    </li>
		
		    <li>
			    <a href="#">Ver Carrito</a> 
		    </li>
		</ol>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server"> Carrito 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server"> Productos que posees:
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

     <div id="alert" runat="server">
    </div>

    <div class="alert alert-success alert-dismissable" style="display:none" id="prueba">
    <button type="button" class="close" data-dismiss="alert" aria-hidden="true"  >&times;</button>
            El Articulo Deportivo se ha Eliminado Exitosamente del Carrito.
        </div>
    
    <div class="alert alert-success alert-dismissable" style="display:none" id="prueba1">
    <button type="button" class="close" data-dismiss="alert" aria-hidden="true"  >&times;</button>
            El Pago se ha registrado Exitosamente.
        </div>
<!--TABLAS-->
     <!-- general form elements -->
     <form id="form1" runat="server">
              
              <div class="row">
            <div class="col-xs-12">
              <div class="box">
        <div class="box-header">
                      <h3 class="box-title">Inventario</h3>
        </div><!-- /.box-header -->

    <div class="box-body table-responsive">
       <asp:Table ID="Table1" runat="server" CssClass="table table-bordered table-striped dataTable">
           <asp:TableHeaderRow>
               <asp:TableHeaderCell>
                   Producto
               </asp:TableHeaderCell>
               <asp:TableHeaderCell>
                   Cantidad
               </asp:TableHeaderCell>
               <asp:TableHeaderCell>
                   Precio
               </asp:TableHeaderCell>
               <asp:TableHeaderCell>
                   Acciones
               </asp:TableHeaderCell>
           </asp:TableHeaderRow>           
         </asp:Table>
        </div>
       </div>
    </div>
</div>

        

         <div class="row">
            <div class="col-xs-12">
              <div class="box">                  
        <div class="box-header">
                      <h3 class="box-title">Matricula</h3>
        </div><!-- /.box-header -->

        <div class="box-body table-responsive">
        <table id="tablamatricula" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
					<th>Identificador de Matricula</th>
					<th >Fecha de Creacion</th>           
                    <th>Ultima Fecha de Pago</th>
                    
					<th style="text-align:left">Acciones</th>
				</tr>
			</thead>
			<tbody>
                <asp:Literal runat="server" ID="laTabla2"></asp:Literal>
		    </tbody>
            </table>
           </div>
       </div>
    </div>
</div>

                <div class="row">
            <div class="col-xs-12">
              <div class="box">
        <div class="box-header">
                      <h3 class="box-title">Evento</h3>
        </div><!-- /.box-header -->

    <div class="box-body table-responsive">
        <table id="tablaevento" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
					<th style="text-align:left">Nombre del evento</th>
					<th style="text-align:left">Costo</th>           
                 
					<th style="text-align:left">Acciones</th>
				</tr>
			</thead>
			<tbody>
                <asp:Literal runat="server" ID="laTabla3"></asp:Literal>
		    </tbody>
            </table>
           </div>
       </div>
    </div>
</div>

   <!-- M  O  D  A  L  E  S-->
       <!--MODAL PARA EL DETALLE IMPLEMENTO-->
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
                                <h3>Imagen</h3>
									<img src="" id="beta" />
                                   
                                <h3>Nombre</h3>
                                    <label id="aux1" ></label>
                                    
								<h3>Tipo Implemento</h3>
                                    <label id="aux2" ></label>
                                    
                                <h3>Marca</h3>
                                    <label id="aux3" ></label>
                                   
                                <h3>Color</h3>
                                    <label id="aux4" ></label>
                                    
                                <h3>Talla</h3>
                                    <label id="aux5" ></label>
                                    
                                <h3>Status</h3>
                                    <label id="aux6" ></label>
                                    
                                <h3>Precio</h3>
                                    <label id="aux7" ></label>
                                    
                                <h3>Descripcion</h3>
                                    <label id="aux8" ></label>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>

        <!--MODAL PARA EL DETALLE EVENTO-->
    	<div id="modal-info2" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h2 class="modal-title">Información detallada del Evento</h2>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info2">
							<div class="row">
                                <h3>Id</h3>
                                    <label id="aux9" ></label>
                                <h3>Nombre</h3>
									 <label id="aux10" ></label>
                                <h3>Descripcion</h3>
									 <label id="aux11" ></label>
                                <h3>Costo</h3>
									 <label id="aux12" ></label>

							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
   



<!--MODAL DE PAGO-->
    <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
         <button id="btn-agregarComp" style="align-content:flex-end" class="btn btn-primary" type="button" data-toggle="modal" data-target="#modal-info"">Pagar</button>
          &nbsp;&nbsp
         
         
         
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

        <%-- <h4 class="modal-title" id ="preciofinal"></h4> --%>

        <div class="form-group">
        <!-- El form iba aqui -->
        
              
        <br />
        
            <div class="col-sm-10 col-md-10 col-lg-10">
                 <div class="dropdown" runat="server" id="div1">
                     </div>
            
                 <div class="btn-group">
            
                                <select id="DropDownList1" runat="server" class="combobox" style="width:100px; height:35px" onchange="example()" >
                                <option value="-1">Seleccione</option>
                                <option value="1">Tarjeta</option>
                                <option value="2">Deposito</option>
                                <option value="3">Transferencia</option>
                                </select>
                
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
			<%--<button id="Boton1" style="align-content:flex-end" runat="server" Disabled="disabled" class="btn btn-primary" type="button" onclick="$('#modal-info').modal('hide'); $('#prueba1').show(); $('#example').DataTable().clear().draw(); " >Registrar Pago</button>--%>
               <%--  <asp:Button id="Boton1" style="align-content:flex-end" OnClick="registrarPago" runat="server" Disabled="disabled" class="btn btn-primary" Text="Registrar Pago" type ="submit" /> --%>
              <%--  <asp:Button ID="Boton1" runat="server" Text="Procesar Pago" OnClick ="registrarPago" class="btn btn-primary" style="align-content:flex-end"/> --%>
                <a class="btn btn-default" href="M16_VerCarrito.aspx">Cancelar</a>
			</div>
	    </div>


     </form>
      


<!--VALIDACION PARA EL MODAL DE PAGO-->
  <%--  <script src="js/Validacion.js"></script>
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
                

                //  $().hide() para esconder campo.
                //     .show() para mostrar campo.
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

        //Funcion que eliminara el producto dependiendo de cual sea
        function prueba3(evento)
        {
            debugger

            //Si el evento no es indefinido se realizaran las acciones pertinentes
            if (e != undefined)
            {
                var numero = 0;

                //Obtenemos a que tipo de objeto nos estamos refiriendo y le asignamos su numero
                var arrayDatos = e.id.split("_");
                if (arrayDatos[1] == "I")
                    numero = 1;
                else if (arrayDatos[1] == "M")
                    numero = 2;
                else
                    numero = 3;

                var producto = {
                    tipo: numero,
                    id: arrayDatos[0]

                }

                var datos = JSON.stringify(producto);

                  $.ajax({
                        cache: false,
                        type: 'POST',
                        url: 'http://localhost:23072/GUI/Modulo16/M16_ConsultarProducto.aspx/eliminarItem',
                        data: datos,
                        dataType: 'json',
                        contentType: "application/json; charset=utf-8",

                        success: function (data) {
                            debugger

                            console.log("Exito:" + data);

                            var aa = JSON.parse(data.d);

                          


                        }

                    });
               
            }
        }


        $(document).ready(function () {

            var table1 = $('#tablainventario').DataTable({
                "dom": '<"pull-left"f>rt<"pull-right"lp>i',
                "language": {
                    "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                }
            });
            var req;
            var tr;

                    $('#tablainventario tbody').on('click', 'a', function () {
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


                    var table2 = $('#tablamatricula').DataTable({
                    "dom": '<"pull-left"f>rt<"pull-right"lp>i',
                    "language": {
                        "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                    }
                });

                                $('tablamatricula tbody').on('click', 'a', function () {
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


                                var table3 = $('#tablaevento').DataTable({
                                    "dom": '<"pull-left"f>rt<"pull-right"lp>i',
                                    "language": {
                                        "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                                    }
                                });

                                $('tablaevento tbody').on('click', 'a', function () {
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
                    $('#prueba').show();//Muestra el mensaje de borrado exitosamente
                });


            // Carga el modal con la informacion del IMPLEMENTO de acuerdo al id
                $('#modal-info1').on('show.bs.modal', function (e) {

                    

                    $.ajax({
                        cache: false,
                        type: 'POST',
                        url: 'http://localhost:23072/GUI/Modulo16/M16_VerCarrito.aspx/pruebaImplemento',
                        data: "{'id':" + "'" + e.relatedTarget.id + "'" + "}",
                        dataType: 'json',
                        contentType: "application/json; charset=utf-8",

                        success: function (data) {
                            console.log(data);

                            var aa = JSON.parse(data.d);

                            console.log(aa);

                            $("#beta").attr("src", aa.Imagen_implemento);
                            $("#aux1").html(aa.Nombre_implemento);
                            $("#aux2").html(aa.Tipo_Implemento);
                            $("#aux3").html(aa.Marca_Implemento);
                            $("#aux4").html(aa.Color_Implemento);
                            $("#aux5").html(aa.Talla_Implemento);
                            $("#aux6").html(aa.Estatus_Implemento);
                            $("#aux7").html(aa.Precio_Implemento);
                            $("#aux8").html(aa.Descripcion_Implemento);

                        }
                    });
                })


            // Carga el modal con la informacion del EVENTO de acuerdo al id
                $('#modal-info2').on('show.bs.modal', function (e) {
                    
                    $.ajax({
                        cache: false,
                        type: 'POST',
                        url: 'http://localhost:23072/GUI/Modulo16/M16_VerCarrito.aspx/pruebaEvento',
                        data: "{'id':" + "'" + e.relatedTarget.id + "'" + "}",
                        dataType: 'json',
                        contentType: "application/json; charset=utf-8",

                        success: function (data) {
                            console.log(data);

                            var aa = JSON.parse(data.d);
                            console.log(aa);

                            $("#aux9").html(aa.Id_evento);
                            $("#aux10").html(aa.Nombre);
                            $("#aux11").html(aa.Descripcion);
                            $("#aux12").html(aa.Costo);

                        }
                    });
                })


           });

        </script>--%>

</asp:Content>
