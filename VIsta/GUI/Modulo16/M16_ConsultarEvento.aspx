<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M16_ConsultarEvento.aspx.cs" Inherits="templateApp.GUI.Modulo16.M16_ConsultarEvento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Inicio</a>
		    </li>
		
		    <li>
			    <a href="../Modulo16/M16_VerCarrito.aspx">Ver Carrito</a> 
		    </li>

            <li>
			    <a href="#">Consultar Evento</a> 
		    </li>
		</ol>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server"> Consulta de Eventos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server"> Eventos en Existencia:
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div id="alert" runat="server">
    </div>

    <div class="alert alert-success alert-dismissable" style="display:none" id="agregarEventoaCarrito">
    <button type="button" class="close" data-dismiss="alert" aria-hidden="true"  >&times;</button>
            El Evento se ha Agregado Exitosamente al Carrito.
        </div>

    <div class="box-body table-responsive">

         <!--MODAL PARA EL DETALLE-->
     <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Eventos Actuales</h3>
                </div><!-- /.box-header -->
              </div>
       <table id="tablaevento" class="table table-bordered table-striped dataTable">
        <thead>
            <tr>
                    
                    <th style="text-align:left">Nombre</th>
					<th style="text-align:left">Descripcion</th>
                    <th style="text-align:left">Costo (Bs.)</th>
					<th style="text-align:left">Acciones</th> 
            </tr>
        </thead>
 
        <tbody>
            <asp:Literal runat="server" ID="laTabla"></asp:Literal>
        </tbody>
    </table>    
   </div>
                  <!--MODAL PARA EL DETALLE -->
<div id="modal-info1" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h2 class="modal-title">Información detallada del Evento</h2>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info1">
							<div class="row">
								<h3>Id</h3>
                                    <label id="aux1" ></label>
                                <h3>Nombre</h3>
									 <label id="aux2" ></label>
                                <h3>Descripcion</h3>
									 <label id="aux3" ></label>
                                <h3>Costo</h3>
									 <label id="aux4" ></label>

							</div>
						</div>
					</div>
				</div>
			</div>
		</div>

     <!--VALIDACION PARA MODAL -->
         
         <script type="text/javascript">

             // Funcionalidad para el boton Agregar Evento al Carrito
             function prueba3(e) {

                 debugger

                 if (e != undefined) {

                     var arrayConDatosDelProducto = e.id.split("_");

                     //Obtenemos el id del boton presionado.
                     var aux = $("#" + arrayConDatosDelProducto[0] + "_combo");

                     //Creamos un objeto con los datos a ser enviado al servidor.
                     var producto = {
                         idEvento: arrayConDatosDelProducto[0],
                         cantidad: aux.val(),
                         precio: arrayConDatosDelProducto[1]
                     }

                     var datos = JSON.stringify(producto);

                     if (aux != undefined) {

                         $.ajax({
                             cache: false,
                             type: 'POST',
                             url: 'http://localhost:23072/GUI/Modulo16/M16_ConsultarEvento.aspx/agregarEventoaCarrito',
                             data: datos,
                             dataType: 'json',
                             contentType: "application/json; charset=utf-8",

                             success: function (data) {
                                 debugger

                                 console.log("Exito:" + data);

                                 var aa = JSON.parse(data.d);

                                 alert("Peticion ajax exitosa:" + aa);


                             }

                         });

                         window.location.href = "M16_VerCarrito.aspx?accion=1&exito=1";

                     }
                 }

             }


             $(document).ready(function () {

                 var table = $('#tablaevento').DataTable({
                    "dom": '<"pull-left"f>rt<"pull-right"lp>i',
                     "language": {
                         "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                     }
                 });
                 var req;
                 var tr;

                 $('#tablaevento tbody').on('click', 'a', function () {
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
                     $('#prueba').show();//Muestra el mensaje de agregado exitosamente

                 });

                 // Carga el modal con la informacion del evento de acuerdo al id
                 $('#modal-info1').on('show.bs.modal', function (e) {
                   
                     $.ajax({
                         cache: false,
                         type: 'POST',
                         url: 'http://localhost:23072/GUI/Modulo16/M16_ConsultarEvento.aspx/prueba',
                         data: "{'id':" + "'" + e.relatedTarget.id + "'" + "}",
                         dataType: 'json',
                         contentType: "application/json; charset=utf-8",

                         success: function (data) {
                             console.log(data);

                             var aa = JSON.parse(data.d);
                             console.log(aa);

                             $("#aux1").html(aa.Id_evento);
                             $("#aux2").html(aa.Nombre);
                             $("#aux3").html(aa.Descripcion);
                             $("#aux4").html(aa.Costo);

                         }
                     });
                 })
             });
        </script>

</asp:Content>