<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Login.aspx.cs" Inherits="Admin_Admin_Login" %>

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
    <td>Name: </td>
    <td><asp:TextBox ID="txtUser_Name" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtUser_Name" ErrorMessage="*"></asp:RequiredFieldValidator> </td>   
    </tr>
    
    <tr>
    <td>Password: </td>
    <td><asp:TextBox ID="txtUser_Password" runat="server" TextMode="Password" ></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="*" ControlToValidate="txtUser_Password"></asp:RequiredFieldValidator> </td>   
    </tr>

    
    <tr runat="server" id="errormesstr" visible="false">
    <td colspan="2">
    <asp:Label ID="LabelError" runat="server" Visible="false" Text="Error: Password incorrect!" ForeColor="Red" ></asp:Label>
    </td>    
    
   <%--<tr runat="server" id="error" visible="true">
    <<td colspan="2"><a href=""><font size="1" color="blue">Forget Password</font></a>
    </tr>
    <asp:Label ID="LabeForget" runat="server" Visible="true" Text=" Forget Password !" ForeColor="blue" ></asp:Label>
    </td> --%>   
    
    </tr>
    
    </table>
        <asp:Button ID="btnLogin" runat="server" Text="Login" 
            onclick="btnLogin_Click" />

    
    </div>
    </form>
</body>
</html>
