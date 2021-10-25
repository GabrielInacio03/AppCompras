<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/principal.Master" AutoEventWireup="true" CodeBehind="Produto.aspx.cs" Inherits="sistemaCompra.View.Produto.Produto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center">Produtos</h1>

    <asp:Label Text="Descrição: " runat="server" ID="campo1" AssociatedControlID="descricao" class="form-label"/>
    <asp:TextBox runat="server" Id="descricao" class="form-control"/>  

    <asp:Label Text="Valor: " runat="server" ID="campo2" AssociatedControlID="valor" class="form-label"/>
    <asp:TextBox runat="server" Id="valor" class="form-control"/>  

    <br />    
    <asp:Label runat="server" ID="LabelErro" class="alert-danger"/> 
    <br />
    <asp:Button Text="Adicionar" runat="server" ID="adicionar" OnClick="adicionar_Click" class="btn btn-success"/> 
    <asp:Button Text="Reset" runat="server" ID="reset" type="reset" class="btn btn-danger"/>

    <table class="table">
        <thead>
            <tr>
                <th>#</th>
                <th>Descricao</th>  
                <th>Valor</th>                
                <th class="col-md-1">Excluir</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="repeaterList" OnItemCommand="repeaterList_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Id") %></td>
                        <td><%# Eval("Descricao") %></td>
                        <td><%# Eval("valor", "{0:c}") %></td>                       
                        <td class="col-md-1">
                            <asp:LinkButton Text="Excluir" runat="server" CommandArgument='<%# Eval("Id") %>' ID="excluir" CommandName="excluir" CssClass="btn btn-danger"/>                        
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
