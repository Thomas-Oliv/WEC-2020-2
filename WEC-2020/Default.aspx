<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WEC_2020._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center" runat="server">
        <div class="form-group">
            <div class="input-group">
                    <asp:TextBox ID="SearchQuery" runat="server" CssClass="form-control"></asp:TextBox>
                <div class="input-group-append">
                    <asp:Button runat="server" class="btn btn-block btn-success" Text="Search" OnClick="Search" />
                </div>
            </div>
        </div>
     </div>
    <div class="row justify-content-center" runat="server">
        <ul class="pagination" runat="server" id="Pagination">
          <li class="page-item"><a class="page-link" href="#">Previous</a></li>
            
          <li class="page-item"><a class="page-link" href="#">Next</a></li>
        </ul>
        </div>
     <div class="row justify-content-center w-100" runat="server">
        <ul  class="list-group w-100" runat="server" id="ResultList">
           <!--
                <li  class="list-group-item">
                <div class="row ">
                    <h2 class="font-weight-bold">title</h2>
                </div>
                <div class="row">
                    <a href = "link">link</a>
                </div>
                <div class="row">
                    <h6 class="font-weight-bold">body</h6>
                </div>
            </li>
            <li  class="list-group-item">
                <div class="row ">
                    <h2 class="font-weight-bold">title</h2>
                </div>
                <div class="row">
                    <a href = "link">link</a>
                </div>
                <div class="row">
                    <h6 class="font-weight-bold">body</h6>
                </div>
            </li>
             -->
        </ul>
    </div>
</asp:Content>
