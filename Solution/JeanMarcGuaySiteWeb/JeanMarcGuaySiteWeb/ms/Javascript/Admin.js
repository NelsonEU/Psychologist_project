!function (t) {
    "use strict"; t("#sidebarToggle").click(function (e) {
        e.preventDefault(), t("body").toggleClass("sidebar-toggled"), t(".sidebar").toggleClass("toggled")
    }), t("body.fixed-nav .sidebar").on("mousewheel DOMMouseScroll wheel", function (e) { if (768 < $window.width()) { var o = e.originalEvent, t = o.wheelDelta || -o.detail; this.scrollTop += 30 * (t < 0 ? 1 : -1), e.preventDefault() } }), t(document).scroll(function () { 100 < t(this).scrollTop() ? t(".scroll-to-top").fadeIn() : t(".scroll-to-top").fadeOut() }), t(document).on("click", "a.scroll-to-top", function (e) { var o = t(this); t("html, body").stop().animate({ scrollTop: t(o.attr("href")).offset().top }, 1e3, "easeInOutExpo"), e.preventDefault() })

}(jQuery);

$(function () {
    $('.btnSuppr').click(function () {
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden";
        confirm_value.name = "confirm_delete";


        if (confirm("Êtes-vous sur de vouloir supprimer cette publication?")) {
            confirm_value.value = "Oui";
        } else {
            confirm_value.value = "Non";
        }
        document.forms[0].appendChild(confirm_value);
    });
});

$(function () {
    $('.btnSupprCategorie').click(function () {
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden";
        confirm_value.name = "confirm_delete";


        if (confirm("Tous les publications associées seront supprimées. Êtes-vous sur de vouloir supprimer cette catégorie? ")) {
            confirm_value.value = "Oui";
        } else {
            confirm_value.value = "Non";
        }
        document.forms[0].appendChild(confirm_value);
    });
});

$('#researchUser').keyup(function () {
    dataTableMaison();
});

$('#researchUser').on('paste', function () {
    dataTableMaison();
})


function dataTableMaison() {
    var val = $('#researchUser').val().toLowerCase();
    val = val.replace(/\s/g, '');
    var regex = new RegExp('\\w*' + val + '\\w*');
    var usersArray = $('#ContentPlaceHolder1_tabUsers tbody tr');
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


function ConfirmerSuppression() {
    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden";
    confirm_value.name = "confirm_delete";
    if (confirm("Êtes-vous sur de vouloir supprimer ces utilisateurs ?")) {
        confirm_value.value = "Oui";
    } else {
        confirm_value.value = "Non";
    }
 
    document.forms[0].appendChild(confirm_value);
}

function ConfirmerDesauthorisation() {
    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden";
    confirm_value.name = "confirm_unauthorized";

    if (confirm("Êtes-vous sur de vouloir désauthoriser ces utilisateurs ?")) {
        confirm_value.value = "Oui";
    } else {
        confirm_value.value = "Non";
    }
    document.forms[0].appendChild(confirm_value);
}



function ConfirmerRDV() {

    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden";
    confirm_value.name = "confirm_rdv";

    if (confirm("Êtes-vous sur de vouloir confirmer ce(s) rendez-vous ?")) {
        confirm_value.value = "Oui";
    } else {
        confirm_value.value = "Non";
    }
    document.forms[0].appendChild(confirm_value);

}

function RefuserRDV() {
    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden";
    confirm_value.name = "refuse_rdv";

    if (confirm("Êtes-vous sur de vouloir refuser ce(s) rendez-vous ?")) {
        confirm_value.value = "Oui";
    } else {
        confirm_value.value = "Non";
    }
    document.forms[0].appendChild(confirm_value);
}

function AnnulerRDV() {
    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden";
    confirm_value.name = "cancel_rdv";

    if (confirm("Êtes-vous sur de vouloir annuler ce(s) rendez-vous ?")) {
        confirm_value.value = "Oui";
    } else {
        confirm_value.value = "Non";
    }
    document.forms[0].appendChild(confirm_value);
}

