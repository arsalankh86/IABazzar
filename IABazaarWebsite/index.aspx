<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<%@ Register src="controls/header.ascx" tagname="header" tagprefix="uc1" %>

<%@ Register src="controls/footer.ascx" tagname="footer" tagprefix="uc2" %>

<%@ Register src="controls/socials.ascx" tagname="socials" tagprefix="uc3" %>

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
    <!--<!--<link href='http://fonts.googleapis.com/css?family=Carme' rel='stylesheet' type='text/css' />-->-->
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
                            <li>
                                <img src="images/slider/slider-image-111.jpg" alt="Banner One" /></li>
                            <li>
                                <img src="images/slider/slider-image-13.jpg" alt="Banner Three" /></li>
                            <li>
                                <img src="images/slider/slider-image-1111.jpg" alt="Banner Two" /></li>
                        </ul>
                    </div>
                    <!--End slider -->
                    <div class="box">
                        <div class="box-heading">
                            <span>Featured</span></div>
                        <div class="box-content">
                            <ul id="carouselfeature" class="elastislide-list customcarousel">
                                <li>
                                    <div>
                                        <div class="inner">
                                            <div class="image">
                                                <a href="#">
                                                    <img src="images/products/womenRingOne-165x165.jpg" alt="Golden ring one" title="Golden ring one" /></a>
                                            </div>
                                            <div class="name">
                                                <a href="#">Golden ring one</a></div>
                                            <div class="price">
                                                $199.99</div>
                                        </div>
                                        <div class="abs">
                                            <div class="cart">
                                                <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
                                                <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <div class="inner">
                                            <div class="specialPromo">
                                            </div>
                                            <div class="image">
                                                <a href="#">
                                                    <img src="images/products/productTwo-165x165.jpg" alt="iPod Classic" title="iPod Classic" /></a>
                                            </div>
                                            <div class="name">
                                                <a href="#">iPod Classic</a></div>
                                            <div class="price">
                                                $100.00</div>
                                        </div>
                                        <div class="abs">
                                            <div class="cart">
                                                <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
                                                <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <div class="inner">
                                            <div class="image">
                                                <a href="#">
                                                    <img src="images/products/womenSandalThree-165x165.jpg" alt="HP LP3065" title="HP LP3065" /></a>
                                            </div>
                                            <div class="name">
                                                <a href="#">HP LP3065</a></div>
                                            <div class="price">
                                                $107.00</div>
                                        </div>
                                        <div class="abs">
                                            <div class="cart">
                                                <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
                                                <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <div class="inner">
                                            <div class="image">
                                                <a href="#">
                                                    <img src="images/products/womenBagOne-165x165.jpg" alt="Women bag one" title="Women bag one" /></a>
                                            </div>
                                            <div class="name">
                                                <a href="#">Women bag one</a></div>
                                            <div class="price">
                                                $1,000.00</div>
                                        </div>
                                        <div class="abs">
                                            <div class="cart">
                                                <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
                                                <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <div class="inner">
                                            <div class="specialPromo">
                                            </div>
                                            <div class="image">
                                                <a href="#">
                                                    <img src="images/products/productSeven-165x165.jpg" alt="MacBook Pro" title="MacBook Pro" /></a>
                                            </div>
                                            <div class="name">
                                                <a href="#">MacBook Pro</a></div>
                                            <div class="price">
                                                $2,000.00</div>
                                        </div>
                                        <div class="abs">
                                            <div class="cart">
                                                <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
                                                <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <div class="inner">
                                            <div class="image">
                                                <a href="#">
                                                    <img src="images/products/ringTwo-165x165.jpg" alt="MacBook Air" title="MacBook Air" /></a>
                                            </div>
                                            <div class="name">
                                                <a href="#">MacBook Air</a></div>
                                            <div class="price">
                                                $1,000.00</div>
                                        </div>
                                        <div class="abs">
                                            <div class="cart">
                                                <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
                                                <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <div class="inner">
                                            <div class="image">
                                                <a href="#">
                                                    <img src="images/products/productSeven-165x165.jpg" alt="Men jacket one" title="Men jacket one" /></a>
                                            </div>
                                            <div class="name">
                                                <a href="#">Men jacket one</a></div>
                                            <div class="price">
                                                $500.00</div>
                                        </div>
                                        <div class="abs">
                                            <div class="cart">
                                                <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
                                                <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <div class="inner">
                                            <div class="specialPromo">
                                            </div>
                                            <div class="image">
                                                <a href="#">
                                                    <img src="images/products/womenSandalOne-165x165.jpg" alt="Women sandal one" title="Women sandal one" /></a>
                                            </div>
                                            <div class="name">
                                                <a href="#">Women sandal one</a></div>
                                            <div class="price">
                                                $100.00</div>
                                        </div>
                                        <div class="abs">
                                            <div class="cart">
                                                <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
                                                <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <div class="inner">
                                            <div class="image">
                                                <a href="#">
                                                    <img src="images/products/productTwo-165x165.jpg" alt="Men Jacket Two" title="Men Jacket Two" /></a>
                                            </div>
                                            <div class="name">
                                                <a href="#">Men Jacket Two</a></div>
                                            <div class="price">
                                                $100.00</div>
                                        </div>
                                        <div class="abs">
                                            <div class="cart">
                                                <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
                                                <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <div class="inner">
                                            <div class="specialPromo">
                                            </div>
                                            <div class="image">
                                                <a href="#">
                                                    <img src="images/products/womenJacketTwo-165x165.jpg" alt="Women jacket one" title="Women jacket one" /></a>
                                            </div>
                                            <div class="name">
                                                <a href="#">Women jacket one</a></div>
                                            <div class="price">
                                                $101.00</div>
                                        </div>
                                        <div class="abs">
                                            <div class="cart">
                                                <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
                                                <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <script type="text/javascript" src="js/jquery.elastislide.js"></script>
                    <script type="text/javascript">
                        $('#carouselfeature').elastislide();
                    </script>
                    <div id="banner0" class="banner">
                        <div>
                            <img src="images/slider/middlebanner-962x125.jpg" alt="HP Banner" title="HP Banner" /></div>
                    </div>
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
                    <div class="clear">
                    </div>
                    <div class="products-slider">
                        <div class="slider-holder">
                            <ul>
                                <li><a class="product" title="Product 9">
                                    <img src="css/images/product-101.jpg" alt="Product Image 10" width="204" height="165" />
                                    <span class="order model">Model Name</span> <span class="order">catalog number: <span
                                        class="number">347</span></span> <span class="order"><span class="buy-text">Buy Now</span><span
                                            class="price"><span class="dollar">$</span>14<span class="sub-text">.99</span></span></span>
                                </a></li>
                                <li><a class="product" title="Product 10">
                                    <img src="css/images/product-111.jpg" alt="Product Image 10" width="204" height="156" />
                                    <span class="order model">Model Name</span> <span class="order">catalog number: <span
                                        class="number">537</span></span> <span class="order"><span class="buy-text">Buy Now</span><span
                                            class="price"><span class="dollar">$</span>24<span class="sub-text">.99</span></span></span>
                                </a></li>
                                <li><a class="product" title="Product 11">
                                    <img src="css/images/product-121.jpg" alt="Product Image 11" width="204" height="160" />
                                    <span class="order model">Model Name</span> <span class="order">catalog number: <span
                                        class="number">710</span></span> <span class="order"><span class="buy-text">Buy Now</span><span
                                            class="price"><span class="dollar">$</span>4<span class="sub-text">.99</span></span></span>
                                </a></li>
                                <li><a class="product" title="Product 12">
                                    <img src="css/images/product-9.jpg" alt="Product Image 11" width="204" height="160" />
                                    <span class="order model">Model Name</span> <span class="order">catalog number: <span
                                        class="number">32</span></span> <span class="order"><span class="buy-text">Buy Now</span><span
                                            class="price"><span class="dollar">$</span>7<span class="sub-text">.99</span></span></span>
                                </a></li>
                                <li><a class="product" title="Product 9">
                                    <img src="css/images/product-11.jpg" alt="Product Image 11" width="204" height="160" />
                                    <span class="order model">Model Name</span> <span class="order">catalog number: <span
                                        class="number">347</span></span> <span class="order"><span class="buy-text">Buy Now</span><span
                                            class="price"><span class="dollar">$</span>14<span class="sub-text">.99</span></span></span>
                                </a></li>
                                <li><a class="product" title="Product 10">
                                    <img src="css/images/product-10.jpg" alt="Product Image 11" width="204" height="160" />
                                    <span class="order model">Model Name</span> <span class="order">catalog number: <span
                                        class="number">537</span></span> <span class="order"><span class="buy-text">Buy Now</span><span
                                            class="price"><span class="dollar">$</span>24<span class="sub-text">.99</span></span></span>
                                </a></li>
                                <li><a class="product" title="Product 11">
                                    <img src="css/images/product-11.jpg" alt="Product Image 11" width="204" height="160" />
                                    <span class="order model">Model Name</span> <span class="order">catalog number: <span
                                        class="number">710</span></span> <span class="order"><span class="buy-text">Buy Now</span><span
                                            class="price"><span class="dollar">$</span>4<span class="sub-text">.99</span></span></span>
                                </a></li>
                                <li><a class="product" title="Product 12">
                                    <img src="css/images/product-121.jpg" alt="Product Image 12" width="204" height="160" />
                                    <span class="order model">Model Name</span> <span class="order">catalog number: <span
                                        class="number">32</span></span> <span class="order"><span class="buy-text">Buy Now</span><span
                                            class="price"><span class="dollar">$</span>7<span class="sub-text">.99</span></span></span>
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
                    <div class="box">
                        <div class="box-heading">
                            <span>Latest</span></div>
                        <div class="box-content">
                            <ul id="carousellatest" class="elastislide-list customcarousel">
                                <li>
                                    <div>
                                        <div class="inner">
                                            <div class="image">
                                                <a href="#">
                                                    <img src="images/products/womenRingOne-165x165.jpg" alt="Golden ring one" title="Golden ring one" /></a>
                                            </div>
                                            <div class="name">
                                                <a href="#">Golden ring one</a></div>
                                            <div class="price">
                                                $199.99</div>
                                        </div>
                                        <div class="abs">
                                            <div class="cart">
                                                <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
                                                <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <div class="inner">
                                            <div class="specialPromo">
                                            </div>
                                            <div class="image">
                                                <a href="#">
                                                    <img src="images/products/productTwo-165x165.jpg" alt="iPod Classic" title="iPod Classic" /></a>
                                            </div>
                                            <div class="name">
                                                <a href="#">iPod Classic</a></div>
                                            <div class="price">
                                                $100.00</div>
                                        </div>
                                        <div class="abs">
                                            <div class="cart">
                                                <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
                                                <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <div class="inner">
                                            <div class="image">
                                                <a href="#">
                                                    <img src="images/products/womenSandalThree-165x165.jpg" alt="HP LP3065" title="HP LP3065" /></a>
                                            </div>
                                            <div class="name">
                                                <a href="#">HP LP3065</a></div>
                                            <div class="price">
                                                $107.00</div>
                                        </div>
                                        <div class="abs">
                                            <div class="cart">
                                                <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
                                                <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <div class="inner">
                                            <div class="image">
                                                <a href="#">
                                                    <img src="images/products/womenBagOne-165x165.jpg" alt="Women bag one" title="Women bag one" /></a>
                                            </div>
                                            <div class="name">
                                                <a href="#">Women bag one</a></div>
                                            <div class="price">
                                                $1,000.00</div>
                                        </div>
                                        <div class="abs">
                                            <div class="cart">
                                                <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
                                                <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <div class="inner">
                                            <div class="specialPromo">
                                            </div>
                                            <div class="image">
                                                <a href="#">
                                                    <img src="images/products/productSeven-165x165.jpg" alt="MacBook Pro" title="MacBook Pro" /></a>
                                            </div>
                                            <div class="name">
                                                <a href="#">MacBook Pro</a></div>
                                            <div class="price">
                                                $2,000.00</div>
                                        </div>
                                        <div class="abs">
                                            <div class="cart">
                                                <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
                                                <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <div class="inner">
                                            <div class="image">
                                                <a href="#">
                                                    <img src="images/products/ringTwo-165x165.jpg" alt="MacBook Air" title="MacBook Air" /></a>
                                            </div>
                                            <div class="name">
                                                <a href="#">MacBook Air</a></div>
                                            <div class="price">
                                                $1,000.00</div>
                                        </div>
                                        <div class="abs">
                                            <div class="cart">
                                                <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
                                                <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <div class="inner">
                                            <div class="image">
                                                <a href="#">
                                                    <img src="images/products/productSeven-165x165.jpg" alt="Men jacket one" title="Men jacket one" /></a>
                                            </div>
                                            <div class="name">
                                                <a href="#">Men jacket one</a></div>
                                            <div class="price">
                                                $500.00</div>
                                        </div>
                                        <div class="abs">
                                            <div class="cart">
                                                <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
                                                <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <div class="inner">
                                            <div class="specialPromo">
                                            </div>
                                            <div class="image">
                                                <a href="#">
                                                    <img src="images/products/womenSandalOne-165x165.jpg" alt="Women sandal one" title="Women sandal one" /></a>
                                            </div>
                                            <div class="name">
                                                <a href="#">Women sandal one</a></div>
                                            <div class="price">
                                                $100.00</div>
                                        </div>
                                        <div class="abs">
                                            <div class="cart">
                                                <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
                                                <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <div class="inner">
                                            <div class="image">
                                                <a href="#">
                                                    <img src="images/products/productTwo-165x165.jpg" alt="Men Jacket Two" title="Men Jacket Two" /></a>
                                            </div>
                                            <div class="name">
                                                <a href="#">Men Jacket Two</a></div>
                                            <div class="price">
                                                $100.00</div>
                                        </div>
                                        <div class="abs">
                                            <div class="cart">
                                                <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
                                                <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <div class="inner">
                                            <div class="specialPromo">
                                            </div>
                                            <div class="image">
                                                <a href="#">
                                                    <img src="images/products/womenJacketTwo-165x165.jpg" alt="Women jacket one" title="Women jacket one" /></a>
                                            </div>
                                            <div class="name">
                                                <a href="#">Women jacket one</a></div>
                                            <div class="price">
                                                $101.00</div>
                                        </div>
                                        <div class="abs">
                                            <div class="cart">
                                                <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
                                                <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
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
