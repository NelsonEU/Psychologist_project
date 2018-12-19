
$(document).ready(function () {
    $(document).scroll(function () {
        if ($(window).scrollTop() >= 170) {
            $('#mainNav').css('background', '#fff');
            $('.nav-item a').css('color', '#1d6280');            
            $('#mainNav').css('box-shadow', '4px 7px 31px -8px rgba(0,0,0,0.75)');
        } else {
            $('#mainNav').css('background', 'transparent');
            $('.nav-item a').css('color', '#fff');
            $('#mainNav').css('box-shadow', 'inherit');
        }
    });
    $("#tooltipImage").tooltip();
});