<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br /><br /><br />

    <div style="padding-top:50px;">
        
        <div class="col-md-9">
        <h4 class="proNameViewCart" runat="server" id="h4Noitems"></h4>
       
        <asp:Repeater ID="rptrCartProducts" runat="server">
        <ItemTemplate>
        <%--Cart Details Start--%>

        <div class="media" style="border:1px solid black;">
            <div class="media-left"> 
                <a href="Product.aspx?Product_ID=<%# Eval("Product_ID") %>" target="_blank">
                    <img class="media-object" width="100px" src="img/Product_Images/<%# Eval("Product_ID") %>/<%# Eval("Img_Name") %><%# Eval("Extenstion") %>" alt="<%# Eval("Img_Name")%>" onerror="this.src='img/Noimg.png'"/>
                </a>
            </div>

            <div class="media-body"> 
                <h4 class="media-heading proNameViewCart"><%# Eval("Product_Name")%></h4>
                <p class="oriPriceDiscountView"><%# Eval ("SizeNamee") %></p>
                <span class="proPriceView"><%# Eval("Selling_Price","{0:c}")%></span>
                <span class="proOgPriceView"><%# Eval("Purchase_Price","{0:0,00}")%></span>
                <p>
                    <asp:Button CommandArgument='<%#Eval("Product_ID")+"-"+ Eval("SizeIDD")%>' ID="btnRemoveCart" cssClass="RemoveButton" runat="server" 
                        Text="REMOVE" OnClick="btnRemoveCart_Click"/>
                </p>
            </div>

        </div>
        </ItemTemplate>
        </asp:Repeater>
        <%--Cart Details End--%>
        </div>
        
        <div class="col-md-3 pt-5" runat="server" id="divpricedetails">

            <div style="border-bottom: 1px solid #eaeaec;">
                <h5>PRICE DETAILS</h5>

                <div>
                    <label>Cart Total</label>
                    <span class="pull-right PriceGray" runat="server" id="spanCartTotal"></span>
                </div>

                <div>
                    <label>Cart Discount</label>
                    <span class="pull-right PriceGreen" id="spanDiscount" runat="server"></span>
                </div>
            
            </div>
            
            <div>
                <div class="proPriceView">
                    <label>Total</label>
                    <span class="float-right" id="spanTotal" runat="server"></span>
                </div>
                <div>
                    <asp:Button ID="btnBuyNow" OnClick="btnBuy_Click" CssClass="buyNowbtn" runat="server" Text="BUY NOW" />
                </div>
            
            </div>

        </div>

    </div>

</asp:Content>

