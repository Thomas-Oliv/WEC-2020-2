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
      
    </div>
</asp:Content>
