<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentView.ascx.cs" Inherits="MoodleQuestions.Pages.QuestionDetails.StudentView" %>

<asp:Table runat="server" ID="QuestionTable">
       <asp:TableRow>
           <asp:TableCell meta:resourcekey="NameCell"/>
           <asp:TableCell ID="NameCell"/>
       </asp:TableRow>
       <asp:TableRow>
           <asp:TableCell meta:resourcekey="CreationDateCell"/>
           <asp:TableCell ID="CreationDateCell"/>
       </asp:TableRow>
       <asp:TableRow>
           <asp:TableCell meta:resourcekey="AuthorCell"/>
           <asp:TableCell ID="AuthorCell"/>
       </asp:TableRow>
       <asp:TableRow>
           <asp:TableCell meta:resourcekey="RatingCell"/>
           <asp:TableCell ID="RatingCell"/>
       </asp:TableRow>
</asp:Table>
<asp:PlaceHolder runat="server" ID="QuestionEditorPlaceHolder" />
<asp:Button runat="server" ID="SaveButton" OnClick="SaveButton_Click" meta:resourcekey="SaveButton"/>
<asp:Button runat="server" ID="CancelButton" PostBackUrl="~/ManageQuestions.aspx" meta:resourcekey="CancelButton"/>