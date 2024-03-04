<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PokedexWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Bienvenido</h1>
     <%-- listar con foreach --%>
    <div class="row row-cols-1 row-cols-md-3 g-4">
    <%foreach (Dominio.Pokemon pokemon in lista)
        {%>
         <div class="col">
            <div class="card" >
                <img src="<%: pokemon.UrlImagen %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%: pokemon.nombre %></h5>
                    <p class="card-text"><%:pokemon.descripcion %></p>
                    <a href="DetallePokemon.aspx" class="btn btn-primary">VER DETALLE</a>
                </div>
            </div>
        </div>

    <% } %> 
    </div>

</asp:Content>
