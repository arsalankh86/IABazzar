<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add_Product.aspx.cs" Inherits="Add_Product" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td>Category:</td>
    <td><asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList> </td>
     </tr>
    <tr>
    <td>Name:</td>
    <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox> </td>
    </tr>
    <tr>
    <td>SEName:</td>
    <td><asp:TextBox ID="txtSEName" runat="server"></asp:TextBox> </td>
    </tr>

    <tr>
    <td>Description:</td>
    <td><asp:TextBox ID="txtDescription" runat="server"></asp:TextBox> </td>
    </tr>
   <tr>
    <td>Summary:</td>
    <td><asp:TextBox ID="txtSummary" runat="server"></asp:TextBox> </td>
    </tr>
     <tr>
    <td>Cost in Rupee:</td>
    <td><asp:TextBox ID="txtCostinrupee" runat="server" AutoPostBack="True" 
            ontextchanged="txtCostinrupee_TextChanged"></asp:TextBox> </td>
    </tr>
     <tr>
    <td>Cost in Dollar:</td>
    <td><asp:TextBox ID="txtCostindollar" runat="server" 
            ></asp:TextBox> </td>
    </tr>
    
     <tr>
    <td>Profit Price in Rupee:</td>
    <td><asp:TextBox ID="txtProfitpriceinrupee" runat="server" 
           ></asp:TextBox> </td>
    </tr>
     <tr>
    <td>Profit Price in Dollar:</td>
    <td><asp:TextBox ID="txtProfitpriceindollar" runat="server" 
            ></asp:TextBox> </td>
    </tr>
     <tr>
    <td>Profit:</td>
    <td><asp:TextBox ID="txtprofit" runat="server" 
            ></asp:TextBox> </td>
    </tr>
     <tr>
    <td>StichedPrice:</td>
    <td><asp:TextBox ID="txtStichedPrice" runat="server"></asp:TextBox> </td>
    </tr>
     <tr>
    <td>Image:</td>
    <td><asp:TextBox ID="txtimage" runat="server"></asp:TextBox> </td>
    </tr>
    <tr>
    <td>Type:</td>
    <td>
    <asp:DropDownList ID="ddlType" runat="server">
     <asp:ListItem Value="Stiched"> Stiched  </asp:ListItem>
     <asp:ListItem Value="Unstiched"> Unstiched  </asp:ListItem>

        </asp:DropDownList>
         </td>
    </tr>      
    </table>

        <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
            onclick="btnSubmit_Click" />

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
    
    </div>
        





    </form>
</body>
</html>
