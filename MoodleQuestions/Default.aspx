<%@ Page Title="<%$ Resources: Strings, HomePageTitle %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MoodleQuestions._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2><%= GetGlobalResourceObject("Strings","HomePageSubtitle") %></h2>
            </hgroup>
            <p><%= GetGlobalResourceObject("Strings","HomePageDescription") %></p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3><%= GetGlobalResourceObject("Strings","HomePageInstructions") %></h3>
</asp:Content>
