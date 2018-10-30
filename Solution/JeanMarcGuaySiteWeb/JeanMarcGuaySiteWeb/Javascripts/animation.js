$(document).ready(function () {
    // hide our element on page load
    $('#h2Apropo').css('opacity', 0);
    //$('#h2Approche').css('opacity', 0);
    //$('.animatedWA').css('opacity', 0);
    //$('#btnAnimated').css('opacity', 0);
    $('.divAnimation3').css('opacity', 0);
    $('#divAnimationbcBlue').css('opacity', 0);
    $('#divAnimationbcBlueHead').css('opacity', 0);
    $('#PremiereRencontreHead').css('opacity', 0);
    $('#premiereRencontre').css('opacity', 0);
    //$('.animatedWA').css("animation-delay", "500ms");
    //$('.divAnimation1').css("animation-delay", "1s");

    $('#h2Apropos').addClass('animated');
    $('#h2Apropos').addClass('slow');
    $('h2Apropos').css("animation-delay", "500ms");

    $('.divAnimation1').addClass('animated');
    $('.divAnimation1').addClass('slow');
    $('.divAnimation1').addClass('delay-1s');

    $('.divAnimation2').addClass('animated');
    $('.divAnimation2').addClass('slow');

    $('.divAnimation4').addClass('animated');
    $('.divAnimation4').addClass('slow');

    $('.divAnimation5').addClass('animated');
    $('.divAnimation5').addClass('slow');

    $('.divAnimation6').addClass('animated');
    $('.divAnimation6').addClass('slow');

    $('#h2Publications').css('opacity', 0);

    //$('#carouselCategories').css('opacity', 0);
    $('#carouselCategories').addClass('animated');
    $('#carouselCategories').addClass('slow');
    $('#carouselCategories').css("animation-delay", "500ms");

    $('.banner').waypoint(function () {
        $('#h2Apropos').addClass('fadeInRight');
        $('.divAnimation1').addClass('fadeInUp');
    }, { offset: '50%' });

    $('.banner2').waypoint(function () {
        $('#h2Apropos').addClass('fadeInRight');
        $('.divAnimation2').addClass('fadeInUp');
    }, { offset: '50%' });

    $('#pTrigger').waypoint(function () {
        $('#h2Approche').addClass('fadeInRight');
        $('.animatedWA').addClass('fadeInRight');
    }, { offset: '50%' });

    $('#paraTrigger').waypoint(function () {
        $('.divAnimation3').css('opacity', 100);
        $('.divAnimation3').addClass('fadeInRight');
    }, { offset: '50%' });

    $('#paraTrigger2').waypoint(function () {
        $('.divAnimation4').css('opacity', 100);
        $('.divAnimation4').addClass('fadeInRight');

        $('.divAnimation5').css('opacity', 100);
        $('.divAnimation5').addClass('fadeInLeft');
    }, { offset: '50%' });

    $('#triggerAnimationbcblue').waypoint(function () {
        $('#divAnimationbcBlue').css('opacity', 100);
        $('#divAnimationbcBlue').addClass('fadeInRight');
    }, { offset: '50%' });

    $('#triggerAnimationbcblueHead').waypoint(function () {
        $('#divAnimationbcBlueHead').css('opacity', 100);
        $('#divAnimationbcBlueHead').addClass('fadeInRight');
    }, { offset: '50%' });

    $('#divTrigger').waypoint(function () {
        $('#btnAnimated').addClass('fadeInRight');
    }, { offset: '50%' });

    $('#triggerAnimationCarousel').waypoint(function () {
        $('#h2Publications').addClass('fadeInRight');
        $('#carouselCategories').addClass('fadeInRight');
    }, { offset: '50%' });

    $('#triggerPremiereRencontreHead').waypoint(function () {
        $('#PremiereRencontreHead').addClass('fadeInRight');
        $('#PremiereRencontreHead').addClass('fadeInRight');
    }, { offset: '50%' });

    $('#triggerPremiereRencontre').waypoint(function () {
        $('#premiereRencontre').css('opacity', 100);
        $('#premiereRencontre').addClass('fadeInRight');
    }, { offset: '50%' });

    $('#evenBiggerBox').mouseover(function () {
        $('.sq').css("border-radius", "8px");
        $('.square1').css("background-color", "#fe0034");
        $('.square2').css("background-color", "#ffff00");
        $('.square3').css("background-color", "#4cb535");
        $('.square4').css("background-color", "#34a9b3");
        $('.square5').css("background-color", "#f4bc11");
        $('.square6').css("background-color", "#8d37bc");
    });

    $('#evenBiggerBox').mouseout(function () {
        $('.square1').css("background-color", "white");
        $('.square2').css("background-color", "white");
        $('.square3').css("background-color", "white");
        $('.square4').css("background-color", "white");
        $('.square5').css("background-color", "white");
        $('.square6').css("background-color", "white");

    });

});