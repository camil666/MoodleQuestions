<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateQuestion.aspx.cs" Inherits="MoodleQuestions.CreateQuestion" Culture="auto" meta:resourcekey="Page" UICulture="auto" ValidateRequest="false" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="Scripts/tiny_mce/tiny_mce.js"></script>
    <script type="text/javascript">
        tinyMCE.init({
            // General options 
            mode: "textareas",
            theme: "advanced",
            plugins: "pagebreak,table,advhr,iespell,inlinepopups,contextmenu,directionality,noneditable,visualchars,nonbreaking,xhtmlxtras,advlist",
            // Theme options 
            theme_advanced_buttons1: "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,fontsizeselect",
            theme_advanced_buttons2: "bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,forecolor,backcolor",
            theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            theme_advanced_statusbar_location: "bottom"
        });

        var Answers = {
            ParseFraction: function (value) {
                var parsedFraction = parseFloat(value.replace(",", "."));
                return parsedFraction;
            },

            ValidateSum: function (sender, args) {
                args.IsValid = true;
                var fractionTextBoxes = $("select.FractionDropDown");
                var sum = 0;
                fractionTextBoxes.each(function (index, element) {
                    var fraction = Answers.ParseFraction(element.value);
                    if (!isNaN(fraction)) {
                        if (fraction > 0) {
                            sum += fraction;
                            if (sum > 100) {
                                args.IsValid = false;
                                return;
                            }
                        }
                    }
                });

                if (sum < 99.8) {
                    args.IsValid = false;
                    return;
                }
            }
        }
    </script>

    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Question creation page.</h2>
    </hgroup>

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
    <asp:Label runat="server" ID="QuestionContentLabel" meta:resourcekey="QuestionContentLabel"></asp:Label>
    <asp:TextBox runat="server" ID="QuestionContentTextBox" TextMode="MultiLine"></asp:TextBox>
    <br />
    <asp:PlaceHolder runat="server" ID="AnswersPlaceHolder"></asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="ButtonsPlaceHolder">
        <asp:Button runat="server" ID="GenerateXMLButton" OnClick="GenerateXMLButton_Click" meta:resourcekey="GenerateXMLButton"></asp:Button>
    </asp:PlaceHolder>
    <asp:CustomValidator runat="server" ClientValidationFunction="Answers.ValidateSum" Display="Dynamic" meta:resourcekey="SumValidator"></asp:CustomValidator>
</asp:Content>
