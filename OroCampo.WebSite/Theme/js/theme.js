;(function($) {
    "use strict";
    
    
    var navbar=$('.header_menu, .middle_menu_area, .header_white_menu');
    var nav_offset_top = $('.header_menu, .middle_menu_area, .header_white_menu').offset().top + 60;
    /*-------------------------------------------------------------------------------
	  Navbar 
	-------------------------------------------------------------------------------*/

	navbar.affix({
	  offset: {
	    top: nav_offset_top,
	  }
	});


	navbar.on('affix.bs.affix', function() {
		if (!navbar.hasClass('affix')){
			navbar.addClass('animated slideInDown');
		}
	});

	navbar.on('affixed-top.bs.affix', function() {
	  	navbar.removeClass('animated slideInDown');
	  	
	});
    
    /*------- search form js -------*/
    $('.search_dropdown a').on('click', function(){
        if( $(this).parent().hasClass('open') ){
            $(this).parent().removeClass('open')
        }
        else{
            $(this).parent().addClass('open')
            $('.offcanvas_closer').addClass('show')
        }
        return false
    });
    
    
//    var navbar2=$('.middle_menu_area');
//    /*-------------------------------------------------------------------------------
//	  Navbar 
//	-------------------------------------------------------------------------------*/
//
//	navbar2.affix({
//	  offset: {
//	    top: 1,
//	  }
//	});
//
//
//	navbar2.on('affix.bs.affix', function() {
//		if (!navbar2.hasClass('affix')){
//			navbar2.addClass('animated slideInDown');
//			$('body').addClass('fixed');
//		}
//	});
//
//	navbar2.on('affixed-top.bs.affix', function() {
//	  	navbar2.removeClass('animated slideInDown');
//        $('body').removeClass('fixed');
//	  	
//	});
    
    // stick menu function
    
//    var nav_offset_top = $('.header_menu').offset().top;
//    
//    if ( nav_offset_top == 0 ){
//        nav_offset_top = 1
//    }
//    
//    $('.header_menu').affix({
//        offset: {
//            top: nav_offset_top,
//        }
//    });
    
    
    /*----------------------------------------------------*/
    /*  Main Slider js
    /*----------------------------------------------------*/
    function main_slider(){
        if ( $('#main_slider').length ){
            $("#main_slider").revolution({
                sliderType:"standard",
                sliderLayout:"auto",
                delay:4000,
                disableProgressBar:"on",
                navigation: {
                    onHoverStop: 'off',
                    touch:{
                        touchenabled:"on"
                    },
                    arrows: {
                        style:"zeus",
                        enable:true,
                        hide_onmobile:true,
                        hide_under:767,
                        hide_onleave:true,
                        hide_delay:200,
                        hide_delay_mobile:1200,
                        tmp:'<div class="tp-title-wrap">  	<div class="tp-arr-imgholder"></div> </div>',
                        left: {
                            h_align: "left",
                            v_align: "center",
                            h_offset: 50,
                            v_offset: 0
                        },
                        right: {
                            h_align: "right",
                            v_align: "center",
                            h_offset: 50,
                            v_offset: 0
                        }
                    },
                },
                responsiveLevels:[4096,1199,992,767,480],
                gridwidth:[1170,1000,750,700,300],
                gridheight:[760,760,760,600,500],
                lazyType:"smart",
                fallbacks: {
                    simplifyAll:"off",
                    nextSlideOnWindowFocus:"off",
                    disableFocusListener:false,
                }
            })
        }
    }
    main_slider();
    
    /*----------------------------------------------------*/
    /*  Main Slider js
    /*----------------------------------------------------*/
    function main_slider3(){
        if ( $('#main_slider3').length ){
            $("#main_slider3").revolution({
                sliderType:"fullwidth",
                sliderLayout:"auto",
                delay:4000,
                disableProgressBar:"on",
                navigation: {
                    onHoverStop: 'off',
                    touch:{
                        touchenabled:"on"
                    },
                    arrows: {
                        style:"zeus",
                        enable:true,
                        hide_onmobile:true,
                        hide_under:767,
                        hide_onleave:true,
                        hide_delay:200,
                        hide_delay_mobile:1200,
                        tmp:'<div class="tp-title-wrap">  	<div class="tp-arr-imgholder"></div> </div>',
                        left: {
                            h_align: "left",
                            v_align: "center",
                            h_offset: 50,
                            v_offset: 0
                        },
                        right: {
                            h_align: "right",
                            v_align: "center",
                            h_offset: 50,
                            v_offset: 0
                        }
                    },
                },
                responsiveLevels:[4096,1199,992,767,480],
                gridwidth:[1170,1000,750,700,300],
                gridheight:[655,655,760,600,500],
                lazyType:"smart",
                fallbacks: {
                    simplifyAll:"off",
                    nextSlideOnWindowFocus:"off",
                    disableFocusListener:false,
                }
            })
        }
    }
    main_slider3();
    
    /*----------------------------------------------------*/
    /*  Main Slider js
    /*----------------------------------------------------*/
    function main_slider4(){
        if ( $('#main_slider4').length ){
            $("#main_slider4").revolution({
                sliderType:"fullwidth",
                sliderLayout:"auto",
                delay:4000,
                disableProgressBar:"on",
                navigation: {
                    onHoverStop: 'off',
                    touch:{
                        touchenabled:"on"
                    },
                    arrows: {
                        style:"zeus",
                        enable:true,
                        hide_onmobile:true,
                        hide_under:767,
                        hide_onleave:true,
                        hide_delay:200,
                        hide_delay_mobile:1200,
                        tmp:'<div class="tp-title-wrap">  	<div class="tp-arr-imgholder"></div> </div>',
                        left: {
                            h_align: "left",
                            v_align: "center",
                            h_offset: 50,
                            v_offset: 0
                        },
                        right: {
                            h_align: "right",
                            v_align: "center",
                            h_offset: 50,
                            v_offset: 0
                        }
                    },
                },
                responsiveLevels:[4096,1199,992,767,480],
                gridwidth:[1170,1000,750,700,300],
                gridheight:[680,680,760,600,500],
                lazyType:"smart",
                fallbacks: {
                    simplifyAll:"off",
                    nextSlideOnWindowFocus:"off",
                    disableFocusListener:false,
                }
            })
        }
    }
    main_slider4();
    
    /*----------------------------------------------------*/
    /*  Main Slider js
    /*----------------------------------------------------*/
    function main_slider5(){
        if ( $('#main_slider5').length ){
            $("#main_slider5").revolution({
                sliderType:"fullwidth",
                sliderLayout:"auto",
                delay:4000,
                disableProgressBar:"on",
                navigation: {
                    onHoverStop: 'off',
                    touch:{
                        touchenabled:"on"
                    },
                    arrows: {
                        style:"zeus",
                        enable:true,
                        hide_onmobile:true,
                        hide_under:767,
                        hide_onleave:true,
                        hide_delay:200,
                        hide_delay_mobile:1200,
                        tmp:'<div class="tp-title-wrap">  	<div class="tp-arr-imgholder"></div> </div>',
                        left: {
                            h_align: "left",
                            v_align: "center",
                            h_offset: 50,
                            v_offset: 0
                        },
                        right: {
                            h_align: "right",
                            v_align: "center",
                            h_offset: 50,
                            v_offset: 0
                        }
                    },
                },
                responsiveLevels:[4096,1199,992,767,480],
                gridwidth:[1170,1000,750,700,300],
                gridheight:[630,630,760,600,500],
                lazyType:"smart",
                fallbacks: {
                    simplifyAll:"off",
                    nextSlideOnWindowFocus:"off",
                    disableFocusListener:false,
                }
            })
        }
    }
    main_slider5();


function serviceCarosule2 () {
    if ($('.service_style_area .owl-carousel').length) {
        $('.service_style_area .owl-carousel').owlCarousel({
            loop: true,
            nav: true,
            dots: false,
            height:300,
            margin:30,
            navText: [
                '<i class="fa fa-angle-left"></i>',
                '<i class="fa fa-angle-right"></i>'
            ],
            autoplay: true,
            autoplayTimeout: 3000,
            autoplayHoverPause: true,
            responsive: {
                0:{
                    items:1
                },
                480:{
                    items:1
                },
                600:{
                    items:2
                },
                1000:{
                    items:3
                },
                1200:{
                    items:3
                },
                1920:{
                    items:3
                },
            }
        });
    }
}
serviceCarosule2 ();


function galleryCarosule1 () {
    if ($('.gallery_style_area .owl-carousel').length) {
        $('.gallery_style_area .owl-carousel').owlCarousel({
            loop: true,
            nav: true,
            dots: false,
            height:300,
            margin:30,
            navText: [
                '<i class="fa fa-angle-left"></i>',
                '<i class="fa fa-angle-right"></i>'
            ],
            autoplay: true,
            autoplayTimeout: 3000,
            autoplayHoverPause: true,
            responsive: {
                0:{
                    items:1
                },
                480:{
                    items:1
                },
                600:{
                    items:2
                },
                1000:{
                    items:3
                },
                1200:{
                    items:3
                },
                1920:{
                    items:3
                },
            }
        });
    }
}
galleryCarosule1 ();

function clientCarosule () {
    if ($('#clients .owl-carousel').length) {
        $('#clients .owl-carousel').owlCarousel({
            loop: true,
            nav: true,
            dots: false,
            margin:70,
            autoWidth: true,
            navText: [
                '<i class="fa fa-angle-left"></i>',
                '<i class="fa fa-angle-right"></i>'
            ],
            autoplay: true,
            smartSpeed: 1500,
            autoplayTimeout: 3000,
            autoplayHoverPause: true,
            responsive: {
                0:{
                    items:1
                },
                480:{
                    items:2
                },
                600:{
                    items:3
                },
                1000:{
                    items:5
                },
                1200:{
                    items:5
                }
            }
        });
    }
}
clientCarosule();

function contactFormValidation () {
    if($('.contact_us_form').length){
        $('.contact_us_form').validate({ // initialize the plugin
            rules: {
                name: {
                    required: true
                },
                email: {
                    required: true,
                    email: true
                },
                message: {
                    required: true
                },
                subject: {
                    required: true
                }
            },
            submitHandler: function (form) { 
                // sending value with ajax request
                $.post($(form).attr('action'), $(form).serialize(), function (response) {
                    $(form).parent('div').append(response);
                    $(form).find('input[type="text"]').val('');
                    $(form).find('input[type="email"]').val('');
                    $(form).find('textarea').val('');
                });
                return false;
            }
        });
    }
}
contactFormValidation ();

// add your custom functions 
function testimonialsCarosule () {
    if ($('.testimonials_area .owl-carousel').length) {
        $('.testimonials_area .owl-carousel').owlCarousel({
            loop: true,
            margin: 30,
            nav: false,
            dots: true,
            autoplay: false,
            navText: [
                '<i class="fa fa-angle-left"></i>',
                '<i class="fa fa-angle-right"></i>'
            ],
            autoplayHoverPause: true,
            responsive: {
                0:{
                    items:1
                },
                480:{
                    items:1
                },
                600:{
                    items:1
                },
                1000:{
                    items:1
                },
                1200:{
                    items:1
                },
                1920:{
                    items:1
                }
            }
        });
    }
}
testimonialsCarosule ();
    
    /*----------------------------------------------------*/
    /*  Testimonial Slider
    /*----------------------------------------------------*/
    function testimonials_slider(){
        if ( $('.testimonials_slider').length ){
            $('.testimonials_slider').owlCarousel({
                loop:true,
                margin: 0,
                items: 1,
                nav:false,
                autoplay: true,
                smartSpeed: 1500,
                dots:true,
//                navContainer:".portfolio_slider",
//                navText: ['<i class="ti-arrow-left"></i>','<i class="ti-arrow-right"></i>'],
                responsiveClass: true,
//                responsive: {
//                    0: {
//                        items: 1,
//                    },
//                    480: {
//                        items: 2,
//                    },
//                    700: {
//                        items: 3,
//                    },
//                    991: {
//                        items: 4,
//                    }
//                }
            })
        }
    }
    testimonials_slider();
    
    /*----------------------------------------------------*/
    /*  Testimonial Slider
    /*----------------------------------------------------*/
    function black_c_slider(){
        if ( $('.black_slider').length ){
            $('.black_slider').owlCarousel({
                loop:true,
                margin: 0,
                items: 1,
                nav:true,
                autoplay: true,
                smartSpeed: 1500,
                dots:true,
                navText: ['<i class="fa fa-angle-left" aria-hidden="true"></i>','<i class="fa fa-angle-right" aria-hidden="true"></i>'],
                responsiveClass: true,
//                responsive: {
//                    0: {
//                        items: 1,
//                    },
//                    480: {
//                        items: 2,
//                    },
//                    700: {
//                        items: 3,
//                    },
//                    991: {
//                        items: 4,
//                    }
//                }
            })
        }
    }
    black_c_slider();
    
    /*----------------------------------------------------*/
    /*  Testimonial Slider
    /*----------------------------------------------------*/
    function cases_slider_b(){
        if ( $('.cases_slider_b').length ){
            $('.cases_slider_b').owlCarousel({
                loop:true,
                margin: 30,
                items: 3,
                nav:true,
                autoplay: true,
                smartSpeed: 1500,
                dots:true,
                navContainer: '.black_cases_slider_inner',
                navText: ['<i class="fa fa-angle-left" aria-hidden="true"></i>','<i class="fa fa-angle-right" aria-hidden="true"></i>'],
                responsiveClass: true,
                responsive: {
                    0: {
                        items: 1,
                    },
                    992: {
                        items: 3,
                    }
                }
            })
        }
    }
    cases_slider_b();
    
    /*----------------------------------------------------*/
    /*  Partner Slider
    /*----------------------------------------------------*/
    function partner_slider(){
        if ( $('.partner_slider').length ){
            $('.partner_slider').owlCarousel({
                loop:true,
                margin: 30,
                items: 5,
                nav:false,
                autoplay: true,
                smartSpeed: 1500,
                dots:false,
                responsiveClass: true,
                responsive: {
                    0: {
                        items: 2,
                    },
                    600: {
                        items: 3,
                    },
                    700: {
                        items: 4,
                    },
                    992: {
                        items: 5,
                    }
                }
            })
        }
    }
    partner_slider();
    
    
//    if($(window).width() <= 992){
//        $('.submenu a').on('click', function() {
//            $('.submenu').toggleClass('open');
//            $(this).parent().find('> ul').slideToggle(350);
//            return false
//        });
//    }
    
    
    /*----------------------------------------------------*/
    /* Submenu js
    /*----------------------------------------------------*/
    
//    var dropToggle =$('.submenu').has('ul').children('a');
//    
//    if($(window).width() <= 992){
//        dropToggle.on('click',function(){
//            dropToggle.not(this).closest('li').find('ul').slideUp(700);
//            $(this).closest('li').children('ul').slideToggle(700);
//            return false;
//        });
//    }
//        
//    $( '.submenu a[href="#"]' ).click( function(e) {
//          e.preventDefault();
//    });
    
    
    
//    function sideNav(){
//        if ( $('.carrers_left').length ){
//            var sideNavTop = $('.carrers_left').offset().top;
//            $('.carrers_left').affix({
//                offset: {
//                    top: sideNavTop,
//                    bottom: function () {
//                        return (this.bottom = $('footer').outerHeight(!0) + 110);
//                    }
//                }
//            })
//        }
//    }
//    sideNav();
    
    /*----------------------------------------------------*/
    /*  portfolio_isotope
    /*----------------------------------------------------*/
    function our_project(){
        if ( $('.our_cases_area, .our_cases_home_area').length ){
            // Activate isotope in container
            $(".our_case_inner, .home_cases_inner").imagesLoaded( function() {
                $(".our_case_inner, .home_cases_inner").isotope({
                    layoutMode: 'fitRows',
                }); 
            }); 
            // Add isotope click function
            $(".project_fillter li").on('click',function(){
                $(".project_fillter li").removeClass("active");
                $(this).addClass("active");

                var selector = $(this).attr("data-filter");
                $(".our_case_inner, .home_cases_inner").isotope({
                    filter: selector,
                    animationOptions: {
                        duration: 450,
                        easing: "linear",
                        queue: false,
                    }
                });
                return false;
            });
        }
    }
    our_project();
    
    
    $(document).ready(function() {
        $('.popup-youtube, .popup-vimeo, .popup-gmaps').magnificPopup({
            disableOn: 700,
            type: 'iframe',
            mainClass: 'mfp-fade',
            removalDelay: 160,
            preloader: false,

            fixedContentPos: false
        });
    });
    
    
    
     /*----------------------------------------------------*/
    /*  Google map js
    /*----------------------------------------------------*/
    
    if ( $('#mapBox').length ){
        var $lat = $('#mapBox').data('lat');
        var $lon = $('#mapBox').data('lon');
        var $zoom = $('#mapBox').data('zoom');
        var $marker = $('#mapBox').data('marker');
        var $info = $('#mapBox').data('info');
        var $markerLat = $('#mapBox').data('mlat');
        var $markerLon = $('#mapBox').data('mlon');
        var map = new GMaps({
        el: '#mapBox',
        lat: $lat,
        lng: $lon,
        scrollwheel: false,
        scaleControl: true,
        streetViewControl: false,
        panControl: true,
        disableDoubleClickZoom: true,
        mapTypeControl: false,
        zoom: $zoom,
            styles: [
                {
                    "featureType": "water",
                    "elementType": "geometry.fill",
                    "stylers": [
                        {
                            "color": "#dcdfe6"
                        }
                    ]
                },
                {
                    "featureType": "transit",
                    "stylers": [
                        {
                            "color": "#808080"
                        },
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "road.highway",
                    "elementType": "geometry.stroke",
                    "stylers": [
                        {
                            "visibility": "on"
                        },
                        {
                            "color": "#dcdfe6"
                        }
                    ]
                },
                {
                    "featureType": "road.highway",
                    "elementType": "geometry.fill",
                    "stylers": [
                        {
                            "color": "#ffffff"
                        }
                    ]
                },
                {
                    "featureType": "road.local",
                    "elementType": "geometry.fill",
                    "stylers": [
                        {
                            "visibility": "on"
                        },
                        {
                            "color": "#ffffff"
                        },
                        {
                            "weight": 1.8
                        }
                    ]
                },
                {
                    "featureType": "road.local",
                    "elementType": "geometry.stroke",
                    "stylers": [
                        {
                            "color": "#d7d7d7"
                        }
                    ]
                },
                {
                    "featureType": "poi",
                    "elementType": "geometry.fill",
                    "stylers": [
                        {
                            "visibility": "on"
                        },
                        {
                            "color": "#ebebeb"
                        }
                    ]
                },
                {
                    "featureType": "administrative",
                    "elementType": "geometry",
                    "stylers": [
                        {
                            "color": "#a7a7a7"
                        }
                    ]
                },
                {
                    "featureType": "road.arterial",
                    "elementType": "geometry.fill",
                    "stylers": [
                        {
                            "color": "#ffffff"
                        }
                    ]
                },
                {
                    "featureType": "road.arterial",
                    "elementType": "geometry.fill",
                    "stylers": [
                        {
                            "color": "#ffffff"
                        }
                    ]
                },
                {
                    "featureType": "landscape",
                    "elementType": "geometry.fill",
                    "stylers": [
                        {
                            "visibility": "on"
                        },
                        {
                            "color": "#efefef"
                        }
                    ]
                },
                {
                    "featureType": "road",
                    "elementType": "labels.text.fill",
                    "stylers": [
                        {
                            "color": "#696969"
                        }
                    ]
                },
                {
                    "featureType": "administrative",
                    "elementType": "labels.text.fill",
                    "stylers": [
                        {
                            "visibility": "on"
                        },
                        {
                            "color": "#737373"
                        }
                    ]
                },
                {
                    "featureType": "poi",
                    "elementType": "labels.icon",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "poi",
                    "elementType": "labels",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "road.arterial",
                    "elementType": "geometry.stroke",
                    "stylers": [
                        {
                            "color": "#d6d6d6"
                        }
                    ]
                },
                {
                    "featureType": "road",
                    "elementType": "labels.icon",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {},
                {
                    "featureType": "poi",
                    "elementType": "geometry.fill",
                    "stylers": [
                        {
                            "color": "#dadada"
                        }
                    ]
                }
            ]
        });

        map.addMarker({
            lat: $markerLat,
            lng: $markerLon,
            icon: $marker,    
            infoWindow: {
              content: $info
            }
        })
    }
    
    
})(jQuery)