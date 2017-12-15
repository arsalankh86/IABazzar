<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Orderhistory.aspx.cs" Inherits="My_Account_Orderhistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>


       <asp:HiddenField ID="hdncustomerid" runat="server" />
     <asp:GridView ID="gview" runat="server">
    </asp:GridView>


    </div>
    </form>
</body>
</html>
