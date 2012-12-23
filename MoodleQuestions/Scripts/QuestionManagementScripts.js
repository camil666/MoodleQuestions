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