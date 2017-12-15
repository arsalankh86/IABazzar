<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testpayment.aspx.cs" Inherits="testpayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>



This is the test payment which charge you 1+1 = 2$ which will refund you. 

<%--<form action="https://www.paypal.com/cgi-bin/webscr" method="post">--%>
<form method="get" action="https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=arsalankhankudcs@yahoo.com">
<input type="hidden" name="cmd" value="_xclick">
<%--<input type="hidden" name="business" value="usaimrankhan@gmail.com">--%>
<input type="hidden" name="business" value="arsalankhankudcs@yahoo.com">
<input type="hidden" name="item_name" value="Banasi kurta for man">
<input type="hidden" name="item_number" value="123">
<input type="hidden" name="amount" value="1">
<input type="hidden" name="shipping" value="1">
<input type="hidden" name="currency_code" value="USD">
<input type="hidden" name="invoice" value="76128" />
<input type="hidden" name="return" value="http://www.iabazaar.com/thankyou.aspx?param=123">
<input type="hidden" name="cancel_return" value="http://www.iabazaar.com/cancel.aspx">
<input type="hidden" name="notify_url" value="http://www.iabazaar.com/notify.aspx">
<input type="hidden" name="undefined_quantity" value="1">
<input type="image" src="http://www.paypalobjects.com/en_US/i/btn/x-click-but23.gif" border="0" name="submit" width="68" height="23" 
alt="Make payments with PayPal - it's fast, free and secure!">
</form>

</body>
</html>
