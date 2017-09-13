<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication8.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Username1" runat="server" Visible="false" ForeColor="#9d9d9d"></asp:Label>
    <a href="../LogOut.aspx">Log Out</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    Welcome to the Home Page!
</asp:Content>
