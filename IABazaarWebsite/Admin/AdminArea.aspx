<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminArea.aspx.cs" Inherits="Admin_AdminArea" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
        <asp:LinkButton ID="lnkcat" runat="server" onclick="LinkButton1_Click">Category</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="lnkprod" runat="server" onclick="LinkButton2_Click">Product</asp:LinkButton>
         <br />
        <br />
        <asp:LinkButton ID="lnkvisitor" runat="server" onclick="LinkButton3_Click" >Visitor </asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="lnkorders" runat="server" onclick="LinkButton4_Click"  >Sales</asp:LinkButton>
         <br />
        <br />
        <asp:LinkButton ID="lnkContactUs" runat="server" onclick="lnkContactUs_Click1" >Contact Us </asp:LinkButton>

        <br />
        <br />
       <%-- <asp:LinkButton ID="lnklogout" runat="server" onclick="lnklogout_Click" >Logout</asp:LinkButton>--%>
    </div>
    </form>
</body>
</html>
