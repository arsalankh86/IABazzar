<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="defualt" %>

<%@ Register Src="controls/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="controls/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<%@ Register Src="controls/socials.ascx" TagName="socials" TagPrefix="uc3" %>
<!DOCTYPE HTML>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="HandheldFriendly" content="True" />
    <meta name="MobileOptimized" content="320" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1" />
    <meta name="description" content="Anycart Responsive Retail Template" />
    <title>Iabazaar</title>
    <link rel="shortcut icon" type="image/x-icon" href="images/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="css/stylesheet.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="css/carousel.css" media="screen" />
    <link rel="stylesheet" href="slider/css/style.css" type="text/css" media="all" />
    <script src="slider/js/jquery-1.6.2.min.js" type="text/javascript" charset="utf-8"></script>
    <script src="slider/js/jquery.jcarousel.min.js" type="text/javascript" charset="utf-8"></script>
    <script src="slider/js/jquery-func.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/jquery/jquery-1.8.2.min.js"></script>
    <script src="js/jquery/ui/jquery-ui-1.8.16.custom.min.js"></script>
    <script src="js/jquery/ui/external/jquery.cookie.js"></script>
    <script src="js/common.js"></script>
    <script src="js/jquery.cycle.js"></script>
    <script src="js/jquery.flexslider-min.js"></script>
    <script src="js/jquery/jquery.cycle.js"></script>
    <script src="js/jquery/jquery.jcarousel.min.js"></script>
    <script src="js/html5.js"></script>
    <script src="js/jquery.tooltipster.min.js"></script>
    <script src="js/custom.js"></script>
    <link rel="stylesheet" type="text/css" href="css/facebook.css" />
    <link rel="stylesheet" type="text/css" href="css/elastislide.css" />
    <script src="js/modernizr.custom.17475.js"></script>

<!-- Google Analytics -->
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-49609094-1', 'iabazaar.com');
        ga('send', 'pageview');

</script>
<!-- End Google Analytics -->



    <!--[if IE 7]>
<link rel="stylesheet" type="text/css" href="css/ie7.css" />
<![endif]-->
    <!--[if lt IE 7]>
<link rel="stylesheet" type="text/css" href="css/ie6.css" />
<script src="js/DD_belatedPNG_0.0.8a-min.js"></script>
<script type="text/javascript">
DD_belatedPNG.fix('#logo img');
</script>
<![endif]-->
</head>
<body>
    <form runat="server">
    <div class="mainWrapper">
        <!--Header Part Start-->
        <header>
        <uc1:header ID="header1" runat="server" />

