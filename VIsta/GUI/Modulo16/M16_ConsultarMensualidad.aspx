<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M16_ConsultarMensualidad.aspx.cs" Inherits="templateApp.GUI.Modulo16.M16_ConsultarMensualidad" %>
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
			    <a href="#">Consultar Mensualidad</a> 
		    </li>
		</ol>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server"> Consulta de Matriculas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server"> Matriculas en Existencia:
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

     
    
    <div id="alert" runat="server">
    </div>

    <div class="alert alert-success alert-dismissable" style="display:none" id="agregarMatriculaAcarrito">
    <button type="button" class="close" data-dismiss="alert" aria-hidden="true"  >&times;</button>
            la matricula se ha Agregado Exitosamente al Carrito.
        </div>
     
         <!--MODAL PARA EL DETALLE-->
     <!-- general form elements -->
         <div class="row">
             <div class="col-xs-12"> 
         <div class="box">
                <div class="box-header">
                  <h3 class="box-title">Mensualidad(es) Morosa(s)</h3>
                </div><!-- /.box-header -->
 <div class="box-body table-responsive">
        <table id="tablamatriculas" class="table table-bordered table-striped dataTable">
        <thead>
            <tr>
              
					<th style="text-align:left">Identificador de Matricula</th>
                    <th style="text-align:left">Fecha Inicio</th>
                    <th style="text-align:left">Fecha tope para cancelar</th>
 					<th style="text-align:left">Acciones</th>
                
                              
            </tr>

             
        </thead>
      
            <tbody>
                <asp:Literal runat="server" ID="laTabla"></asp:Literal>
               
		    </tbody>
                  
             </table>
          </div>
          </div>
          </div>
          </div>
        <form role="form" class="form-horizontal" method="POST">
    <div class="form-group">
    
        </div>     
        
            </form>


     <!--VALIDACION PARA MODAL -->
             <script type="text/javascript">

                 // Funcionalidad para el boton Agregar Producto al Carrito
                 function prueba3(e) {

                     debugger

                     if (e != undefined) {

                         var arrayConDatosDelProducto = e.id.split("_");

                         //Obtenemos el id del boton presionado.
                         var aux = $("#" + arrayConDatosDelProducto[0]);

                         //Creamos un objeto con los datos a ser enviado al servidor.
                         var producto = {
                             idMatricula: arrayConDatosDelProducto[0],
                             precio: arrayConDatosDelProducto[1]
                         }

                         var datos = JSON.stringify(producto);

                         if (aux != undefined) {

                             $.ajax({
                                 cache: false,
                                 type: 'POST',
                                 url: 'http://localhost:23072/GUI/Modulo16/M16_ConsultarMensualidad.aspx/agregarMatriculaAcarrito',
                                 data: datos,
                                 dataType: 'json',
                                 contentType: "application/json; charset=utf-8",

                                 success: function (data) {
                                     debugger

                                     console.log("Exito:" + data);

                                     var aa = JSON.parse(data.d);



                                 }

                             });

                             window.location.href = "M16_VerCarrito.aspx?accion=1&exito=1";

                         }
                     }

                 }



                 $(document).ready(function () {

                     var table = $('#tablamatriculas').DataTable({
                         "dom": '<"pull-left"f>rt<"pull-right"lp>i',
                         "language": {
                             "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                         }
                     });
                     var req;
                     var tr;

                     $('#tablamatriculas tbody').on('click', 'a', function () {
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



                     $('#tablamatriculas tbody').on('click', 'a', function () {
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

                     $('#modal-agregar').on('show.bs.modal', function (event) {
                         var modal = $(this)
                         modal.find('.modal-title').text('Eliminar requerimiento:  ' + req)
                         modal.find('#req').text(req)
                     })
                     $('#btn-agregar').on('click', function () {
                         table.row(tr).valueOf.call;//se elimina la fila de la tabla
                         $('#modal-delete').modal('hide');//se esconde el modal
                         $('#prueba').show();//Muestra el mensaje de agregado exitosamente


                     });





                 });
        </script>

</asp:Content>