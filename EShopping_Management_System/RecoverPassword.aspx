<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecoverPassword.aspx.cs" Inherits="RecoverPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recover Password</title>

    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="css/Custom.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <div>
        <div class="navbar navbar-default navbar-fixed-top" role="navigation">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle " data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle Navagition</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="Default.aspx"><span><img src="icon/safeicons.png" alt="MyShopping" height="35" /></span>E-Shopping</a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="Default.aspx">Home</a></li>
                        <li><a href="#">About</a></li>
                        <li><a href="#">Contact US</a></li>
                        <li><a href="#">Blog-</a></li>
                        <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">Products<b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li class="dropdown-header">Men</li>
                                <li role="separator" class="divider "></li>
                                <li><a href="#">Shirts</a></li>
                                <li><a href="#">Pants</a></li>
                                <li><a href="#">Denims</a></li>
                                <li role="separator" class="divider "></li>
                                <li class="dropdown-header">Women</li>
                                <li role="separator" class="divider "></li>
                                <li><a href="#">Top</a></li>
                                <li><a href="#">Legggings</a></li>
                                <li><a href="#">Denims</a></li>
                            </ul>
                            <li><a href="Signin.aspx">Sign in</a></li>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>

    </div>

    <div class="container">
        <div class="form-horizontal">
        <br />
        <br />
        <br />
            <h2>Reset Password</h2>
            <hr />
            <h3></h3>
            <div class ="form-group">
                <asp:Label ID="lblMsg" CssClass ="col-md-2 control-label" runat="server" Visible="False" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            
            </div>


            <div class ="form-group">
                    <asp:Label ID="lblNewPassword" CssClass ="col-md-2 control-label" 
                        runat="server" Text="Enter New Password : " Visible="False"></asp:Label>
                    <div class ="col-md-3">
                        <asp:TextBox ID="tb_New_Password" CssClass =" form-control" TextNode="Password" 
                            runat="server" Visible="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNewPass" CssClass ="Text-danger" runat="server" ErrorMessage="Enter Your New Password : " ControlToValidate="tb_New_Password" ForeColor="Red"></asp:RequiredFieldValidator>

                    </div>

                </div>

                <div class ="form-group">
                    <asp:Label ID="lblConfirmPassword" CssClass ="col-md-2 control-label" 
                        runat="server" Text="Enter Confirm Password : " Visible="False"></asp:Label>
                    <div class ="col-md-3">
                        <asp:TextBox ID="tb_Confirm_Password" CssClass =" form-control" 
                            TextNode="ConfirmPassword" runat="server" Visible="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPass" CssClass ="Text-danger" runat="server" ErrorMessage="Enter Confirm Password : " ControlToValidate="tb_Confirm_Password" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidatorPass" runat="server" ForeColor="Red"
                            ErrorMessage="Confirm Password Not Matched...Try Again !!!" 
                            ControlToCompare="tb_New_Password" ControlToValidate="tb_Confirm_Password"></asp:CompareValidator>
                    </div>

                </div>

                <div class ="form-group">
                    <div class ="col-md-2"></div>
                    <div class ="col-md-6">
                        <asp:Button ID="btn_Reset_Pass" CssClass ="btn btn-default" runat="server" 
                            Text="Reset" Visible="False" onclick="btn_Reset_Pass_Click"/>
                     </div>
                </div>

        </div>
    </div>

    </form>

    <!-- FOOTER SECTION -->

    <hr />
    <footer class="footer-pos">
        <div class="container">
            <p class="pull-right "><a href="#">Back to top</a></p>
            <p>&copy;2022 snehalrenushe.in &middot; <a href="Default.aspx">Home</a>&middot;<a href="#">About</a>&middot;<a href="#">Contact</a>&middot;<a href="#">Products</a>&middot;</p>
        </div>
    </footer>

    <!-- FOOTER SECTION END-->

</body>
</html>