</header>
        <!--Header Part End-->
        <div class="wrapper">
            <div id="notification">
            </div>
            <div id="container">
                <div id="content">
                    <uc3:socials ID="socials1" runat="server" />
                    <!-- Start slider -->
                    <div class="flexslider">
                        <ul class="slides">
                            <li><a href="cc-mahnoor-spring-collection-2014-vol-1-29">
                                <img src="images/slider/2014-mahnoor.jpg" alt="mahnoor-spring-collection-2014-vol-1" /></a></li>
                            <li><a href="cc-umar-sayeed-festival-2013-by-al-karam-51">
                                <img src="images/slider/2013-umersayyed.jpg" alt="umar-sayeed-festival-2013-by-al-karam" /></a></li>
                                <li><a href="cc-al-karam-festival-collection-2013-2">
                                <img src="images/slider/alkaramjoy.jpg" alt="al-karam-festival-collection-2013" /></a></li>
                            <%--<li>
                                <img src="images/slider/2013-orient.jpg" alt="Banner Three" /></li>
                            <li>
                                <img src="images/slider/2013-khadder.jpg" alt="Banner Two" /></li>--%>
                            
                        </ul>
                    </div>
                    <!--End slider -->
                    <%-- <div class="box">
                        <div class="box-heading">
                            <span>Featured</span></div>--%>
                    <div class="box">
                        <div class="box-heading">
                            <span>Featured</span></div>
                        <div class="box-content">
                            <div class="elastislide-wrapper elastislide-horizontal">
                                <div class="elastislide-carousel">
                                    <ul style="display: block; max-height: 159px; transition: all 500ms ease-in-out 0s;
                                        transform: translateX(0px);" id="Ul2" class="elastislide-list customcarousel">
                                        <li style="width: 33.2988%; max-width: 159px; max-height: 159px;">
                                            <div>
                                                <div class="inner">
                                                    <div class="image">
                                                        <a href="kareena-kapoor-cresent-lawn-7-night-952">
                                                            <img src="images/products/onlineimage/C9.jpg" alt="Cresent Lawn 7 Night" title="Cresent Lawn 7 Night"
                                                                height="155" width="155"></a>
                                                    </div>
                                                    <div class="name">
                                                        <a href="kareena-kapoor-cresent-lawn-7-night-952">Cresent Lawn 7 Night</a></div>
                                                    <div class="price">
                                                        $88.61</div>
                                                </div>
                                                <div style="display: none;" class="abs">
                                                    <div class="cart">
                                                        <a class="button1" title="Add to Cart" href="kareena-kapoor-cresent-lawn-7-night-952">
                                                            <span>Add to Cart</span></a> <a class="btn-detail ml10" title="Detail" href="kareena-kapoor-cresent-lawn-7-night-952">
                                                                <span>Detail</span></a></div>
                                                </div>
                                            </div>
                                        </li>
                                        <li style="width: 33.2988%; max-width: 159px; max-height: 159px;">
                                            <div>
                                                <div class="inner">
                                                    <div class="specialPromo">
                                                    </div>
                                                    <div class="image">
                                                        <a href="#">
                                                            <img src="images/products/onlineimage/C2.jpg" alt="Cresent Lawn 8 Passion" title="Cresent Lawn 8 Passion"
                                                                height="155" width="155"></a>
                                                    </div>
                                                    <div class="name">
                                                        <a href="kareena-kapoor-cresent-lawn-8-passion-939">Cresent Lawn 8 Passion</a></div>
                                                    <div class="price">
                                                        $85.63</div>
                                                </div>
                                                <div style="display: none;" class="abs">
                                                    <div class="cart">
                                                        <a class="button1" title="Add to Cart" href="kareena-kapoor-cresent-lawn-8-passion-939">
                                                            <span>Add to Cart</span></a> <a class="btn-detail ml10" title="Detail" href="kareena-kapoor-cresent-lawn-8-passion-939">
                                                                <span>Detail</span></a></div>
                                                </div>
                                            </div>
                                        </li>
                                        <li style="width: 33.2988%; max-width: 159px; max-height: 159px;">
                                            <div>
                                                <div class="inner">
                                                    <div class="image">
                                                        <a href="#">
                                                            <img src="images/products/onlineimage/C3.jpg" alt="Cresent Lawn 15 Skin" title="Cresent Lawn 15 Skin"
                                                                height="155" width="155"></a>
                                                    </div>
                                                    <div class="name">
                                                        <a href="kareena-kapoor-cresent-lawn-15-skin-940">Cresent Lawn 15 Skin</a></div>
                                                    <div class="price">
                                                        $91.60</div>
                                                </div>
                                                <div style="display: none;" class="abs">
                                                    <div class="cart">
                                                        <a class="button1" title="Add to Cart" href="kareena-kapoor-cresent-lawn-15-skin-940">
                                                            <span>Add to Cart</span></a> <a class="btn-detail ml10" title="Detail" href="kareena-kapoor-cresent-lawn-15-skin-940">
                                                                <span>Detail</span></a></div>
                                                </div>
                                            </div>
                                        </li>
                                        <li style="width: 33.2988%; max-width: 159px; max-height: 159px;">
                                            <div>
                                                <div class="inner">
                                                    <div class="image">
                                                        <a href="#">
                                                            <img src="images/products/onlineimage/C4.jpg" alt="Cresent Lawn 6 Water" title="Cresent Lawn 6 Water"
                                                                height="155" width="155"></a>
                                                    </div>
                                                    <div class="name">
                                                        <a href="#">Cresent Lawn 6 Water</a></div>
                                                    <div class="price">
                                                        $88.61</div>
                                                </div>
                                                <div style="display: none;" class="abs">
                                                    <div class="cart">
                                                        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a> <a class="btn-detail ml10"
                                                            title="Detail" href="#"><span>Detail</span></a></div>
                                                </div>
                                            </div>
                                        </li>
                                        <li style="width: 33.2988%; max-width: 159px; max-height: 159px;">
                                            <div>
                                                <div class="inner">
                                                    <div class="specialPromo">
                                                    </div>
                                                    <div class="image">
                                                        <a href="kareena-kapoor-cresent-lawn-1-earth-945">
                                                            <img src="images/products/onlineimage/C5.jpg" alt="Cresent Lawn 1 Earth" title="Cresent Lawn 1 Earth"
                                                                height="155" width="155"></a>
                                                    </div>
                                                    <div class="name">
                                                        <a href="#">Cresent Lawn 1 Earth</a></div>
                                                    <div class="price">
                                                        $85.63</div>
                                                </div>
                                                <div style="display: none;" class="abs">
                                                    <div class="cart">
                                                        <a class="button1" title="Add to Cart" href="kareena-kapoor-cresent-lawn-1-earth-945">
                                                            <span>Add to Cart</span></a> <a class="btn-detail ml10" title="Detail" href="kareena-kapoor-cresent-lawn-1-earth-945">
                                                                <span>Detail</span></a></div>
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                                <nav><span style="display: none;" class="elastislide-prev">Previous</span><span style="display: block;" class="elastislide-next">Next</span></nav>
                            </div>
                        </div>
                        </li> </ul>
                    </div>
                </div>
                <script type="text/javascript" src="js/jquery.elastislide.js"></script>
                <script type="text/javascript">
                    $('#carouselfeature').elastislide();
                </script>
                <div class="box">
                    <script type="text/javascript"><!--
                        $(document).ready(function () {
                            $('#banner0 div:first-child').css('display', 'block');
                        });

                        var banner = function () {
                            $('#banner0').cycle({
                                before: function (current, next) {
                                    $(next).parent().height($(next).outerHeight());
                                }
                            });
                        }

                        setTimeout(banner, 2000);
