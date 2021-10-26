<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/principal.Master" AutoEventWireup="true" CodeBehind="CompraView.aspx.cs" Inherits="sistemaCompra.View.Compra.CompraView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center">Lista de Compras</h1>
    <asp:Repeater runat="server" ID="RepeaterCompras" OnItemDataBound="RepeaterCompras_ItemDataBound" OnItemCommand="RepeaterCompras_ItemCommand" >
        <ItemTemplate>
                <div class="card">                   

                    <div class="card-header">                       
                        <table class="table">
                            <thead>
                                <tr>
                                    <th class="col-md-1">#</th>
                                    <th class="col-md-1">Cliente</th>
                                    <th class="col-md-2">Data</th>
                                    <th class="col-md-2">Valor Total</th>
                                    <th class="col-md-2">Ativo</th>
                                    <th class="col-md-2">Ação</th>
                                    <th class="col-md-2">Lista</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td class="col-md-1">
                                        <asp:Label Text='<%# Eval("Id") %>' runat="server" ID="lbCodigo"/>
                                    </td>
                                    <td class="col-md-1">
                                        <asp:Label Text='<%# Eval("CodCliente") %>' runat="server" ID="Label2"/>
                                    </td>
                                    <td class="col-md-2">
                                        <asp:Label Text='<%# Eval("Data") %>' runat="server" ID="Label3"/>
                                    </td>
                                    <td class="col-md-2">
                                        <asp:Label Text='<%# Eval("ValorTot") %>' runat="server" ID="lbValorTot"/>
                                    </td>
                                    <td class="col-md-2">
                                        <asp:label Text='<%# Eval("AtivoString") %>' runat="server" ID="Label4"/>
                                    </td>
                                    <td class="col-md-2">                                    
                                        <asp:LinkButton  Text="Editar" runat="server" CommandArgument='<%# Eval("Id") %>' ID="Editar" CommandName="Editar" class="btn btn-primary"/>                                        
                                        <asp:LinkButton Text="Excluir" runat="server" CommandArgument='<%# Eval("Id") %>' ID="excluir" CommandName="Excluir" CssClass="btn btn-danger" />                                        
                                    </td>
                                    <td class="col-md-2">
                                        <p class="btn btn-primary" data-bs-toggle="collapse" href="#dadosItem" role="button" aria-expanded="false" aria-controls="collapseExample">Ver Lista</p>
                                    </td>
                                </tr>
                            </tbody>
                        </table>                   
                    </div>
                    <div class="card-body collapse" id="dadosItem">
                         
                        <asp:Label Text="Produtos: " runat="server" ID="produto" class="form-label"/>
                        <asp:DropDownList runat="server" ID="ddlproduto" class="form-select" DataTextField="Descricao" DataValueField="Id">         
        
                        </asp:DropDownList>

                        <asp:Label Text="Quantidade: " runat="server" ID="qtd" AssociatedControlID="qtds" class="form-label"/>
                        <asp:TextBox runat="server" ID="qtds" class="form-control"/>  

                        <br />    
                        <asp:Label runat="server" ID="LabelErro" class="alert-danger"/> 
                        <br />
                         <asp:LinkButton  Text="Adicionar" runat="server"  ID="Adicionar"  CommandArgument='<%# Eval("Id") %>' CommandName="Adicionar" class="btn btn-primary"/> 
                         <asp:Button Text="Reset" runat="server" ID="reset" type="reset" class="btn btn-danger"/>
                         
                        <br />
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>##</th>
                                    <th>Produto</th>
                                    <th>Qtd</th>
                                    <th>SubTotal</th>
                                    <th>Ação</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="RepeaterListaItens" OnItemCommand="RepeaterListaItens_ItemCommand">
                                    <ItemTemplate>
                                         <tr>
                                            <td>
                                                 <asp:Label Text='<%# Eval("Id") %>' runat="server" ID="lbId"/>
                                            </td>
                                             <td>
                                                 <asp:Label Text='<%# Eval("GuidCod") %>' runat="server" ID="lbGuid"/>
                                             </td>
                                            <td>
                                                 <asp:Label Text='<%# Eval("CodProduto") %>' runat="server" ID="lbCodProd"/>
                                            </td>
                                            <td>
                                                 <asp:Label Text='<%# Eval("Qtd") %>' runat="server" ID="lbQtd"/>
                                            </td>
                                             <td>

                                                 <asp:Label Text='<%# Eval("SubTotal") %>' runat="server" ID="lbSubTot"/>
                                            </td>
                                            <td>
                                                <asp:LinkButton Text="Excluir" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="Excluir" ID="Excluir" CssClass="btn btn-danger"/>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>                               
                            </tbody>
                        </table>
                    </div>
                </div> 
            <hr />
        </ItemTemplate>
     </asp:Repeater>      
   
   
</asp:Content>
