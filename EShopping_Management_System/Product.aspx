<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />

    <div style="padding-top:50px">
        <div class="col-md-5">
            <div style="max-width:480px" class="thumbnail">
            <%--for Product Image slider--%>
                <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                  <!-- Indicators -->
                  <ol class="carousel-indicators">
                    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="3"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="4"></li>
                  </ol>

                  <!-- Wrapper for slides -->
                  <div class="carousel-inner" role="listbox">
                      <asp:Repeater ID="rptrImage" runat="server">
                        <ItemTemplate>
                    <div class="item <%# GetActiveImgClass(Container.ItemIndex) %>">
                      <img src="img/Product_Images/<%# Eval("Product_ID") %>/<%# Eval("Img_Name") %><%# Eval("Extenstion") %>" alt="<%# Eval("Img_Name") %>" onerror="this.src='img/Noimg.png'">
                    </div>
                    </ItemTemplate>
                  </asp:Repeater>
                  </div>
                  
                  <!-- Controls -->
                  <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                  </a>
                  <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                  </a>
                </div>
            <%--end Product Image slider--%>
            </div>
        </div>
        <div class="col-md-5">
        
            <asp:Repeater ID="rptrProductDetails" runat="server" OnItemDataBound="rptrProductDetails_ItemDataBound">
       
            <ItemTemplate>
            <div class="divDet1">
                 <h1 class="proNameView"><%# Eval ("Product_Name") %></h1>
                <span class="proOgPriceView"><%# Eval ("Purchase_Price") %></span><span class="proPriceDiscountView"><%#string.Format("{0}",Convert.ToInt64(Eval("Purchase_Price"))-Convert.ToInt64(Eval("Selling_Price"))) %></span>
                <p class="proPriceView">Rs. <%# Eval ("Selling_Price") %></p>
            </div>
            <div >
                <h5 class="h5size">SIZE</h5>
                <div>
                    <asp:radiobuttonlist ID="rblSize" runat="server" RepeatDirection="Horizontal" >
                        <asp:ListItem Value="S" Text="S"></asp:ListItem>
                        <asp:ListItem Value="M" Text="M"></asp:ListItem>
                        <asp:ListItem Value="L" Text="L"></asp:ListItem>
                        <asp:ListItem Value="XL" Text="XL"></asp:ListItem>
                    </asp:radiobuttonlist>
                </div>
            </div>
            <div class="divDet1">
                <asp:button ID="btnAddtoCart" CssClass="mainButton" runat="server" text="ADD TO CART" OnClick="btnAddtoCart_Click"/>
                <asp:Label ID="lblError" CssClass ="text-danger " runat="server" ></asp:Label>
            </div>
            <div class="divDet1">
                <h5 class="h5size"> Description</h5>
                <p><%# Eval ("Description") %></p>

                 <h5 class="h5size">Product_Details"</h5>
                <p><%# Eval ("Product_Details") %>
                </p>
                 <h5 class="h5size">Material & Care</h5>
                <p><%# Eval ("Material_Care") %></p>
            </div>
            <div >
                <p><%# ((int)Eval ("Free_Delivery")==1)? "Free Delivery":"" %></p>
                <p><%# ((int)Eval("30_Day_Ret") == 1) ? "30 Days Returns" : ""%></p>
                <p><%# ((int)Eval("COD") == 1) ? "Cash On Delivery" : ""%></p>
            </div>
        
        <asp:HiddenField ID="hfCatID" runat="server" value='<%#Eval ("Category_ID") %>'/>
        <asp:HiddenField ID="hfSubCatID" runat="server" value='<%#Eval ("Subcategory_ID") %>'/>
        <asp:HiddenField ID="hfGenderID" runat="server" value='<%#Eval ("Gender") %>'/>
        <asp:HiddenField ID="hfBrandID" runat="server" value='<%#Eval ("Brand_ID") %>'/>

        </div>
        </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>

