<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserHome.aspx.cs" Inherits="UserHome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Home Page</title>

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
                            <li>
                                <asp:Button ID="btn_Logout" CssClass="btn btn-default navbar-btn" runat="server" Text="Sign Out" />
                            </li>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    </div>
    <br /><br /><br /><br />

    <asp:Label ID="lbl_Success" runat="server" CssClass="text-success"></asp:Label>

    <!-- FOOTER SECTION -->

    <hr />
    <footer class="footer-pos">
        <div class="container">
            <p class="pull-right "><a href="#">Back to top</a></p>
            <p>&copy;2022 snehalrenushe.in &middot; <a href="Default.aspx">Home</a>&middot;<a href="#">About</a>&middot;<a href="#">Contact</a>&middot;<a href="#">Products</a>&middot;</p>
        </div>
    </footer>

    <!-- FOOTER SECTION END-->
    </form>
</body>
</html>
