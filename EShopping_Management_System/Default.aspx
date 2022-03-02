<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>E-Shopping Service</title>
    <script src="http://code.jquery.com/jquery-3.5.1.js" integrity="sha256-QWo7LDvxbWT2tbbQ97B53yJnYU3WhH/C8ycbRAkjPDc=" crossorigin="anonymous">

    </script>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="css/Custom.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <script>

        $(document).ready(function myfunction() {
            $("#btnCart").click(function myfunction() {
                window.location.href = "/Cart.aspx";
            });
        });

    </script>

</head>
<body>
    <form id="form1" runat="server">
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
                        <li class ="active"><a href="Default.aspx">Home</a></li>
                        <li><a href="#">About</a></li>
                        <li><a href="#">Contact US</a></li>
                        <li><a href="#">Blog-</a></li>
                        <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">Products<b class="caret"></b></a>
                            <ul class="dropdown-menu">
                            <li><a href="ViewProduct.aspx">All Products</a></li>
                            <li role="separator" class="divider "></li>
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
                                <li><button id="btnCart" class="btn btn-primary navbar-btn" type="button">Cart<span class="badge" id="pCount" runat="server">6</span>
                            
                                </button>
                            </li>
                            <li id="btnSignUP" runat=server><a href="Signup.aspx">Signup</a></li>
                            <li id="btnSignIN" runat=server><a href="Signin.aspx">Sign In</a></li>
                            <li>
                                <asp:Button ID="btnlogout" CssClass="btn btn-default navbar-btn" 
                                            runat="server" Text="Sign Out" onclick="btn_Logout_Click"/>
                            </li>
                        </li>
                    </ul>
                </div>
            </div>
        </div>

        <!-- IMAGE SLIDE SHOW -->

                    <div class="container">
              <h2>Carousel Example</h2>  
              <div id="myCarousel" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                  <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                  <li data-target="#myCarousel" data-slide-to="1"></li>
                  <li data-target="#myCarousel" data-slide-to="2"></li>
                </ol>

                <!-- Wrapper for slides -->
                <div class="carousel-inner">
                  <div class="item active">
                      <img src="img/1.jpg" style="width:100%; height:251px"/>
                      <div class="carousel-caption">
                           <h3>Women Shopping</h3>
                            <p>50% OFF</p>
                            <p><a class="btn btn-lg btn-primary" href="#" role="button">Buy Now</a></p>
                      </div>
                  </div>

                  <div class="item">
                      <img src="img/2.png" style="width:100%; height:251px"/>
                      <div class="carousel-caption">
                           <h3>Acce Mobile Shopping</h3>
                            <p>20% OFF</p>
                      </div>
                  </div>
    
                  <div class="item">
                      <img src="img/3.png" style="width:100%; height:251px"/>
                      <div class="carousel-caption">
                           <h3>On mobile you can get</h3>
                            <p>25% OFF</p>
                      </div>
                  </div>
                </div>

                <!-- Left and right controls -->
                <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                  <span class="glyphicon glyphicon-chevron-left"></span>
                  <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#myCarousel" data-slide="next">
                  <span class="glyphicon glyphicon-chevron-right"></span>
                  <span class="sr-only">Next</span>
                </a>
              </div>
            </div>

        <!-- IMAGE SLIDE SHOW END -->

    </div>

    <hr />
    <div class="container center">
        <div class="row">
            <div class="col-lg-4">
                <img class="img-circle" src="img/iphone11.jpeg" alt="thumb" width="140px" height="140px" />
                <h2>Mobiles</h2>
                <p>The iPhone 11 display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 15.40 centimetres (6.06 inches) diagonally (actual viewable area is less).The iPhone 11 display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 15.40 centimetres (6.06 inches) diagonally (actual viewable area is less).</p>
                <p><a class ="btn btn-default" href="#" role="button">View More &raquo;</a></p>
            </div>
            <div class="col-lg-4">
                <img class="img-circle" src="img/Shoes.jpeg" alt="thumb" width="140px" height="140px" />
                <h2>Footwear</h2>
                <p>The iPhone 11 display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 15.40 centimetres (6.06 inches) diagonally (actual viewable area is less).The iPhone 11 display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 15.40 centimetres (6.06 inches) diagonally (actual viewable area is less).</p>
                <p><a class ="btn btn-default" href="#" role="button">View More &raquo;</a></p>
            </div>
            <div class="col-lg-4">
                <img class="img-circle" src="img/tshirt.jpeg" alt="thumb" width="140px" height="140px" />
                <h2>Clothing</h2>
                <p>The iPhone 11 display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 15.40 centimetres (6.06 inches) diagonally (actual viewable area is less).The iPhone 11 display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 15.40 centimetres (6.06 inches) diagonally (actual viewable area is less).</p>
                <p><a class ="btn btn-default" href="#" role="button">View More &raquo;</a></p>
            </div>
        </div>
    </div>

    <!-- FOOTER SECTION -->
    <hr />
    <footer>
        <div class="container">
            <p class="pull-right "><a href="#">Back to top</a></p>
            <p>&copy;2022 snehalrenushe.in &middot; <a href="Default.aspx">Home</a>&middot;<a href="#">About</a>&middot;<a href="#">Contact</a>&middot;<a href="#">Products</a>&middot;</p>
        </div>
    </footer>

    <!-- FOOTER SECTION END-->

    </form>
    <script type="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
