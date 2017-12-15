<%@ Page Language="C#" AutoEventWireup="true" CodeFile="checkoutanon.aspx.cs" Inherits="checkoutanon" %>

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
    <title>Buy Indian Pakistani Salwar Kameez Online</title>
    <link rel="shortcut icon" type="image/x-icon" href="images/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="css/stylesheet.css" media="screen" />
    <!--<link href='http://fonts.googleapis.com/css?family=Carme' rel='stylesheet' type='text/css' />-->
    <script src="js/jquery/jquery-1.8.2.min.js"></script>
    <script src="js/jquery/ui/jquery-ui-1.8.16.custom.min.js"></script>
    <script src="js/jquery/ui/external/jquery.cookie.js"></script>
    <script src="js/common.js"></script>
    <script src="js/html5.js"></script>
    <script src="js/jquery.tooltipster.min.js"></script>
    <script src="js/custom.js"></script>
    <link rel="stylesheet" type="text/css" href="css/facebook.css" />
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
                    <div class="breadcrumb">
                        <a href="index-2.html" title="Home">Home</a> &raquo; <a href="cart.html" title="Shopping Cart">
                            Shopping Cart</a> &raquo; <a href="checkout.html" title="Checkout">Checkout</a>
                    </div>
                    <h1>
                        <span>Checkout</span></h1>
                    <div class="checkout">
                        <div id="checkout">
      <div class="checkout-heading">Order Information</div>
      <div class="checkout-content"></div>
   <asp:Repeater ID="dtlcart" runat="server">
                    <HeaderTemplate>
      <table class="list">
    <thead>
      <tr>
        <td class="left">Product Name</td>
        <td class="left">Model</td>
        <td class="right">Quantity</td>
        <td class="right">Price</td>
        <td class="right">Total</td>
                
              </tr>
    </thead>
    </HeaderTemplate>        
    <ItemTemplate>
    <tbody>
            <tr>
        <td class="left"><%# Eval("Name")%> </td>
        <td class="left">Product 14</td>
        <td class="right"><%# Eval("Quantity") %></td>
        <td class="right">$<%# Eval("ProductPrice")%></td>
        <td class="right">$<%# Eval("CartTotal")%></td>
        
      </tr>

                </tbody>
                </ItemTemplate>
                <FooterTemplate>
                </table>
                
                </FooterTemplate>

    

  </asp:Repeater>
