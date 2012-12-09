<%@ Page Title="<%$ Resources: Strings, CreateQuestionPageTitle %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateQuestion.aspx.cs" Inherits="MoodleQuestions.CreateQuestion" Culture="auto" meta:resourcekey="Page" UICulture="auto" ValidateRequest="false" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2><%= GetGlobalResourceObject("Strings","CreateQuestionPageSubtitle") %></h2>
    </hgroup>
    <asp:PlaceHolder runat="server" ID="ViewPlaceHolder" />
</asp:Content>
