(function ($) {
  "use strict";

  /*---WOW active js ---- */
  new WOW().init();
  var owl = $(".owl-carousel-banner");
  owl.owlCarousel({
    margin: 0,
    loop: true,
    nav: true,
    navText: [
      '<i class=" home-demo fa fa-angle-left"></i>',
      '<i class="home-demo fa fa-angle-right"></i>',
    ],
    dots: true,
    autoplay: true,
    animateOut: "fadeOut",
    autoplayTimeout: 3000,
    responsiveClass: true,
    responsive: {
      0: {
        items: 1,
      },
      600: {
        items: 1,
      },
      1000: {
        items: 1,
      },
    },
  });
  $('.dropdown-menu a.dropdown-toggle').on('click', function (e) {
    if (!$(this).next().hasClass('show')) {
        $(this).parents('.dropdown-menu').first().find('.show').removeClass("show");
    }
    var $subMenu = $(this).next(".dropdown-menu");
    $subMenu.toggleClass('show');


    $(this).parents('li.nav-item.dropdown.show').on('hidden.bs.dropdown', function (e) {
        $('.dropdown-submenu .show').removeClass("show");
    });

    return false;
});

  var owl_categorys = $(".products-carousel");
  owl_categorys.owlCarousel({
    margin: 30,
    loop: false,
    items: 6,
    nav: true,
    navText: [
      '<i class="fa fa-angle-left"></i>',
      '<i class="fa fa-angle-right"></i>',
    ],
    dots: true,
    autoplay: true,
    animateOut: "fadeOut",
    autoplayTimeout: 3000,
    responsiveClass: true,
    responsive: {
      0: {
        items: 1,
        margin: 10,
      },
      300: {
        items: 1,
        margin: 10,
      },
      400: {
        items: 2,
        margin: 10,
      },
      600: {
        items: 2,
        margin: 10,
      },

      1000: {
        items: 3,
      },
      1400: {
        items: 4,
      },
    },
  });
  var owl_category = $(".blog-carousel");
  owl_category.owlCarousel({
    margin: 30,
    loop: false,
    items: 5,
    nav: true,
    navText: [
      '<i class="home-demo fa fa-angle-left">',
      '<i class="home-demo fa fa-angle-right">',
    ],
    dots: true,
    autoplay: false,
    animateOut: "fadeOut",
    autoplayTimeout: 3000,
    responsiveClass: true,
    responsive: {
      0: {
        items: 1,
      },
      600: {
        items: 2,
        margin: 10,
      },
      1000: {
        items: 2,
      },
      1200: {
        items: 3,
      },
      1400: {
        items: 3,
      },
    },
  });
  var owl_category2 = $(".slideTestimonial");
  owl_category2.owlCarousel({
    loop: false,
    items: 3,
    nav: true,
    navText: [
      '<i class="home-demo fa fa-angle-left"></i>',
      '<i class="home-demo fa fa-angle-right"></i>',
    ],
    dots: true,
    autoplay: true,
    autoplayTimeout: 2000,
    responsiveClass: true,
    responsive: {
      0: {
        items: 1,
      },
      600: {
        items: 1,
      },
      1000: {
        items: 1,
      },
    },
  });
  var owl_categorys = $(".players-carousel");
  owl_categorys.owlCarousel({
    margin: 30,
    loop: false,
    items: 6,
    animateOut: "fadeOut",
    nav: true,
    navText: [
      '<i class="home-demo fa fa-angle-left"></i>',
      '<i class="home-demo fa fa-angle-right"></i>',
    ],
    dots: true,
    autoplay: false,
    autoplayTimeout: 3000,
    responsiveClass: true,
    responsive: {
      0: {
        items: 1,
        margin: 10,
      },
      300: {
        items: 1,
        margin: 10,
      },
      400: {
        items: 2,
        margin: 10,
      },
      600: {
        items: 3,
        margin: 10,
      },

      1000: {
        items: 4,
      },
      1400: {
        items: 4,
      },
    },
  });
  // additional
  var owl_category5 = $(".additional");
  owl_category5.owlCarousel({
    margin: 30,
    loop: false,
    items: 6,
    nav: true,
    navText: [
      '<i class="additional fa fa-angle-left"></i>',
      '<i class="additional fa fa-angle-right"></i>',
    ],
    dots: true,
    autoplay: false,
    autoplayTimeout: 3000,
    responsiveClass: true,
    responsive: {
      0: {
        items: 1,
      },
      300: {
        items: 2,
      },
      400: {
        items: 2,
      },
      700: {
        items: 2,
      },
      800: {
        items: 2,
      },
      900: {
        items: 2,
      },

      1400: {
        items: 3,
      },
    },
  });
  $(document).ready(function () {
    $(".counter").each(function () {
      $(this)
        .prop("Counter", 0)
        .animate(
          {
            Counter: $(this).text(),
          },
          {
            duration: 5000,
            easing: "swing",
            step: function (now) {
              $(this).text(Math.ceil(now));
            },
          }
        );
    });
  });

  // loader
  $(window).on("load", function () {
    $(".loader").fadeOut("slow", function () {
      $(this).remove();
    });
  });
  // cart scroll
  // cart scroll
  function set_cart_scroll() {
    var header_height = $("header").height();
    var screen_height = $(window).height();
    var cart_list_height = $("#cart .dropdown-menu .table-striped").height();
    var cart_total_height = $("#cart .dropdown-menu li+li").height();
    var cart_div_height =
      parseInt(cart_list_height) + parseInt(cart_total_height) + 10;
    var cart_div_max_height = parseInt(screen_height) - parseInt(header_height);
    var cart_total_pro = jQuery(".cart-content-product table tr").length;

    if (screen_height < cart_div_height) {
      $("#cart .dropdown-menu").css({
        "overflow-y": "unset",
        "max-height": "unset",
      });
      $("ul.dropdown-menu.header-cart-toggle")
        .addClass("scroll_cart_dropdown")
        .css({
          "overflow-y": "auto",
          "max-height": cart_div_max_height + "px",
        });
    } else {
      $("ul.dropdown-menu.header-cart-toggle")
        .removeClass("scroll_cart_dropdown")
        .css({ "overflow-y": "unset", "max-height": "unset" });
      $("#cart .dropdown-menu ul").css({
        "overflow-y": "auto",
        "max-height": "240px",
      });
    }
  }
  $(document).ready(function () {
    $(document).on("click", "#cart button.btn.btn-inverse", function () {
      set_cart_scroll();
    });
  });
  // back to top
  $(document).ready(function () {
    // Back to top
    backToTop();
  });
  // Product-Page onclick to open reviwe section
  $(document).ready(function () {
    $(".write-review").on("click", function (event) {
      $("a[href='#tab-review']").tab("show");
      $("body,html").animate(
        {
          scrollTop: $(".propage-tab").offset().top,
        },
        500
      );
      return false;
    });
  });

  // Product-Page onclick to shows image
  jQuery(".additional a.elevatezoom-gallery").click(function (e) {
    e.preventDefault();
    var this_img_src = jQuery(this).attr("data-zoom-image");
    jQuery("#prozoom").attr("src", this_img_src);
    return;
  });

  // Scroll to Top
  function backToTop() {
    //Check to see if the window is top if not then display button
    $(".scrollToTop").hide();
    $(window).scroll(function () {
      if ($(this).scrollTop() > 250) {
        $(".scrollToTop").fadeIn();
      } else {
        $(".scrollToTop").fadeOut();
      }
    });
    //Click event to scroll to top
    $(".scrollToTop").on("click", function () {
      $("html, body").animate({ scrollTop: 0 }, 800);
      return false;
    });
  }

  $(document).ready(function () {
    // responsive header
    responsiveheader();
    //footer drop-down
    footerExplanCollapse();
    // footer
    updateColumnsAndContent();
   
  });

  $(document).ready(function () {
    var headerfixed = 1;
    if (headerfixed == 1) {
      $(window).scroll(function () {
        var windows_height = jQuery(window).height();
        if ($(this).scrollTop() > windows_height) {
          $("header").addClass("header-fixed");
          var scroll_header_height = $("header").height();
          $("body").css({ "padding-top": scroll_header_height + "px" });
        } else {
          $("header").removeClass("header-fixed");
          $("body").css({ "padding-top": "0px" });
        }
      });
    } else {
      $("header").removeClass("header-fixed");
      $("body").css({ "padding-top": "0px" });
    }
    if (window.location.href.indexOf('submitted=true') !== -1) {
      $('.submitted').show();
      }
  });
  $(window).resize(function () {
    responsiveheader();
    updateColumnsAndContent();
   
  });
  $(document).on("click", ".plus, .minus", function (e) {
    e.preventDefault();
    var parent = $(this).parents(".product-btn-quantity");
    var quantity = parent.find('[name="quantity"]');
    var val = quantity.val();
    if ($(this).hasClass("plus")) {
      val = parseInt(val) + 1;
    } else {
      if (val == 1) {
        val = 1;
      } else {
        val = val >= 1 ? parseInt(val) - 1 : 0;
      }
    }
    quantity.val(val);
    quantity.trigger("change");
    return false;
  });
  /* Responsive Menu */
  $("#show-header_menu").click(function () {
    $(".slotmachine-menu .main-menu-outer").toggleClass("main-menu-active");
    $("body").addClass("active");
  });

  $(".slotmachine-menu .menu-title i").click(function () {
    $(".slotmachine-menu .main-menu-outer").removeClass("main-menu-active");
    $("body").removeClass("active");
  });

  let prevWidth = null;
  function responsiveheader() {
    var this_window_width = $(window).width();
    if (prevWidth != this_window_width) {
      if (this_window_width <= 1199) {
        $(".header-center").insertAfter(".header-inner");
      } else {
        $(".header-center").insertBefore(".header-right");
      }
      prevWidth = this_window_width;
    }
  }
  

  function footerExplanCollapse() {
    $(".footer-top h5").addClass("toggled");
    $(".footer-top .toggled").on("click", function (e) {
      e.preventDefault();
      if ($(window).width() < 992) {
        $(this).toggleClass("active");

        $(this).parent().find("ul").toggleClass("active").toggle("slow");
      }
    });
  }
  /*----------
   Update column & content in responsive
   -----------*/
  function updateColumnsAndContent() {
    if ($(window).width() < 992) {
      $("#column-left, #column-right").insertAfter("#content");
      // footer

      if ($(".footer-top .toggle-open").length == 0) {
        $(".footer-top h5").append(
          "<span class='toggle-open'><i class='fa fa-chevron-down'></i></span>"
        );
        $(".footer-top ul.list-unstyled").hide();
      }
    } else {
      $("#column-right").insertAfter("#content");
      $("#column-left").insertBefore("#content");

      // footer
      $(".footer-top .toggle-open").remove();
      $(".footer-top ul.list-unstyled").show();
    }
  }

})(jQuery);
