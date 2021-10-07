﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/principal.Master" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="sistemaCompra.View.Compra.Compra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <h1 class="text-center">Comprar</h1>    
        
    <asp:label text="Clientes: " runat="server" class="form-label"/>
    <asp:DropDownList runat="server" ID="ddlcliente" class="form-select" DataTextField="nome" DataValueField="Id">       
    </asp:DropDownList>        

    <asp:Label Text="Produtos: " runat="server" ID="produto" class="form-label"/>
    <asp:DropDownList runat="server" ID="ddlproduto" class="form-select" DataTextField="Descricao" DataValueField="Id">         
        
    </asp:DropDownList>

    <asp:Label Text="Quantidade: " runat="server" ID="qtd" AssociatedControlID="qtds" class="form-label"/>
    <asp:TextBox runat="server" ID="qtds" class="form-control"/>  

    <br />    
    <asp:Label runat="server" ID="LabelErro" class="alert-danger"/> 
    <br />
    <asp:Button Text="Adicionar" runat="server" id="Enviar" OnClick="Enviar_Click" class="btn btn-success"/>                

    <br />

    <hr />   
    <h2>Itens da Compra</h2>
    
    <table class="table">
        <thead>
            <tr>
                <th class="col-md-1">#</th>
                <td class="col-md-1">Código</td>
                <th class="col-md-9">Descrição</th>
                <th class="col-md-2">Valor</th>
                <th class="col-md-2">Quantidade</th>
                <th class="col-md-2">SubTotal</th>
            </tr>
        </thead>
        <tbody>                            
        <asp:repeater runat="server" ID="repeaterItens">
            <itemtemplate>
                <tr>
                    <td>
                         <asp:label text='<%# Eval("Id") %>' runat="server" ID="lbCodigo"></asp:label>
                    </td>  
                    <td class="col-md-3">
                        <asp:label text='<%# Eval("CodProduto") %>' runat="server" ID="lbCodProduto"/>
                    </td>
                    <td class="col-md-3">
                        <asp:label text='<%# Eval("nomeProd") %>' runat="server" ID="lbDescricao"/>
                    </td>
                    <td class="col-md-1">
                        <asp:label text='<%# Eval("valorProd") %>' runat="server" ID="lbValor"/>
                    </td>                                                                             
                    <td class="col-md-1">
                        <asp:label text='<%# Eval("Qtd") %>' runat="server" ID="lbQtd"/>  
                    </td>
                    <td class="col-md-2">
                        <asp:label text='<%# Eval("SubTotal") %>' runat="server" ID="lbSubTotal"/>
                    </td>
                </tr>
            </itemtemplate>
        </asp:repeater>
            <tfoot>
                <tr>
                    <td>
                        Valor Total: R$00,00
                    </td>
                    <td>
                        <asp:button text="Finalizar" runat="server" class="btn btn-primary" ID="finalizar" Onclick="finalizar_click"/>
                    </td>
                </tr>
            </tfoot>            
        </tbody>
    </table>          
</asp:Content>
