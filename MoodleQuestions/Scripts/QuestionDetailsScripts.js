function ConfirmDelete() {

    var answer = confirm("Czy chcesz usunąć to pytanie?")
    if (answer) {
        return true;
    }
    else {
        return false;
    }
};