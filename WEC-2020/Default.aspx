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
          <div class="input-group justify-content-center">
              <div class="input-group-prepend">
                   <asp:Button ID="Btn_Prev" CssClass="btn btn-dark" runat="server" OnClick="Page_Previous" Text="Previous" />
              </div>
              <asp:Button ID="Btn_Current_Page" CssClass="btn btn-dark"  runat="server" Text="" />
              <div class="input-group-append">
                 <asp:Button ID="Btn_Next"  CssClass="btn  btn-dark"  runat="server" OnClick="Page_Next" Text="Next" />
              </div>
        </div>
    </div>
     <div class="row justify-content-center w-100" runat="server">
         <asp:Label  ID="totalResults" runat="server"></asp:Label>
     </div>
     <div class="row justify-content-center w-100" runat="server">
        <ul  class="list-group w-100" runat="server" id="ResultList">
        </ul>
    </div>
</asp:Content>
