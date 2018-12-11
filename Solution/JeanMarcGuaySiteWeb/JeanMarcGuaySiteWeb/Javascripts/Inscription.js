$(function () {
    $("#birthday").datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange:  '-100:+0',
        closeText: 'Fermer',
        prevText: 'Précédent',
        nextText: 'Suivant',
        currentText: 'Aujourd\'hui',
        monthNames: ['Janvier', 'Février', 'Mars', 'Avril', 'Mai', 'Juin', 'Juillet', 'Août', 'Septembre', 'Octobre', 'Novembre', 'Décembre'],
        monthNamesShort: ['Janv.', 'Févr.', 'Mars', 'Avril', 'Mai', 'Juin', 'Juil.', 'Août', 'Sept.', 'Oct.', 'Nov.', 'Déc.'],
        dayNames: ['Dimanche', 'Lundi', 'Mardi', 'Mercredi', 'Jeudi', 'Vendredi', 'Samedi'],
        dayNamesShort: ['Dim.', 'Lun.', 'Mar.', 'Mer.', 'Jeu.', 'Ven.', 'Sam.'],
        dayNamesMin: ['D', 'L', 'M', 'M', 'J', 'V', 'S'],
        weekHeader: 'Sem.',
        dateFormat: 'dd-mm-yy'
    }).attr('readonly', 'true');
    
    
});


$(function () {
    $('#bntSuppr').click(function () {
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden";
        confirm_value.name = "confirm_delete";


        if (confirm("Cette action effectuera une demande de suppression définitive de votre compte et tous les informations associées. Voulez-vous continuer?")) {
            confirm_value.value = "Oui";
        } else {
            confirm_value.value = "Non";
        }
        document.forms[0].appendChild(confirm_value);
    });
});