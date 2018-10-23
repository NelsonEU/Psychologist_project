
$(document).ready(function () {
    // hide our element on page load
    $('#h2Apropo').css('opacity', 0);
    $('#h2Approche').css('opacity', 0);
    $('.animatedWA').css('opacity', 0);
    $('#btnAnimated').css('opacity', 0);
    $('.animatedWA').css("animation-delay", "500ms");
    $('.divAnimation1').css("animation-delay", "1s");

    $('#h2Apropos').addClass('animated');
    $('#h2Apropos').addClass('slow');
    $('h2Apropos').css("animation-delay", "500ms");

    $('.divAnimation1').addClass('animated');
    $('.divAnimation1').addClass('slow');
    $('.divAnimation1').addClass('delay-1s');

    $('#h2Publications').css('opacity', 0);
    $('#h2Publications').addClass('animated');
    $('#h2Publications').addClass('slow');

    $('#carouselCategories').css('opacity', 0);
    $('#carouselCategories').addClass('animated');
    $('#carouselCategories').addClass('slow');
    $('#carouselCategories').css("animation-delay", "500ms");

    $('.banner').waypoint(function () {
        $('#h2Apropos').addClass('fadeInRight');
        $('.divAnimation1').addClass('fadeInUp');
    }, { offset: '50%' });

    $('#pTrigger').waypoint(function () {
        $('#h2Approche').addClass('fadeInRight');
        $('.animatedWA').addClass('fadeInRight');
    }, { offset: '50%' });

    //$('#btnTrigger').waypoint(function () {
    //    $('.animatedWA').addClass('fadeInRight');
    //}, { offset: '50%' });

    $('#divTrigger').waypoint(function () {
        $('#btnAnimated').addClass('fadeInRight');
    }, { offset: '50%' });

    $('#btnEnSavoirPlus').waypoint(function () {
        $('#h2Publications').addClass('fadeInRight');
        $('#carouselCategories').addClass('fadeInRight');
    }, { offset: '50%' });

    //$('#h2Publications').waypoint(function () {
    //    $('#carouselCategories').addClass('fadeInRight');
    //}, { offset: '50%' });

});