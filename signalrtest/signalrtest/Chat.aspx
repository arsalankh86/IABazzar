<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="signalrtest.Chat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Signal R Chat</title>
    <script src="Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.signalR-1.1.4.min.js" type="text/javascript"></script>
    <script src="signalr/hubs" type="text/javascript"></script>

</head>
<body>

<script type="text/javascript">

    $(function () {


        var iwanachat = $.connection.myChatHub;


        iwanachat.client.sendMessage = function (message) {

            $("#lst").append('<li>' + message + '</li>');
        };

        $("#sendmessage").click(function(){
                iwanachat.server.send($('#txt').val());

                });
               

               $.connection.hub.start();


    });



</script>

   <div>
   <input type="text" id="txt" />

   <input type="button" id="sendmessage" />
   
   <ul id="lst"></ul>   
   
   </div>
</body>
</html>
