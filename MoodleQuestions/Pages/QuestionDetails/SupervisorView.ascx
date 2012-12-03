<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SupervisorView.ascx.cs" Inherits="MoodleQuestions.Pages.QuestionDetails.SupervisorView" %>

<asp:Table runat="server" ID="QuestionTable">
    <asp:TableRow>
        <asp:TableCell meta:resourcekey="NameCell" />
        <asp:TableCell ID="NameCell">
            <asp:TextBox runat="server" ID="NameTextBox"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell meta:resourcekey="TypeCell" />
        <asp:TableCell ID="TypeCell" />
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell meta:resourcekey="CategoryCell" />
        <asp:TableCell ID="CategoryCell">
            <asp:DropDownList runat="server" ID="CategoryDropDown" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell meta:resourcekey="CreationDateCell" />
        <asp:TableCell ID="CreationDateCell" />
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell meta:resourcekey="AuthorCell" />
        <asp:TableCell ID="AuthorCell" />
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell meta:resourcekey="RatingCell" />
        <asp:TableCell ID="RatingCell">
            <asp:DropDownList runat="server" ID="RatingDropDown">
                <asp:ListItem>-</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:PlaceHolder runat="server" ID="QuestionEditorPlaceHolder" />
<asp:Button runat="server" ID="SaveButton" OnClick="SaveButton_Click" meta:resourcekey="SaveButton"/>
<asp:Button runat="server" ID="CancelButton" PostBackUrl="~/ManageQuestions.aspx" meta:resourcekey="CancelButton"/>
