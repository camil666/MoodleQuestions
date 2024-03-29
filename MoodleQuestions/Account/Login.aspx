﻿<%@ Page Title="<%$ Resources: Strings, LoginPageTitle %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MoodleQuestions.Account.Login" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>
    <section id="loginForm">
        <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="false">
            <LayoutTemplate>
                <p class="validation-summary-errors">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
                <fieldset>
                    <legend>Log in Form</legend>
                    <ol>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="UserName"><%= GetGlobalResourceObject("Strings","LoginLabel") %></asp:Label>
                            <asp:TextBox runat="server" ID="UserName" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="<%$ Resources: Strings, FieldIsRequiredMessage %>" />
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="Password"><%= GetGlobalResourceObject("Strings","PasswordLabel") %></asp:Label>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="<%$ Resources: Strings, FieldIsRequiredMessage %>" />
                        </li>
                        <li>
                            <asp:CheckBox runat="server" ID="RememberMe" />
                            <asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="checkbox"><%= GetGlobalResourceObject("Strings","RememberMeLabel") %></asp:Label>
                        </li>
                    </ol>
                    <asp:Button runat="server" CommandName="Login" Text="<%$ Resources: Strings, LoginText %>" />
                </fieldset>
            </LayoutTemplate>
        </asp:Login>
    </section>

</asp:Content>
