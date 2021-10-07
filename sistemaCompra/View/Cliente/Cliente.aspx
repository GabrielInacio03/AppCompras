<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/principal.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="sistemaCompra.View.Cliente.Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">       
    <h1 class="text-center">Clientes</h1>
    <asp:Label Text="Nome: " runat="server" ID="campo1" AssociatedControlID="campoTexto1" class="form-label"/>
    <asp:TextBox runat="server" ID="campoTexto1" class="form-control"/>
            
    <asp:Label Text="Endereço: " runat="server" ID="Label2" AssociatedControlID="campoTexto2" class="form-label"/>
    <asp:TextBox runat="server" ID="campoTexto2" class="form-control"/>

    <asp:Label Text="Data de Nascimento: " runat="server" ID="Label3" AssociatedControlID="campoTexto3" class="form-label"/>
    <asp:TextBox runat="server" ID="campoTexto3" class="form-control"/>

    <br />    
    <asp:Label runat="server" ID="LabelErro" class="alert-danger"/> 
    <br />
    <asp:Button Text="Enviar" runat="server" ID="enviar" OnClick="enviar_Click" class="btn btn-success"/> 
    <asp:Button Text="Reset" runat="server" ID="reset" type="reset" class="btn btn-danger"/>
    
    <table class="table">
        <thead>
            <tr>
                <th class="col-md-1">#</th>
                <th class="col-md-3">Nome</th>
                <th class="col-md-3">Endereço</th>
                <th class="col-md-1">Data de Nascimento</th>               
                <th class="col-md-1">Editar</th>
                <th class="col-md-1">Excluir</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="repeaterList">
                <ItemTemplate>
                    <tr>
                        <td class="col-md-1"><%# Eval("Id") %></td>
                        <td class="col-md-3"><%# Eval("Nome") %></td>
                        <td class="col-md-2"><%# Eval("Endereco") %></td>
                        <td class="col-md-2"><%# Eval("DataNasc") %></td>                       
                        <td class="col-md-1">
                            <a class="btn btn-primary" href="#">Editar</a>                            
                        </td>
                        <td class="col-md-1">
                            <a class="btn btn-danger" href="#">Excluir</a>                               
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
       
    </table>
</asp:Content>
