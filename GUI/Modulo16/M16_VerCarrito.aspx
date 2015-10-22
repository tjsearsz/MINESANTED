<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M16_VerCarrito.aspx.cs" Inherits="templateApp.GUI.Modulo16.M16_VerCarrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

     <div id="alert" runat="server">
    </div>

    <div class="box-body table-responsive">
        <h1>Total en el carrito: 23300</h1>
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
        <tbody>
            <tr>
                <td><img src="Imagenes/CintaBlanca.jpg" alt="" style="width:50px; height:auto;"></td>
                <td>Cinta Blanca</td>
                <td>1</td>
                <td>400</td>
                <td>
                    <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                </td>
            </tr>
            <tr>
                <td><img src="Imagenes/Karategi.jpg" alt="" style="width:50px; height:auto;"></td>
                <td>Karategi</td>
                <td>1</td>
                <td>14000</td>
                 <td>
                     <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                     <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                </td>
            </tr>
            <tr>
                <td><img src="Imagenes/Suspensorio.jpg" alt="" style="width:50px; height:auto;"></td>
                <td>Suspensorio</td>
                <td>2</td>
                <td>350</td>
                <td> 
                    <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                </td>
            </tr>
             <tr>
                <td><img src="Imagenes/ProtectorBucal.jpg" alt="" style="width:50px; height:auto;"></td>
                <td>Proteccion bucal</td>
                <td>1</td>
                <td>3200</td>
                <td>
                    <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                </td>
            </tr>
            <tr>
                <td><img src="Imagenes/GuanteRojo.jpg" alt="" style="width:50px; height:auto;"></td>
                <td>Guantes rojos</td>
                <td>1</td>
                <td>5000</td>
                <td>
                    <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"> </a>
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

    		<div id="modal-info" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h2 class="modal-title">Información detallada del Producto</h2>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
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

        <script type="text/javascript">
            $(document).ready(function () {
                $('#example').DataTable();

                var table = $('#example').DataTable();
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
