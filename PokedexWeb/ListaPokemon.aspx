<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaPokemon.aspx.cs" Inherits="PokedexWeb.ListaPokemon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista Pokemon</h1>
    <asp:GridView ID="dgvPokemons" runat="server" CssClass="table" AutoGenerateColumns="false" DataKeyNames="id" 
        OnPageIndexChanging="dgvPokemons_PageIndexChanging"
         PageSize="5" AllowPaging="true" 
        OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Numero" DataField="numero" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Tipo" DataField="tipo.descripcion" />
            <asp:BoundField HeaderText="Debilidad" DataField="debilidad.descripcion" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="editar"/>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnAgregar" runat="server" Text="AGREGAR" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
</asp:Content>
