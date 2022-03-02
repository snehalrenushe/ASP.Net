<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="ViewProduct.aspx.cs" Inherits="ViewProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <br />
    <br />

    <h3>Welcome to View all Product</h3>


    <div class="row" style="padding-top:50px">
       <asp:repeater ID="rptrProducts" runat="server">
           <ItemTemplate>
        <div class="col-sm-3 col-md-3">
        <a href="Product.aspx?Product_ID=<%# Eval("Product_ID") %>" style="text-decoration: none">
          <div class="thumbnail">              
              <img src="img/Product_Images/<%# Eval("Product_ID") %>/<%# Eval("Img_Name") %><%# Eval("Extenstion") %>" alt="<%# Eval("Img_Name") %>"/>
              <div class="caption"> 
                   <div class="probrand"><%# Eval ("Brand_Name") %>  </div>
                   <div class="proName"> <%# Eval ("Product_Name") %> </div>
                   <div class="proPrice"> <span class="proOgPrice" > <%# Eval ("Purchase_Price") %> </span> <%# Eval ("Selling_Price") %> <span class="proPriceDiscount"> (<%# Eval("DiscAmount")%>off) </span></div> 
              </div>
          </div>
        </div>
        </a>
               </ItemTemplate>
       </asp:repeater>
    </div>



</asp:Content>

