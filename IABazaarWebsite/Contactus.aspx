<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contactus.aspx.cs" Inherits="Contactus" %>

<%@ Register src="controls/header.ascx" tagname="header" tagprefix="uc1" %>

<%@ Register src="controls/footer.ascx" tagname="footer" tagprefix="uc2" %>

<%@ Register src="controls/socials.ascx" tagname="socials" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="HandheldFriendly" content="True" />
    <meta name="MobileOptimized" content="320" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1" />
    <meta name="description" content="Anycart Responsive Retail Template" />
    <title>Buy Indian Pakistani Salwar Kameez Online</title>
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

<form id="Form1" runat="server">
    <div class="mainWrapper">
        <!--Header Part Start-->
        <header>
        <uc1:header ID="header1" runat="server" />

</header>
        <!--Header Part End-->
        <div class="wrapper">
            <div id="container">

    <h2>Contact Form</h2>
    <div class="content">
    <b>First Name:</b><br />
    <input type="text" name="name" id="name" runat="server" maxlength="50" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="name"></asp:RequiredFieldValidator>
    <br />
        <br />
    <b>E-Mail Address:</b><br />
    <input type="text" name="email" id="email" runat="server" maxlength="50" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="email"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ErrorMessage="Incorrect Email"  ControlToValidate="email" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator>
    <br />

        <br />
        <b>Phone Number</b><br />
    <input type="text" name="phone" id="phone" runat="server" maxlength="50" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="phone"></asp:RequiredFieldValidator>
    <br />
    <b>Enquiry:</b><br />
    <textarea name="enquiry"  id="enquiry" cols="40" rows="10" style="width:98%;" runat="server" maxlength="50"  ></textarea>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="enquiry"></asp:RequiredFieldValidator>
    <br />
        <br />
    
        </div>
    <div class="buttons">
      <div class="right">
          <asp:Button ID="btn_submit" runat="server" Text="Submit" CssClass="button" 
              onclick="btn_submit_Click" /></div>
    </div>

                    

                    <script type="text/javascript" src="js/jquery.elastislide.js"></script>
                    <script type="text/javascript">
                        $('#carousellatest').elastislide();
                    </script>
                  
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
