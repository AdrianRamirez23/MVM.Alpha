<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comunicaciones.aspx.cs" Inherits="MVM.WebApp.Comunicaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid " style="margin-top:5%">
        <div class="alert alert-warning alert-dismissible" role="alert" runat="server" id="alerta">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <strong>Importante!</strong> <asp:Label ID="lblAlerta" runat="server" ></asp:Label>
        </div>
        <asp:LinkButton ID="lbtnCrear" CssClass="btn btn-primary btn-lg" runat="server" data-toggle="modal" data-target="#myModal">Crear Nueva Comunicación</asp:LinkButton>
        <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="myModalLabel">Radicar Nueva Comunicación</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                 <div  >
                            Seleccione las opciones según el tipo de comunicación que desea radicar
                            <div class="col-md-12">
                                <asp:DropDownList ID="ddlTipoCom" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoCom_SelectedIndexChanged" CssClass="form-control"  runat="server">
                                    <asp:ListItem Value="0">Seleccione Tipo de Correspondencia</asp:ListItem>
                                    <asp:ListItem Value="CI">Interna</asp:ListItem>
                                    <asp:ListItem Value="CE">Externa</asp:ListItem>
                                </asp:DropDownList>
                            </div>


                                <div class="col-md-12" style="margin-top:2%">
                                     <asp:TextBox ID="txtRemitente" CssClass="form-control" placeholder="Escriba nombre del remitente" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-12" style="margin-top:1%">
                                     <asp:DropDownList ID="ddlRem" CssClass="form-control"  runat="server">
                                    <asp:ListItem Value="0">Seleccione Remitente Interno</asp:ListItem>
                                    <asp:ListItem Value="aramirez">Sistemas y Tecnología</asp:ListItem>
                                    <asp:ListItem Value="jgutierrez">Recursos Humanos</asp:ListItem>
                                    <asp:ListItem Value="nhiguita">Contabilidad</asp:ListItem>
                                    <asp:ListItem Value="ycifuentes">Comercial</asp:ListItem>
                                </asp:DropDownList>
                                </div>

                            <div >
                                <div class="col-md-12" style="margin-top: 2%; margin-bottom: 2%">
                                    <asp:DropDownList ID="ddlDestin" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0">Seleccione Area Destino</asp:ListItem>
                                        <asp:ListItem Value="aramirez">Sistemas y Tecnología</asp:ListItem>
                                        <asp:ListItem Value="jgutierrez">Recursos Humanos</asp:ListItem>
                                        <asp:ListItem Value="nhiguita">Contabilidad</asp:ListItem>
                                        <asp:ListItem Value="ycifuentes">Comercial</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                 
                            </div>
                        </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                       
                    </div>
                    <div class="modal-footer" style="margin-top:25%">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                        <asp:LinkButton ID="lblGuardar" CssClass="btn btn-primary glyphicon glyphicon-floppy-disk" OnClick="lblGuardar_Click" runat="server">Guardar</asp:LinkButton>
                       
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
                <p>En esta vista podra crear, modificar, eliminar y ver la lista de comunicaciones radicadas según los permisos que posea</p><br />
                <p>Busqueda por rango de fecha</p><br /><br />
                <asp:TextBox ID="txtFechIni" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtFechFin" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox><br />
                <asp:Button ID="btnSearch" CssClass="btn btn-primary glyphicon glyphicon-search" runat="server" OnClick="btnSearch_Click" Text="Buscar" />


            </div>

            <!-- Table -->
            <asp:GridView ID="grdComunicaciones" CssClass="table" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="Id Comunicacion">
                        <ItemTemplate>
                            <asp:Label ID="lblcom" runat="server" Text='<%# Eval("idComunicacion") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Consecutivo">
                        <ItemTemplate>
                            <asp:Label ID="lblCons" runat="server" Text='<%# Eval("Consecutivo") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Código Tipo de Comunicación">
                        <ItemTemplate>
                            <asp:Label ID="lblCodTip" runat="server" Text='<%# Eval("CodTipoComunicacion") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Usuario Gestor">
                        <ItemTemplate>
                            <asp:Label ID="lblUsserGes" runat="server" Text='<%# Eval("UsuarioGestor") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remitente">
                        <ItemTemplate>
                            <asp:TextBox ID="txtRem" runat="server" CssClass="form-control" Text='<%# Eval("Remitente") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Destinatario">
                        <ItemTemplate>
                            <asp:TextBox ID="txtDes" runat="server" CssClass="form-control" Text='<%# Eval("Destinatario") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha Radicación">
                        <ItemTemplate>
                            <asp:Label ID="lblRad" runat="server" Text='<%# Eval("FechaRadc") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblEditar" CssClass="btn btn-success glyphicon glyphicon-pencil" OnClick="lblEditar_Click" runat="server"></asp:LinkButton>
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
