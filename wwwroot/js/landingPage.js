////////////////////////////////////
// SMOOTH SCROLLING WITH NAV HEIGHT OFFSET

$(function () {
    var navHeight = $("nav").outerHeight();
    $('a[href*="#"]:not([href="#"])').click(function () {
        if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
            if (target.length) {
                $('html, body').animate({
                    scrollTop: target.offset().top - navHeight
                }, 1000);
                return false;
            }
        }
    });
});

////////////////////////////////////
// NAVIGATION STICKY

var viewHeight = $(window).height();
var navigation = $('nav');

$(window).scroll(function () {
    if ($(window).scrollTop() > (viewHeight - 175)) { //edit for nav height
        navigation.addClass('sticky');
    } else {
        navigation.removeClass('sticky');
    }
});

