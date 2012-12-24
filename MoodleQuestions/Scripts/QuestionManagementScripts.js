$(document).ready(function () {
    $(".questionGrid th input[type=checkbox]").click(function () {

        var checkboxes = $(".questionGrid tr>td>input[type=checkbox]");
        if ($(this).attr("checked")) {
            checkboxes.attr('checked', true);
        }
        else {
            checkboxes.attr('checked', false);
        }
    });
});

function ConfirmCategoryDelete() {

    var answer = confirm("Czy na pewno chcesz usunąć tą kategorię?\nWszystkie pytania należące do tej kategorii zostaną przeniesione do kategorii głównej.")
    if (answer) {
        return true;
    }
    else {
        return false;
    }
};