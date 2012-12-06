<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuestionDetails.aspx.cs" Inherits="MoodleQuestions.QuestionDetails" culture="auto" meta:resourcekey="Page" uiculture="auto" ValidateRequest="false" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Question Details.</h2>
    </hgroup>
   <asp:PlaceHolder runat="server" ID="ViewPlaceHolder" />
</asp:Content>
