function ConfirmDelete() {

    var answer = confirm("Czy jesteś pewien, że chcesz usunąć to pytanie?")
    if (answer) {
        return true;
    }
    else {
        return false;
    }
};