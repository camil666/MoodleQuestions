<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuestionComposer.ascx.cs" Inherits="MoodleQuestions.Controls.QuestionComposer" %>
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
<asp:Label runat="server" ID="QuestionContentLabel" meta:resourcekey="QuestionContentLabel"></asp:Label>
<asp:TextBox runat="server" ID="QuestionContentTextBox" TextMode="MultiLine"></asp:TextBox>
<br />
<asp:PlaceHolder runat="server" ID="AnswersPlaceHolder"></asp:PlaceHolder>
