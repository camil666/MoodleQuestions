<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageQuestions.aspx.cs" Inherits="MoodleQuestions.ManageQuestions" Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Manage questions page.</h2>
    </hgroup>
    <asp:PlaceHolder runat="server" ID="UserDropDownPlaceHolder"></asp:PlaceHolder>
    <asp:GridView runat="server" ID="QuestionGridView" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" Visible="false" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="CreationDate" HeaderText="Creation Date" />
            <asp:BoundField DataField="Rating" HeaderText="Rating" />
            <asp:HyperLinkField HeaderText="Details" Text="Details" datanavigateurlfields="Id" datanavigateurlformatstring="QuestionDetails.aspx?q={0}"/>
            <asp:CommandField ButtonType="Image" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>

    <%--<asp:PlaceHolder runat="server" ID="AnswersPlaceHolder"></asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="ButtonsPlaceHolder">
        <asp:Button runat="server" ID="GenerateXMLButton" OnClick="GenerateXMLButton_Click" meta:resourcekey="GenerateXMLButton"></asp:Button>
    </asp:PlaceHolder>--%>
</asp:Content>
