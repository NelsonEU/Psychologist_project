!function (t) {
    "use strict"; t("#sidebarToggle").click(function (e) {
        e.preventDefault(), t("body").toggleClass("sidebar-toggled"), t(".sidebar").toggleClass("toggled")
    }), t("body.fixed-nav .sidebar").on("mousewheel DOMMouseScroll wheel", function (e) { if (768 < $window.width()) { var o = e.originalEvent, t = o.wheelDelta || -o.detail; this.scrollTop += 30 * (t < 0 ? 1 : -1), e.preventDefault() } }), t(document).scroll(function () { 100 < t(this).scrollTop() ? t(".scroll-to-top").fadeIn() : t(".scroll-to-top").fadeOut() }), t(document).on("click", "a.scroll-to-top", function (e) { var o = t(this); t("html, body").stop().animate({ scrollTop: t(o.attr("href")).offset().top }, 1e3, "easeInOutExpo"), e.preventDefault() })
}(jQuery);

$(document).ready(function () {
    $('#ContentPlaceHolder1_tabUsers').DataTable();
})


$('#researchUser').keydown(function () {
    dataTableMaison();
});

$('#researchUser').on('paste', function () {
    dataTableMaison();
})


function dataTableMaison() {

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
