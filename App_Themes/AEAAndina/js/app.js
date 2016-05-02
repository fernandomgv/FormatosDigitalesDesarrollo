/**
 * Project: Bootstrap Hover Dropdown
 * http://cameronspear.com/blog/bootstrap-dropdown-on-hover-plugin/
 */
 (function(e,t,n){var r=e();e.fn.dropdownHover=function(n){if("ontouchstart"in document)return this;r=r.add(this.parent());return this.each(function(){var i=e(this),s=i.parent(),o={delay:500,instantlyCloseOthers:!0},u={delay:e(this).data("delay"),instantlyCloseOthers:e(this).data("close-others")},a="show.bs.dropdown",f="hide.bs.dropdown",l=e.extend(!0,{},o,n,u),c;s.hover(function(e){if(!s.hasClass("open")&&!i.is(e.target))return!0;l.instantlyCloseOthers===!0&&r.removeClass("open");t.clearTimeout(c);s.addClass("open");i.trigger(a)},function(){c=t.setTimeout(function(){s.removeClass("open");i.trigger(f)},l.delay)});i.hover(function(){l.instantlyCloseOthers===!0&&r.removeClass("open");t.clearTimeout(c);s.addClass("open");i.trigger(a)});s.find(".dropdown-submenu").each(function(){var n=e(this),r;n.hover(function(){t.clearTimeout(r);n.children(".dropdown-menu").show();n.siblings().children(".dropdown-menu").hide()},function(){var e=n.children(".dropdown-menu");r=t.setTimeout(function(){e.hide()},l.delay)})})})};e(document).ready(function(){e('[data-hover="dropdown"]').dropdownHover()})})(jQuery,this);

