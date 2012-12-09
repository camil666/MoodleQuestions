<%@ Page Title="<%$ Resources: Strings, RegisterPageTitle %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MoodleQuestions.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2><%= GetGlobalResourceObject("Strings","RegisterPageSubtitle") %></h2>
    </hgroup>

    <asp:CreateUserWizard runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder" />
            <asp:PlaceHolder runat="server" ID="navigationPlaceholder" />
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" ID="RegisterUserWizardStep">
                <ContentTemplate>
                    <p class="message-info">
                        <%= GetGlobalResourceObject("Strings","MinimumPasswordLengthText") %>
                    </p>

                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>

                    <fieldset>
                        <legend>Registration Form</legend>
                        <ol>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="UserName"><%= GetGlobalResourceObject("Strings","LoginLabel") %></asp:Label>
                                <asp:TextBox runat="server" ID="UserName" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                    CssClass="field-validation-error" ErrorMessage="<%$ Resources: Strings, FieldIsRequiredMessage %>" />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="FirstName"><%= GetGlobalResourceObject("Strings","FirstNameLabel") %></asp:Label>
                                <asp:TextBox runat="server" ID="FirstName" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                                    CssClass="field-validation-error" ErrorMessage="<%$ Resources: Strings, FieldIsRequiredMessage %>" />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="LastName"><%= GetGlobalResourceObject("Strings","LastNameLabel") %></asp:Label>
                                <asp:TextBox runat="server" ID="LastName" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
                                    CssClass="field-validation-error" ErrorMessage="<%$ Resources: Strings, FieldIsRequiredMessage %>" />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="Email"><%= GetGlobalResourceObject("Strings","EmailLabel") %></asp:Label>
                                <asp:TextBox runat="server" ID="Email" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                    CssClass="field-validation-error" ErrorMessage="<%$ Resources: Strings, FieldIsRequiredMessage %>" />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="Password"><%= GetGlobalResourceObject("Strings","PasswordLabel") %></asp:Label>
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                    CssClass="field-validation-error" ErrorMessage="<%$ Resources: Strings, FieldIsRequiredMessage %>" />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="ConfirmPassword"><%= GetGlobalResourceObject("Strings","ConfirmPasswordLabel") %></asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="<%$ Resources: Strings, FieldIsRequiredMessage %>" />
                                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="<%$ Resources: Strings, PasswordConfimrationIsWrongMessage %>" />
                            </li>
                        </ol>
                        <asp:Button runat="server" CommandName="MoveNext" Text="<%$ Resources: Strings, RegisterButtonText %>" />
                    </fieldset>
                </ContentTemplate>
                <CustomNavigationTemplate />
            </asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>