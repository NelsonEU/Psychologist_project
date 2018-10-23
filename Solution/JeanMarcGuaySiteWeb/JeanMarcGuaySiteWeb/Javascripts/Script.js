$(document).ready(function () {

    // hide our element on page load
    $('.underline1').css('opacity', 0);
    $('#h2Approche').css('opacity', 0);
    $('.animatedWA').css('opacity', 0);
    $('#btnAnimated').css('opacity', 0);

    $('.underline1').addClass('animated');
    //$('.underline1').addClass('fadeInRight');
    $('.underline1').addClass('slow');
    $('.underline1').addClass('delay-1s');
    $('.divAnimation1').addClass('animated');
    //$('.divAnimation1').addClass('fadeInUp');
    $('.divAnimation1').addClass('slow');
    $('.divAnimation1').addClass('delay-1s');

    $('.banner').waypoint(function () {
        $('.underline1').addClass('fadeInRight');
        $('.divAnimation1').addClass('fadeInUp');
    }, { offset: '50%' });

    $('#pTrigger').waypoint(function () {
        $('#h2Approche').addClass('fadeInRight');
    }, { offset: '50%' });

    $('#btnTrigger').waypoint(function () {
        $('.animatedWA').addClass('fadeInRight');
    }, { offset: '50%' });

    $('#divTrigger').waypoint(function () {
        $('#btnAnimated').addClass('fadeInRight');
    }, { offset: '50%' });


});