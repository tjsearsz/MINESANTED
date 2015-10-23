<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M16_ConsultarProducto.aspx.cs" Inherits="templateApp.GUI.Modulo16.M16_ConsultarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server"> Consulta de Productos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

     <div class="box-body table-responsive">

         <!--MODAL PARA EL DETALLE-->
     <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Productos Actuales</h3>
                </div><!-- /.box-header -->

       <table id="example" class="table table-bordered table-striped dataTable">
        <thead>
            <tr>
                <th>Foto</th>
                <th>Producto</th>
                <th>Precio (Bs)</th>
                <th>Accion</th>
                
            </tr>
        </thead>
 
        <tfoot>
            <tr>
                <th>Foto</th>
                <th>Producto</th>
                <th>Precio (BS)</th>
                <th>Accion</th>
            </tr>
        </tfoot>
 
        <tbody>
            <tr>
                <td><img src="Imagenes\Karategi.jpg" alt="" style="width:60px; height:auto;"></td>
                <td>Karategi</td>
                <td>Bs 14000</td>
                <td><a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="M16_Prueba.aspx"></a></td>
            </tr>
            <tr>
                <td><img src="Imagenes\CintaBlanca.jpg" alt="" style="width:60px; height:auto;"></td>
                <td>Cinta Blanca</td>
                <td>Bs 400</td>
                <td><a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a></td>
            </tr>
            <tr>
                <td><img src="Imagenes\Suspensorio.jpg" alt="" style="width:60px; height:auto;"></td>
                <td>Suspensorio</td>
                <td>Bs 350</td>
                <td><a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a></td>
            </tr>
            
            <tr>
                <td><img src="Imagenes\ProtectorBucal.jpg" alt="" style="width:60px; height:auto;"></td>
                <td>Proteccion Bucal</td>
                <td>Bs 3200</td>
                <td><a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a></td>
            </tr>

             <tr>
                <td><img src="Imagenes\GuanteRojo.jpg" alt="" style="width:60px; height:auto;"></td>
                <td>Guantes Rojos</td>
                <td>Bs 5000</td>
                <td><a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a></td>
            </tr>

        </tbody>
    </table>



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

        <script type="text/javascript">
            $(document).ready(function () {
                $('#example').DataTable();
            });
        </script>
</asp:Content>