<table align="right">
  
            <tr>
        <td colspan="3"></td>
        <td class="right"><b>Sub-Total:</b></td>
        <td class="right">$<asp:Label ID="lblsubtotal" runat="server" Text="[Subtotal]"></asp:Label></td>
                <td></td>
              </tr>
            <tr>
        <td colspan="3"></td>
        <td class="right"><b>Flat Shipping Rate:</b></td>
        <td class="right">$<asp:Label ID="lblShipping" runat="server" Text="[Shipping]"></asp:Label></td>
                <td></td>
              </tr>
            <tr>
        <td colspan="3"></td>
        <td class="right"><b>Total:</b></td>
        <td class="right">$<asp:Label ID="lbltotal" runat="server" Text="[Total]"></asp:Label></td>
                <td></td>
              </tr>
  </table>

    </div>
    <br />
    <br />
    <br />
    <br />
     <br />
     <div>
     <table>
     <tr>
     <td>First Name :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
     <td><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox> 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Please Enter First Name"
                                            ForeColor="Red" 
             ControlToValidate="txtFirstName">*</asp:RequiredFieldValidator>
         </td>
     </tr>
      <tr>
     <td>Last Name :</td>
     <td><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox> 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Please Enter First Name"
                                            ForeColor="Red" 
             ControlToValidate="txtLastName">*</asp:RequiredFieldValidator>
          </td>
     </tr>
      <tr>
     <td>E-Mail :</td>
     <td><asp:TextBox ID="txtEMail" runat="server"></asp:TextBox> 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="Please Enter First Name"
                                            ForeColor="Red" 
             ControlToValidate="txtEMail">*</asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
             ErrorMessage="Invalid Email" ControlToValidate="txtEMail" 
             ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

          </td>
     </tr>
     </table>
     </div>
    <br />
    <br />
                        <div id="payment-address">
                            <div class="checkout-heading">
                                <span>Shipping Details</span></div>
                            <%--<div class="checkout-content" style="display: block;">
      	<input type="radio" checked="checked" id="payment-address-existing" value="existing" name="payment_address">
		<label for="payment-address-existing">I want to use an existing address</label>
        <div id="payment-existing">
          <select size="5" style="width: 100%; margin-bottom: 15px;" name="address_id">
                    <option selected="selected" value="6">shakti pattanaik, Bhubaneswar, Bhubaneswar, Orissa, India</option>
                        <option value="16">shakti pattanaik, Bhubaneswar, Bhubaneswar, Orissa, India</option>
                        <option value="17">shakti pattanaik, Bhubaneswar, Bhubaneswar, Orissa, India</option>
                  </select>
        </div>
        <p>
          <input type="radio" id="payment-address-new" value="new" name="payment_address">
          <label for="payment-address-new">I want to use a new address</label>
        </p>
        <div class="buttons">
          <div class="right"><input type="button" class="button" id="button-payment-address" value="Continue"></div>
        </div>
 
		</div>--%>
                            <table>
                                <tr>
                                    <td class="style7">
                                        Shipping Phone :
                                    </td>
                                    <td class="style6">
                                        <asp:TextBox ID="txtship_Phone" runat="server" Width="169px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter First Name"
                                            ForeColor="Red" ControlToValidate="txtship_Phone">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style7">
                                        Shipping Address 1 :
                                    </td>
                                    <td class="style6">
                                        <asp:TextBox ID="txtship_Address" runat="server" Width="169px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Last Name"
                                            ForeColor="Red" ControlToValidate="txtship_Address">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style7">
                                        Shipping Address 2 :
                                    </td>
                                    <td class="style6">
                                        <asp:TextBox ID="txtship_Address2" runat="server" Width="169px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please Enter Last Name"
                                            ForeColor="Red" ControlToValidate="txtship_Address2">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style7">
                                        Shipping State :
                                    </td>
                                    <td class="style6">
                                        <asp:TextBox ID="txtship_State" runat="server" Width="169px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Please Enter Phone Number"
                                            ForeColor="Red" ControlToValidate="txtship_State">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style7">
                                        Shipping Zip :
                                    </td>
                                    <td class="style6">
                                        <asp:TextBox ID="txtship_Zip" runat="server" Width="169px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Phone Number"
                                            ForeColor="Red" ControlToValidate="txtship_Zip">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                       <tr>
                                    <td class="style7">
                                        Shipping City
                                        :</td>
                                    <td class="style6">
                                        <asp:TextBox ID="txtshipcity" runat="server" Width="169px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter Phone Number"
                                            ForeColor="Red" ControlToValidate="txtshipcity">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style7">
                                        Shipping Country :
                                    </td>
                                    <td class="style6">
                                        <asp:TextBox ID="txtship_Country" runat="server" Width="169px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter Phone Number"
                                            ForeColor="Red" ControlToValidate="txtship_Country">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />
                        <div id="shipping-address">
                            <div class="checkout-heading">
                                Billing Details</div>
                            <div class="checkout-content">
                            </div>
                            <table>
                                <tr>
                                    <td class="style7">
                                    
 &nbsp;<asp:CheckBox ID="chkbilldif" runat="server" AutoPostBack="True" oncheckedchanged="CheckBox1_CheckedChanged" value="1" />
                                       <%-- <input type="checkbox" id="chkbilling" name="chkblling" runat="server" value="1" />--%>
                                    </td>
                                    <td class="style6">
                                        Checkbox this box if your billing address is different
                                    </td>
                                </tr>
                                <asp:Panel ID="Panel1" runat="server" Visible="false">
                                
                               <tr>
                                    <td class="style7">
                                        Billing Phone :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td class="style6">
                                        <asp:TextBox ID="txtBll_Phone" runat="server" Width="169px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Enter First Name"
                                            ForeColor="Red" ControlToValidate="txtBll_Phone">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style7">
                                        Billing Address :
                                    </td>
                                    <td class="style6">
                                        <asp:TextBox ID="txtBll_Address" runat="server" Width="169px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Enter Last Name"
                                            ForeColor="Red" ControlToValidate="txtBll_Address">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="style7">
                                        Billing Address 2:
                                    </td>
                                    <td class="style6">
                                        <asp:TextBox ID="txtBll_Address2" runat="server" Width="169px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please Enter Last Name"
                                            ForeColor="Red" ControlToValidate="txtBll_Address2">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style7">
                                        Billing State :
                                    </td>
                                    <td class="style6">
                                        <asp:TextBox ID="txtBll_State" runat="server" Width="169px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Enter Phone Number"
                                            ForeColor="Red" ControlToValidate="txtBll_State">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style7">
                                        Billing Zip :
                                    </td>
                                    <td class="style6">
                                        <asp:TextBox ID="txtBll_Zip" runat="server" Width="169px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Please Enter Phone Number"
                                            ForeColor="Red" ControlToValidate="txtBll_Zip">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style7">
                                        Billing Country :
                                    </td>
                                    <td class="style6">
                                        <asp:TextBox ID="txtBll_Country" runat="server" Width="169px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Please Enter Phone Number"
                                            ForeColor="Red" ControlToValidate="txtBll_Country">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style7">
                                        Billing City :
                                    </td>
                                    <td class="style6">
                                        <asp:TextBox ID="txtBll_City" runat="server" Width="169px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Please Enter Phone Number"
                                            ForeColor="Red" ControlToValidate="txtBll_City">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                </asp:Panel>
                            </table>
                        </div>
                        <div id="payment-method">
                            <div class="checkout-heading">
                                Payment Method</div>
                            <div class="checkout-content">
                            </div>

                            <asp:RadioButton ID="RadioButton1" runat="server" Checked="true" Text="Paypal Express" /> &nbsp; <img id="ctl00_PageContent_ctrlPaymentMethod_imgPAYPALEXPRESS" 
                                                src="Images/paypal2.gif"
                                                style="margin: 0px; border: 0px none;" />
                            <span style="color: rgb(255, 0, 0); font-family: Arial, Helvetica, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: bold; letter-spacing: normal; line-height: normal; orphans: auto; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(231, 231, 231); display: inline !important; float: none;">
                            <br />
                            <br />
                            After you make your PayPal payment (by clicking the button below), you<span 
                                class="Apple-converted-space">&nbsp;</span></span><b 
                                style="margin: 0px; font-size: 13px; color: rgb(255, 0, 0); font-family: Arial, Helvetica, sans-serif; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(231, 231, 231);">must</b><span 
                                style="color: rgb(255, 0, 0); font-family: Arial, Helvetica, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: bold; letter-spacing: normal; line-height: normal; orphans: auto; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(231, 231, 231); display: inline !important; float: none;"><span 
                                class="Apple-converted-space">&nbsp;</span>click the<span 
                                class="Apple-converted-space">&nbsp;</span></span><b 
                                style="margin: 0px; font-size: 13px; color: rgb(255, 0, 0); font-family: Arial, Helvetica, sans-serif; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(231, 231, 231);">&quot;Return 
                            To Merchant&quot;</b><span 
                                style="color: rgb(255, 0, 0); font-family: Arial, Helvetica, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: bold; letter-spacing: normal; line-height: normal; orphans: auto; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(231, 231, 231); display: inline !important; float: none;"><span 
                                class="Apple-converted-space">&nbsp;</span>button that will appear on the PayPal 
                            site. That will allow our store to complete your order!</span></div>
                    </div>
                </div>
                <div class="clear">
                <div class="buttons">
                    <div class="right">
                    <asp:ImageButton ID="btnContinue" runat="server" Text="Continue" ImageUrl="~/Images/btn_paypal.jpg"
                            onclick="btnContinue_Click" />
                    </div>
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


//        function chkbilling_onclick() {

//        }

//        function chkbilling_onclick()
//        {

//        }

    </script>
    <!--end of Scroll back to top-->
</body>
</html>
