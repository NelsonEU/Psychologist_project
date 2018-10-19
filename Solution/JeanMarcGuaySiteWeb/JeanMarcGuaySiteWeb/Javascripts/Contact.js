$(function () {

    $('#characters').text('0');
    $('#txtContent').keyup(updateCount);
    $('#txtContent').keydown(updateCount);
    
    function updateCount() {
        var cs = $(this).val().length;
        if (cs > 500) {
            $('#characters').css("color","red")
        } else {
            $('#characters').css("color", "black")
        }
        $('#characters').text(cs);
    }
});
