<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Visitor_rpt.aspx.cs" Inherits="Admin_Visitor_rpt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="float:left;">

    <asp:GridView ID="grdcount1" runat="server" Width="748px" 
            BackColor="White" BorderColor="#336666" 
                          BorderStyle="Double" BorderWidth="3px" CellPadding="4">
        <RowStyle BackColor="White" ForeColor="#333333" />
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
   
    <br />
    <br />
       <asp:GridView ID="GridView1" runat="server" Width="748px" 
            BackColor="White" BorderColor="#336666" 
                          BorderStyle="Double" BorderWidth="3px" CellPadding="4">
        <RowStyle BackColor="White" ForeColor="#333333" />
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
     <br />
    <br />
    <asp:GridView ID="grdipcount" runat="server" Width="748px" 
            BackColor="White" BorderColor="#336666" 
                          BorderStyle="Double" BorderWidth="3px" CellPadding="4">
        <RowStyle BackColor="White" ForeColor="#333333" />
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    
    </div>
    </form>
</body>
</html>
