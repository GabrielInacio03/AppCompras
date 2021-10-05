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
</asp:Content>
