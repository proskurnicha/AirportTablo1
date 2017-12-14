//console.log('userID', userID);
$(document).ready(function () {
    $(".print-btn").on("click", function () {
        printPage();
    });

    function printPage() {
        window.print();
    }
});