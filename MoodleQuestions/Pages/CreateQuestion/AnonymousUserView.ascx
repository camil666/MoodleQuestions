<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AnonymousUserView.ascx.cs" Inherits="MoodleQuestions.Pages.CreateQuestion.AnonymousUserView" %>

<asp:Label runat="server" ID="AnswerCountLabel" meta:resourcekey="AnswerCountLabel"></asp:Label>
    <asp:DropDownList runat="server" ID="AnswerCountDropDown" AutoPostBack="True" meta:resourcekey="AnswerCountDropDown">
        <asp:ListItem Value="2">2</asp:ListItem>
        <asp:ListItem Value="3">3</asp:ListItem>
        <asp:ListItem Selected="True" Value="4">4</asp:ListItem>
        <asp:ListItem Value="5">5</asp:ListItem>
        <asp:ListItem Value="6">6</asp:ListItem>
        <asp:ListItem Value="7">7</asp:ListItem>
        <asp:ListItem Value="8">8</asp:ListItem>
        <asp:ListItem Value="9">9</asp:ListItem>
        <asp:ListItem Value="10">10</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:PlaceHolder runat="server" ID="QuestionComposerPlaceHolder"></asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="ButtonsPlaceHolder">
        <asp:Button runat="server" ID="GenerateXMLButton" OnClick="GenerateXMLButton_Click" meta:resourcekey="GenerateXMLButton"></asp:Button>
    </asp:PlaceHolder>
    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="Answers.ValidateSum" Display="Dynamic" meta:resourcekey="SumValidator"></asp:CustomValidator>