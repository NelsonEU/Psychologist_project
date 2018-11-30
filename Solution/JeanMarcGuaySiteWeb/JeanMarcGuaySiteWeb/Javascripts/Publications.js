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
    var divs = $('#ContentPlaceHolder1_publicationsPortfolio').children();
    var divsNb = divs.length;
    for (var i = 0; i < divsNb; i++) {
        var titre = divs[i].children[0].children[0].textContent.toLowerCase();
        titre = titre.replace(/\s/g, '');
        if (!regex.test(titre)) {
            divs[i].style.display = "none";
        } else {
            divs[i].style.display = "initial";
        }
    }

} 
