<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M16_ConsultarEvento.aspx.cs" Inherits="Vista.GUI.Modulo16.M16_ConsultarEvento" %>
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
                    <th style="text-align:left">Cantidad</th>
					<th style="text-align:left">Acciones</th> 
            </tr>
        </thead>
 
        <tbody>
            <asp:Literal runat="server" ID="tlTablaEventos"></asp:Literal>
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

</asp:Content>