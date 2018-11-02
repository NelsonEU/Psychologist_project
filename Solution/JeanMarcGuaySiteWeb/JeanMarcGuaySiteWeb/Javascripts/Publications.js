$('#searchPublications').keyup(function () {
    dataTableMaison();
});

$('#searchPublications').on('paste', function () {
    dataTableMaison();
})


function dataTableMaison() {
    var val = $('#searchPublications').val().toLowerCase();
    val = val.replace(/\s/g, '');
    var regex = new RegExp('\\w*' + val + '\\w*');
    var usersArray = $('#ContentPlaceHolder1_tablePublications tbody tr');
    var arrayLength = usersArray.length;
    for (var i = 1; i < arrayLength; i++) {
        var line = usersArray[i].innerText.toLowerCase();
        line = line.replace(/\s/g, '');
        if (i == 1) {
            console.log(line);
        }
        if (!regex.test(line)) {
            usersArray[i].style.display = "none";
        } else {
            usersArray[i].style.display = "table-row";
        }
    }

} 