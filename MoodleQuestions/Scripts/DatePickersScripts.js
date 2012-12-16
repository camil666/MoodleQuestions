$(document).ready(function () {
    $.datepicker.setDefaults($.datepicker.regional["pl"]);

    $("#startDateTextBox").datepicker();
    $("#endDateTextBox").datepicker();
});