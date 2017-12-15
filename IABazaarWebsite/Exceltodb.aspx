<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exceltodb.aspx.cs" Inherits="Exceltodb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <%--<asp:Button ID="Button1" runat="server" Text="OBProducts" 
            onclick="Button1_Click" />--%>

        <asp:Button ID="Button2" runat="server" Text="OBExcelImageIssue" 
            onclick="Button2_Click1" />
        
        <asp:Button ID="Button3" runat="server" Text="OBExcelSENameIssue" 
            onclick="Button3_Click" />
        
        <br />
        <br />
        <br />
        <asp:Button ID="btnunstiched" runat="server" Text="Unstiched Category" 
            onclick="btnunstiched_Click" />

            <asp:Button ID="btnunstichedrod" runat="server" Text="Unstiched Product" onclick="btnunstichedrod_Click" 
             />
        
        <br />
        <br />
        
        <br />
        <asp:Button ID="btnstiched" runat="server" Text="Stiched Category" 
            onclick="btnstiched_Click" />
             <asp:Button ID="btnstichedprod" runat="server" Text="Stiched Product" 
            onclick="btnstichedprod_Click" />
        <br />
        <br />
        <br />
        <asp:Button ID="btnfrzcresentlawn" runat="server" 
            Text="Fraz Manan Cresent Lawn Category" onclick="btnfrzcresentlawn_Click" />
              <asp:Button ID="btnfrzcresentlawnprod" runat="server" 
            Text="Fraz Manan Cresent Lawn Product" 
            onclick="btnfrzcresentlawnprod_Click"  />
        <br />
        <br />
         <asp:Button ID="btnnacat" runat="server" 
            Text="New Arrival Category" onclick="btnnacat_Click" />
              <asp:Button ID="btnnaprod" runat="server" 
            Text="New Arrival Product" onclick="btnnaprod_Click" 
             />
            <br />
            <br />
              <asp:Button ID="indianwear" runat="server" 
            Text="Indian wear" onclick="indianwear_Click" />
            <br />
            <br />
              <asp:Button ID="btnmeta" runat="server" 
            Text="Product Detail Page Meta" onclick="btnmeta_Click" 
            style="height: 26px"/>
        <asp:Label ID="lblerror" runat="server" Text="Label"></asp:Label>
        
        </div>
    </form>
</body>
</html>
