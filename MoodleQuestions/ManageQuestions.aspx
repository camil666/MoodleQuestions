<%@ Page Title="<%$ Resources: Strings, ManageQuestionsPageTitle %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageQuestions.aspx.cs" Inherits="MoodleQuestions.ManageQuestions" Culture="auto" UICulture="auto" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2><%= GetGlobalResourceObject("Strings","ManageQuestionsPageSubtitle") %></h2>
    </hgroup>
    <asp:PlaceHolder runat="server" ID="ViewPlaceHolder" />
</asp:Content>
