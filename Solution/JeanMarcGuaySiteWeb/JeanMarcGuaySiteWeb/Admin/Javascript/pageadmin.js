$(function () {
    
    $('#divDispo').click(function () {
        document.location.replace('AvailabilityManagement.aspx');
    });

    $('#divRDV').click(function () {
        document.location.replace('AppointmentManagement.aspx');
    });

    $('#divPubli').click(function () {
        document.location.replace('DocumentManagement.aspx');
    });

    $('#divContact').click(function () {
        document.location.replace('RequestManagement.aspx');
    });

    $('#divUtili').click(function () {
        document.location.replace('UserManagement.aspx');
    });

    $('#divModules').click(function () {
        document.location.replace('ModuleManagement.aspx');
    });
});