$(function() {
    if ($(window).width() > 991) {
        $('nav .dropdown-toggle').dropdownHover({
            instantlyCloseOthers: false,
            delay: 0
        }).dropdown();
    }
});

 var webApp = function() {
     var urlPageSearch = '';
     var aliasPath = '';
     var urlSubItem = [];

     var eventIni = function() {
         function buscar() {
             var searchText = $("#ctl00_txtSearch").val();
             if (searchText !== '')
                 window.location.href = urlPageSearch + "?search=" + searchText;
         };

         function configuracionMenu() {
             //Reemplazamos la url que no está en el menu, por su correspondiente
             for (var i = 0; i < urlSubItem.length; i++) {
                 if (aliasPath === urlSubItem[i].nodeAlias) {
                     aliasPath = urlSubItem[i].urlMenu;
                     break;
                 }
             }

             var $itemMenu = $(".menu-collapse a[href*='" + aliasPath + ".aspx']").first();

             if ($itemMenu.length > 0) {
                 var $sinSubItem = $itemMenu.closest('li:not(:has(div))');

                 if ($sinSubItem.length > 0) {
                     $sinSubItem.addClass('active');
                     $("#itemTablet")
                         .text($itemMenu.text())
                         .attr("href", $itemMenu.attr("href"))
                         .css("display", "");
                 } else {
                     var $liContent = $itemMenu.closest('li.dropdown');
                     $liContent.addClass('active');
                     $itemMenu.addClass('active');
                     $("#itemTablet")
                         .text($liContent.find("a.dropdown-toggle:first").text())
                         .attr("href", $itemMenu.attr("href"))
                         .css("display", "");
                     $("#subItemTablet")
                         .text($itemMenu.text())
                         .attr("href", $itemMenu.attr("href"))
                         .css("display", "");
                 }
             }

             $("footer a").removeClass('active');
             $("footer a[href*='" + aliasPath + ".aspx']").addClass('active');
         }

         $(document).ready(function() {
             configuracionMenu();

             $('[data-toggle="tooltip"]').tooltip();
             $('#toUp').click(function() {
                 $('body,html').animate({
                     scrollTop: 0
                 }, 1000);
             });
             $(".navbar-toggle").click(function(event) {
                 $("#header-page").toggleClass('openheader');
                 $("body").toggleClass('openbody');
                 $('body,html').animate({
                     scrollTop: 0
                 }, 100);
             });

             // click scroll table
             var scrrollY = $(window).scrollLeft();

             $(".tabs-right").click(function() {
                 var sy = $(this).parents(".tabs-controls").data('scroll');
                 var tselect = $(this).parents(".tabs-controls");
                 scrrollY = $("." + tselect.data('fortabs')).scrollLeft() + sy;
                 $("." + tselect.data('fortabs')).animate({ scrollLeft: scrrollY }, 800);
             });
             $(".tabs-left").click(function() {
                 var sy = $(this).parents(".tabs-controls").data('scroll');
                 var tselect = $(this).parents(".tabs-controls");
                 scrrollY = $("." + tselect.data('fortabs')).scrollLeft() - sy;
                 $("." + tselect.data('fortabs')).animate({ scrollLeft: scrrollY }, 800);
             });

             if ($(window).width() < 767) {
                 $(".slider-nav-fixed").slideUp();
             }

             $("#openMenu").click(function(event) {
                 $(".slider-nav-fixed").slideToggle();
                 $(this).children('i').toggleClass('fa-minus');
             });

             // close alert rop
             $(".close-msg-top").on('click', function(event) {
                 event.preventDefault();
                 $(this).parents(".message-top").slideUp();
                 localStorage.close_true = true;
                 $("body").addClass('body-msg-close');
             });

             if (localStorage.close_true) {
                 $(".message-top").css('display', 'none');
                 $("body").addClass('body-msg-close');
             }

             $('.slide-home').slick({
                 // dots: true,
                 vertical: true,
                 prevArrow: '<i class="slick-up fa fa-chevron-up"></i>',
                 nextArrow: '<i class="slick-down fa fa-chevron-down"></i>',
                 // asNavFor: '.slider-nav',
                 autoplay: true
             });

             $('.slide-gallery-detalle').slick({
                 // dots: true,
                 // vertical:true,
                 prevArrow: '<i class="slick-up fa fa-chevron-up"></i>',
                 nextArrow: '<i class="slick-down fa fa-chevron-down"></i>',
                 asNavFor: '.nav-gallery-detalle',
                 autoplay: true,
                 fade: true
             });

             $('.nav-gallery-detalle').slick({
                 slidesToShow: 10,
                 arrows: false,
                 // centerMode: true,
                 infinite: true,
                 centerPadding: '10px',
                 focusOnSelect: true,
                 asNavFor: '.slide-gallery-detalle',
                 responsive: [
                     {
                         breakpoint: 1200,
                         settings: {
                             slidesToShow: 8
                         }
                     },
                     {
                         breakpoint: 992,
                         settings: {
                             slidesToShow: 6
                         }
                     },
                     {
                         breakpoint: 768,
                         settings: {
                             slidesToShow: 5
                         }
                     },
                     {
                         breakpoint: 560,
                         settings: {
                             slidesToShow: 4
                         }
                     },
                     {
                         breakpoint: 480,
                         settings: {
                             slidesToShow: 3
                         }
                     }
                 ]
             });

             $('.slide-home-galerias').slick({
                 arrows: true,
                 autoplay: true,
                 prevArrow: '<i class="slick-prev fa fa-chevron-left"></i>',
                 nextArrow: '<i class="slick-next fa fa-chevron-right"></i>',
             });
             $('.slide-home-innovacion').slick({
                 autoplay: true,
                 vertical: true,
                 prevArrow: '<i class="slick-up fa fa-chevron-up"></i>',
                 nextArrow: '<i class="slick-down fa fa-chevron-down"></i>',
             });
             $('.slide-detalle-innovacion').slick({
                 autoplay: true,
                 vertical: false,
                 prevArrow: '<i class="slick-up fa fa-chevron-left"></i>',
                 nextArrow: '<i class="slick-down fa fa-chevron-right"></i>',
                 slidesToShow: 3,
                 // fade: true,
                 responsive: [
                     {
                         breakpoint: 992,
                         settings: {
                             slidesToShow: 2
                         }
                     },
                     {
                         breakpoint: 600,
                         settings: {
                             slidesToShow: 1
                         }
                     }
                 ]
             });

             $('.slick-videos').slick({
                 autoplay: true,
                 prevArrow: '<i class="slick-prev fa fa-chevron-left"></i>',
                 nextArrow: '<i class="slick-next fa fa-chevron-right"></i>',
                 slidesToShow: 4,
                 // infinite: true,
                 responsive: [
                     {
                         breakpoint: 992,
                         settings: {
                             slidesToShow: 3
                         }
                     },
                     {
                         breakpoint: 600,
                         settings: {
                             slidesToShow: 2
                         }
                     }
                 ]
             });

             // innovaciones isotope
             var $isotopeP = $('.isotope');
             $isotopeP.imagesLoaded(function () {
                 $isotopeP.masonry({ itemSelector: '.item-is', isAnimated: true, layoutMode: 'masonry' });
             });

             // videopopup
             $('.venobox').venobox({
                 infinigall: true
             });

             $("#btnSearch").click(function(e) {
                 e.preventDefault();
                 buscar();
             });

             $("#txtSearch").keypress(function(e) {
                 if (e.keyCode === 13) {
                     buscar();
                     e.preventDefault();
                 }
             });
         });
     };

     return {
         init: function (parametros) {
             urlPageSearch = parametros.urlPageSearch;
             aliasPath = parametros.aliasPath;
             urlSubItem = parametros.urlSubItem;

             eventIni();
         }
     }
 }();