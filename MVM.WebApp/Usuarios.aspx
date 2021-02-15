<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="MVM.WebApp.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container-fluid " style="margin-top:5%">
        <div class="alert alert-warning alert-dismissible" role="alert" runat="server" id="alerta">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <strong>Importante!</strong> <asp:Label ID="lblAlerta" runat="server" ></asp:Label>
        </div>
        <asp:LinkButton ID="lbtnCrear" CssClass="btn btn-primary btn-lg" runat="server" data-toggle="modal" data-target="#myModal">Crear Usuario</asp:LinkButton>
        <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="myModalLabel">Crear Nuevo Usuario</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                 <div  >
                            Llene todas las opciones
                            <div class="col-md-12">
                               <asp:TextBox ID="txtUsuario" CssClass="form-control" placeholder="Usuario nuevo" runat="server"></asp:TextBox>
                            </div>

                                <div class="col-md-12" style="margin-top:2%">
                                   <asp:TextBox ID="txtContraseña" CssClass="form-control" placeholder="Escriba la contraseña" runat="server"></asp:TextBox>
                                </div>
                                     <div class="col-md-12" style="margin-top:2%">
                                   <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Escriba el nombre completo del Usuario" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-12" style="margin-top:1%">
                                     <asp:DropDownList ID="ddlRem" CssClass="form-control"  runat="server">
                                    <asp:ListItem Value="0">Seleccione Rol</asp:ListItem>
                                    <asp:ListItem Value="admin">Administrador</asp:ListItem>
                                    <asp:ListItem Value="Gestor">Gestor</asp:ListItem>
                                    <asp:ListItem Value="Consultor">Consultor</asp:ListItem>
                                </asp:DropDownList>
                                </div>

                            <div >
                                <div class="col-md-12" style="margin-top: 2%; margin-bottom: 2%">
                                    <asp:DropDownList ID="ddlDestin" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0">Seleccione Area Destino</asp:ListItem>
                                        <asp:ListItem Value="TI">Sistemas y Tecnología</asp:ListItem>
                                        <asp:ListItem Value="DHO">Recursos Humanos</asp:ListItem>
                                        <asp:ListItem Value="Gestion Documental">Gestion Documental</asp:ListItem>
                                        <asp:ListItem Value="Comercial">Comercial</asp:ListItem>
                                        <asp:ListItem Value="Contabilidad">Contabilidad</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <asp:CheckBox ID="chEstado" CssClass="form-control" Text="Estado" runat="server" />
                            </div>
                        </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                       
                    </div>
                    <div class="modal-footer" style="margin-top:35%">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                        <asp:LinkButton ID="lblGuardar" CssClass="btn btn-primary glyphicon glyphicon-floppy-disk"  runat="server">Guardar</asp:LinkButton>
                       
                    </div>
                </div>
            </div>
        </div>
        <br />
        <br />
        <div class="panel panel-default mt-10">
            <!-- Default panel contents -->
            <div class="panel-heading">Control de Aplicaciones</div>
            <div class="panel-body">
                <p>En esta vista podra crear, modificar, eliminar y ver la lista de usuarios del sistema</p>

            </div>

            <!-- Table -->
            <asp:GridView ID="grdUsers" CssClass="table" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="Id Comunicacion">
                        <ItemTemplate>
                            <asp:Label ID="lblcom" runat="server" Text='<%# Eval("IdUsuario") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Consecutivo">
                        <ItemTemplate>
                            <asp:Label ID="lblCons" runat="server" Text='<%# Eval("NombreUsuario") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Código Tipo de Comunicación">
                        <ItemTemplate>
                            <asp:Label ID="lblCodTip" runat="server" Text='<%# Eval("Rol") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Usuario Gestor">
                        <ItemTemplate>
                            <asp:Label ID="lblUsserGes" runat="server" Text='<%# Eval("Area") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remitente">
                        <ItemTemplate>
                            <asp:Label ID="txtRem" runat="server"  Text='<%# Eval("Estado") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                             <asp:LinkButton ID="lblEliminar" CssClass="btn btn-primary glyphicon glyphicon-trash" OnClick="lblEliminar_Click" runat="server"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
