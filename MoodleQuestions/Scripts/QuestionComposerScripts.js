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