﻿<%@ Page Title="<%$ Resources: Strings, AccountManagePageTitle %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="MoodleQuestions.Account.Manage" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>

    <section id="passwordForm">
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="message-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>

        <p><%= GetGlobalResourceObject("Strings","LoggedInAsMessage") %> <strong><%: User.Identity.Name %></strong>.</p>

        <asp:PlaceHolder runat="server" ID="changeName">
            <h2><%= GetGlobalResourceObject("Strings","ChangeNameHeader") %></h2>
            <br />
            <asp:Label runat="server" AssociatedControlID="FirstName"><%= GetGlobalResourceObject("Strings","FirstNameLabel") %></asp:Label>
            <asp:TextBox runat="server" ID="FirstName" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                CssClass="field-validation-error" ErrorMessage="<%$ Resources: Strings, FieldIsRequiredMessage %>"
                ValidationGroup="ChangeName" />

            <asp:Label runat="server" AssociatedControlID="LastName"><%= GetGlobalResourceObject("Strings","LastNameLabel") %></asp:Label>
            <asp:TextBox runat="server" ID="LastName" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
                CssClass="field-validation-error" ErrorMessage="<%$ Resources: Strings, FieldIsRequiredMessage %>"
                ValidationGroup="ChangeName" />
            <br />
            <br />
            <asp:Button runat="server" OnClick="NameChange_Click" Text="<%$ Resources: Strings, ChangeNameButtonText %>" ValidationGroup="ChangeName" />
        </asp:PlaceHolder>

        <asp:PlaceHolder runat="server" ID="changePassword">
            <h2><%= GetGlobalResourceObject("Strings","ChangePasswordHeader") %></h2>
            <asp:ChangePassword runat="server" CancelDestinationPageUrl="~/" ViewStateMode="Disabled" RenderOuterTable="false" SuccessPageUrl="Manage.aspx?m=ChangePwdSuccess">
                <ChangePasswordTemplate>
                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                    <fieldset class="changePassword">
                        <legend>Change password details</legend>
                        <ol>
                            <li>
                                <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword"><%= GetGlobalResourceObject("Strings","CurrentPasswordLabel") %></asp:Label>
                                <asp:TextBox runat="server" ID="CurrentPassword" CssClass="passwordEntry" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                                    CssClass="field-validation-error" ErrorMessage="<%$ Resources: Strings, FieldIsRequiredMessage %>"
                                    ValidationGroup="ChangePassword" />
                            </li>
                            <li>
                                <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword"><%= GetGlobalResourceObject("Strings","NewPasswordLabel") %></asp:Label>
                                <asp:TextBox runat="server" ID="NewPassword" CssClass="passwordEntry" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                                    CssClass="field-validation-error" ErrorMessage="<%$ Resources: Strings, FieldIsRequiredMessage %>"
                                    ValidationGroup="ChangePassword" />
                            </li>
                            <li>
                                <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword"><%= GetGlobalResourceObject("Strings","ConfirmNewPasswordLabel") %></asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmNewPassword" CssClass="passwordEntry" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword"
                                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="<%$ Resources: Strings, FieldIsRequiredMessage %>"
                                    ValidationGroup="ChangePassword" />
                                <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="<%$ Resources: Strings, PasswordConfimrationIsWrongMessage %>"
                                    ValidationGroup="ChangePassword" />
                            </li>
                        </ol>
                        <asp:Button runat="server" CommandName="ChangePassword" Text="<%$ Resources: Strings, ChangePasswordButtonText %>" ValidationGroup="ChangePassword" />
                    </fieldset>
                </ChangePasswordTemplate>
            </asp:ChangePassword>
        </asp:PlaceHolder>
    </section>
</asp:Content>
