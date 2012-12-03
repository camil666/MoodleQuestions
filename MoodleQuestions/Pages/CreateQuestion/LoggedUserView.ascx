<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoggedUserView.ascx.cs" Inherits="MoodleQuestions.Pages.CreateQuestion.LoggedUserView" %>
<%@ Register Src="~/Pages/CreateQuestion/AnonymousUserView.ascx" TagPrefix="uc" TagName="AnonymousUserView" %>

<uc:AnonymousUserView runat="server" id="AnonymousUserView" />
<asp:Button runat="server" ID="SaveQuestionButton" OnClick="SaveQuestionButton_Click" meta:resourcekey="SaveQuestionButton" />