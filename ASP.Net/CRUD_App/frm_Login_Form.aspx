<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_Login_Form.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CRUD Application</title>
    <style type="text/css">
        #form1
        {
            height: 172px;
        }
        
        body
        {
            background-color: #FFCCFF;    
        }
    </style>
</head>
<body style="height: 395px; width: 1580px; margin-left: 11px;">
    <form id="form1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="118px" style="margin-left: 455px" 
        Width="553px">
        <h1 style="height: 141px; width: 861px">
            <asp:Label ID="lbl_Login_Form" runat="server" Font-Size="XX-Large" 
                style="font-family: 'Copperplate Gothic Bold'; font-size: 70px; color: #FF0000; background-color: #66FFCC" 
                Text="Login Form"></asp:Label>
        </h1>
    </asp:Panel>

    <div>   
    <asp:Panel ID="Panel2" runat="server" Height="86px" style="margin-left: 267px" 
        Width="1000px">
        <h2>
            <asp:Label ID="lbl_Username" runat="server" 
                style="font-family: 'Times New Roman', Times, serif; font-size: 45px; color: #3333CC" 
                Text="Username"></asp:Label>
            <asp:TextBox ID="tb_Username" runat="server" Font-Size="20px" Height="30px" 
                style="margin-left: 275px; font-family: 'Times New Roman', Times, serif;" 
                Width="321px" TabIndex="1"></asp:TextBox>
        </h2>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server" Height="86px" style="margin-left: 267px" 
        Width="1000px">
        <h2>
            <asp:Label ID="lbl_Password" runat="server" 
                style="font-family: 'Times New Roman', Times, serif; font-size: 45px; color: #3333CC" 
                Text="Password"></asp:Label>
            <asp:TextBox ID="tb_Password" runat="server" Font-Size="20px" Height="30px" 
                style="margin-left: 282px; font-family: 'Times New Roman', Times, serif;" 
                Width="321px" MaxLength="10" TabIndex="2"></asp:TextBox>
        </h2>
    </asp:Panel>
    <asp:Panel ID="Panel4" runat="server" Height="86px" style="margin-left: 267px" 
        Width="1000px">
        <h2 style="width: 188px; height: 41px; margin-left: 253px">
            <asp:Button ID="btn_Submit" runat="server" Font-Size="30px" Height="44px" 
                style="font-family: 'Book Antiqua'; color: #006600; font-weight: 700; margin-left: 0px; background-color: #FFFF99" 
                Text="Submit" Width="190px" Enabled="False" TabIndex="3" />
        </h2>
    </asp:Panel>
    </div>
    

    </form>
    </body>
</html>
