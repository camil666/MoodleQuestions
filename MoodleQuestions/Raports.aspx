<%@ Page Title="<%$ Resources: Strings, RaportsPageTitle %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Raports.aspx.cs" Inherits="MoodleQuestions.Raports" Culture="auto" UICulture="auto" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2><%= GetGlobalResourceObject("Strings","RaportsPageSubtitle") %></h2>
    </hgroup>
    <asp:PlaceHolder runat="server" ID="ViewPlaceHolder" />
</asp:Content>