//--></script>
                    <div class="box">
                        <div class="box-heading">
                            <span>Featured</span></div>
                        <div class="clear">
                        </div>
                        <div class="products-slider">
                            <div class="slider-holder">
                                <ul>
                                    <li><a class="product" title="Mausummery Lawn Tulip Aura Green" href="mausummery-lawn-tulip-aura-green-412">
                                        <img src="css/images/M1.jpg" alt="PMausummery Lawn Tulip Aura Green" width="204"
                                            height="165" />
                                        <span class="order model">Mausummery Lawn Tulip Aura Green</span> <span class="order">
                                            <span class="number"></span></span><span class="order"><span class="buy-text">Buy Now</span><span
                                                class="price"><span class="dollar">$</span>33<span class="sub-text">.51</span></span></span>
                                    </a></li>
                                    <li><a class="product" title="Mausummery Lawn Ladakh Red" href="mausummery-lawn-ladakh-red-413">
                                        <img src="css/images/M2.jpg" alt="Mausummery Lawn Ladakh Red" width="204" height="156" />
                                        <span class="order model">Mausummery Lawn Ladakh Red</span> <span class="order"><span
                                            class="number"></span></span><span class="order"><span class="buy-text">Buy Now</span><span
                                                class="price"><span class="dollar">$</span>33<span class="sub-text">.99</span></span></span>
                                    </a></li>
                                    <li><a class="product" title="Mausummery Lawn Ladakh Blue" href="mausummery-lawn-ladakh-blue-414">
                                        <img src="css/images/M3.jpg" alt="Mausummery Lawn Ladakh Blue" width="204" height="160" />
                                        <span class="order model">Mausummery Lawn Ladakh Blue</span> <span class="order"><span
                                            class="number"></span></span><span class="order"><span class="buy-text">Buy Now</span><span
                                                class="price"><span class="dollar">$</span>33<span class="sub-text">.51</span></span></span>
                                    </a></li>
                                    <li><a class="product" title="Mausummery Lawn Flower Pot Aqua" href="mausummery-lawn-flower-pot-aqua-415">
                                        <img src="css/images/M4.jpg" alt="Mausummery Lawn Flower Pot Aqua" width="204" height="160" />
                                        <span class="order model">Mausummery Lawn Flower Pot Aqua</span> <span class="order">
                                            <span class="number"></span></span><span class="order"><span class="buy-text">Buy Now</span><span
                                                class="price"><span class="dollar">$</span>54<span class="sub-text">.36</span></span></span>
                                    </a></li>
                                    <li><a class="product" title="Mausummery Lawn Persian Flower Black" href="mausummery-lawn-persian-flower-black-418">
                                        <img src="css/images/M5.jpg" alt="Mausummery Lawn Persian Flower Black" width="204"
                                            height="160" />
                                        <span class="order model">Mausummery Lawn Persian Flower Black</span> <span class="order">
                                            <span class="number"></span></span><span class="order"><span class="buy-text">Buy Now</span><span
                                                class="price"><span class="dollar">$</span>69<span class="sub-text">.25</span></span></span>
                                    </a></li>
                                    <li><a class="product" title="Mausummery Lawn Checker Yellow" href="mausummery-lawn-phulkari-yellow-417">
                                        <img src="css/images/M6.jpg" alt="Product Image 11" width="204" height="160" />
                                        <span class="order model">Mausummery Lawn Checker Yellow</span> <span class="order">
                                            <span class="number"></span></span><span class="order"><span class="buy-text">Buy Now</span><span
                                                class="price"><span class="dollar">$</span>69<span class="sub-text">.25</span></span></span>
                                    </a></li>
                                    <li><a class="product" title="Mausummery Lawn Iznik Blue" href="mausummery-lawn-iznik-blue-424">
                                        <img src="css/images/M7.jpg" alt="Product Image 11" width="204" height="160" />
                                        <span class="order model">Mausummery Lawn Iznik Blue</span> <span class="order"><span
                                            class="number"></span></span><span class="order"><span class="buy-text">Buy Now</span><span
                                                class="price"><span class="dollar">$</span>51<span class="sub-text">.38</span></span></span>
                                    </a></li>
                                    <li><a class="product" title="Mausummery Lawn Triangle Blue" href="mausummery-lawn-triangle-blue-423">
                                        <img src="css/images/M8.jpg" alt="Product Image 12" width="204" height="160" />
                                        <span class="order model">Mausummery Lawn Triangle Blue</span> <span class="order"><span
                                            class="number"></span></span><span class="order"><span class="buy-text">Buy Now</span><span
                                                class="price"><span class="dollar">$</span>58<span class="sub-text">.29</span></span></span>
                                    </a></li>
                                </ul>
                            </div>
                            <div class="nav">
                                <a href="#" class="prev" title="Previous">Prev</a> <a href="#" class="next" title="Next">
                                    Next</a>
                                <div class="cl">
                                    &nbsp;</div>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="box-heading">
                            <span>Latest</span></div>
                        <div class="box-content">
                            <div class="elastislide-wrapper elastislide-horizontal">
                                <div class="elastislide-carousel">
                                    <ul id="carousellatest3" class="elastislide-list customcarousel" style="display: block;
                                        max-height: 159px; transition: all 500ms ease-in-out 0s; transform: translateX(0px);">
                                        <li style="width: 33.2988%; max-width: 159px; max-height: 159px;">
                                            <div>
                                                <div class="inner">
                                                    <div class="image">
                                                        <a href="Strawberry-31B">
                                                            <img alt="Golden ring one" height="155" src="Images/products/OB/Unstiched/Strawberry_31B.jpg"
                                                                title="Strawberry - 31B" width="155" /></a>
                                                    </div>
                                                    <div class="name">
                                                        <a href="strawberry-31b-605">Strawberry - 31B</a></div>
                                                    <div class="price">
                                                        $90.85</div>
                                                </div>
                                                <div class="abs" style="display: none;">
                                                    <div class="cart">
                                                        <a class="button1" href="strawberry-31b-605" title="Add to Cart"><span>Add to Cart</span></a>
                                                        <a class="btn-detail ml10" href="strawberry-31b-605" title="Detail"><span>Detail</span></a></div>
                                                </div>
                                            </div>
                                        </li>
                                        <li style="width: 33.2988%; max-width: 159px; max-height: 159px;">
                                            <div>
                                                <div class="inner">
                                                    <div class="specialPromo">
                                                    </div>
                                                    <div class="image">
                                                        <a href="#">
                                                            <img alt="Golden ring one" height="155" src="Images/products/OB/Unstiched/Strawberry_32A.jpg"
                                                                title="Strawberry - 32A" width="155" /></a>
                                                    </div>
                                                    <div class="name">
                                                        <a href="strawberry-32a-606">Strawberry - 32A</a></div>
                                                    <div class="price">
                                                        $90.85</div>
                                                </div>
                                                <div class="abs" style="display: none;">
                                                    <div class="cart">
                                                        <a class="button1" href="strawberry-32a-606" title="Add to Cart"><span>Add to Cart</span></a>
                                                        <a class="btn-detail ml10" href="strawberry-32a-606" title="Detail"><span>Detail</span></a></div>
                                                </div>
                                            </div>
                                        </li>
                                        <li style="width: 33.2988%; max-width: 159px; max-height: 159px;">
                                            <div>
                                                <div class="inner">
                                                    <div class="image">
                                                        <a href="#">
                                                            <img alt="Golden ring one" height="155" src="images/products/onlineimage/g3.jpg"
                                                                title="Strawberry - 32B" width="155" /></a>
                                                    </div>
                                                    <div class="name">
                                                        <a href="strawberry-32b-607">Strawberry - 32B</a></div>
                                                    <div class="price">
                                                        $90.85</div>
                                                </div>
                                                <div class="abs" style="display: none;">
                                                    <div class="cart">
                                                        <a class="button1" href="strawberry-32b-607" title="Add to Cart"><span>Add to Cart</span></a>
                                                        <a class="btn-detail ml10" href="strawberry-32b-607" title="Detail"><span>Detail</span></a></div>
                                                </div>
                                            </div>
                                        </li>
                                        <li style="width: 33.2988%; max-width: 159px; max-height: 159px;">
                                            <div>
                                                <div class="inner">
                                                    <div class="image">
                                                        <a href="Images/products/OB/Unstiched/Strawberry_34B.jpg">
                                                            <img alt="Golden ring one" height="155" src="Images/products/OB/Unstiched/Strawberry_34B.jpg"
                                                                title="Strawberry - 34B" width="155" /></a>
                                                    </div>
                                                    <div class="name">
                                                        <a href="strawberry-34b-608">Strawberry - 34B</a></div>
                                                    <div class="price">
                                                        $90.85</div>
                                                </div>
                                                <div class="abs" style="display: none;">
                                                    <div class="cart">
                                                        <a class="button1" href="strawberry-34b-608" title="Add to Cart"><span>Add to Cart</span></a>
                                                        <a class="btn-detail ml10" href="strawberry-34b-608" title="Detail"><span>Detail</span></a></div>
                                                </div>
                                            </div>
                                        </li>
                                        <li style="width: 33.2988%; max-width: 159px; max-height: 159px;">
                                            <div>
                                                <div class="inner">
                                                    <div class="specialPromo">
                                                    </div>
                                                    <div class="image">
                                                        <a href="#">
                                                            <img alt="Women sandal one" height="155" src="Images/products/OB/Unstiched/Strawberry_35A.jpg"
                                                                title="Strawberry - 35A" width="155" /></a>
                                                    </div>
                                                    <div class="name">
                                                        <a href="strawberry-35a-609">Strawberry - 35A</a></div>
                                                    <div class="price">
                                                        $90.85</div>
                                                </div>
                                                <div class="abs" style="display: none;">
                                                    <div class="cart">
                                                        <a class="button1" href="strawberry-35a-609" title="Add to Cart"><span>Add to Cart</span></a>
                                                        <a class="btn-detail ml10" href="strawberry-35a-609" title="Detail"><span>Detail</span></a></div>
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                                <nav><span class="elastislide-prev" style="display: none;"></span><span 
                            class="elastislide-next" style="display: block;"></span></nav>
                            </div>
                        </div>
                        <nav><span class="elastislide-prev" style="display: none;"></span><span 
                            class="elastislide-next" style="display: block;"></span></nav>
                    </div>
                </div>
                <script type="text/javascript" src="js/jquery.elastislide.js"></script>
                <script type="text/javascript">
                    $('#carousellatest').elastislide();
                </script>
                <!--<div id="carousel0">
  <ul class="jcarousel-skin-opencart">
        <li><a href="#"><img src="images/manufacture/komoder-100x100.jpg" alt="Komoder" title="Komoder" /></a></li>
        <li><a href="#"><img src="images/manufacture/checkout-100x100.jpg" alt="Checkout" title="Checkout" /></a></li>
        <li><a href="#"><img src="images/manufacture/booko-100x100.jpg" alt="Booko" title="Booko" /></a></li>
        <li><a href="#"><img src="images/manufacture/mistercutts-100x100.jpg" alt="Mister Cutts" title="Mister Cutts" /></a></li>
        <li><a href="#"><img src="images/manufacture/become-100x100.jpg" alt="Become" title="Become" /></a></li>
        <li><a href="#"><img src="images/manufacture/komoder-100x100.jpg" alt="Komoder" title="Komoder" /></a></li>
      </ul>
</div>-->
                <!--<script type="text/javascript">
$('#carousel0 ul').jcarousel({
	vertical: false,
	visible: 5,
	scroll: 3});
</script>//-->
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
    <!--Footer Part Start-->
    <footer>
<uc2:footer ID="footer1" runat="server" />
</footer>
    <!--Footer Part End-->
    </div>
    </form>
    <!--Scroll back to top-->
    <script>
        $(function () {
            $(window).scroll(function () {
                if ($(this).scrollTop() > 100) {
                    $('#backTop').fadeIn();
                } else {
                    $('#backTop').fadeOut();
                }
            });
        });
        jQuery('.backtotop').click(function () {
            jQuery('html, body').animate({ scrollTop: 0 }, 'slow');
        });

    </script>
    <!--end of Scroll back to top-->
</body>
</html>
