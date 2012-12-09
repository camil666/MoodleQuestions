<%@ Page Title="<%$ Resources: Strings, ViewQuestionsPageTitle %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewQuestions.aspx.cs" Inherits="MoodleQuestions.ViewQuestions" Culture="auto" UICulture="auto" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2><%= GetGlobalResourceObject("Strings","ViewQuestionsPageSubtitle") %></h2>
    </hgroup>
    <asp:PlaceHolder runat="server" ID="ViewPlaceHolder" />
</asp:Content>
