<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class ="container">
       <div class ="form-horizontal">
           
           <br />
           <br />
           <h2>Add Product</h2>
           <hr />

           <div class ="form-group">
               <asp:Label ID="Label1" runat="server" CssClass ="col-md-2 control-label" Text="Proudct Name"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="tb_Product_Name" CssClass ="form-control" runat="server"></asp:TextBox>


               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label2" runat="server" CssClass ="col-md-2 control-label" Text="Price"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="tb_Price" CssClass ="form-control" runat="server"></asp:TextBox>
               </div>
           </div>


           <div class ="form-group">
               <asp:Label ID="Label3" runat="server" CssClass ="col-md-2 control-label" Text="SellingPrice"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="tb_sell_Price" CssClass ="form-control" runat="server"></asp:TextBox>
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label4" runat="server" CssClass ="col-md-2 control-label" Text="Brand"></asp:Label>
               <div class ="col-md-3">
                   <asp:DropDownList ID="ddlBrand" CssClass ="form-control" runat="server"></asp:DropDownList>
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label5" runat="server" CssClass ="col-md-2 control-label" Text="Category"></asp:Label>
               <div class ="col-md-3">
                   <asp:DropDownList ID="ddl_Category" CssClass ="form-control" runat="server"></asp:DropDownList>
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label6" runat="server" CssClass ="col-md-2 control-label" Text="SubCategory"></asp:Label>
               <div class ="col-md-3">
                   <asp:DropDownList ID="ddl_SubCategory" CssClass ="form-control" runat="server"></asp:DropDownList>
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label19" runat="server" CssClass ="col-md-2 control-label" Text="Gender"></asp:Label>
               <div class ="col-md-3">
                   <asp:DropDownList ID="ddl_Gender" CssClass ="form-control" runat="server"></asp:DropDownList>
               </div>
           </div>

            <div class ="form-group">
               <asp:Label ID="Label7" runat="server" CssClass ="col-md-2 control-label" Text="Size"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="tb_Dynamic_size" CssClass ="form-control" runat="server"></asp:TextBox>
               </div>
           </div>

            <div class ="form-group">
               <asp:Label ID="Label8" runat="server" CssClass ="col-md-2 control-label" Text="Description"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="tb_Description" TextMode ="MultiLine"  CssClass ="form-control" runat="server"></asp:TextBox>
               </div>
           </div>

            <div class ="form-group">
               <asp:Label ID="Label9" runat="server" CssClass ="col-md-2 control-label" Text="Product Details"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="tb_P_Detail" TextMode ="MultiLine" CssClass ="form-control" runat="server"></asp:TextBox>
               </div>
           </div>

           
            <div class ="form-group">
               <asp:Label ID="Label10" runat="server" CssClass ="col-md-2 control-label" Text="Materials and Care"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="tb_Mat_Care" TextMode ="MultiLine" CssClass ="form-control" runat="server"></asp:TextBox>
               </div>
           </div>

            <div class ="form-group">
               <asp:Label ID="Label11" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image"></asp:Label>
               <div class ="col-md-3">
                   <asp:FileUpload ID="fuImg01" CssClass ="form-control" runat="server" />
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label12" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image"></asp:Label>
               <div class ="col-md-3">
                   <asp:FileUpload ID="fuImg02" CssClass ="form-control" runat="server" />
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label13" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image"></asp:Label>
               <div class ="col-md-3">
                   <asp:FileUpload ID="fuImg03" CssClass ="form-control" runat="server" />
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label14" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image"></asp:Label>
               <div class ="col-md-3">
                   <asp:FileUpload ID="fuImg04" CssClass ="form-control" runat="server" />
               </div>
           </div>



            <div class ="form-group">
               <asp:Label ID="Label15" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image"></asp:Label>
               <div class ="col-md-3">
                   <asp:FileUpload ID="fuImg05" CssClass ="form-control" runat="server" />
               </div>
           </div>

            <div class ="form-group">
               <asp:Label ID="Label16" runat="server" CssClass ="col-md-2 control-label" Text="Free Delivery"></asp:Label>
               <div class ="col-md-3">
                   <asp:CheckBox ID="ch_Free_Delivery" runat="server" />
               </div>
           </div>


            <div class ="form-group">
               <asp:Label ID="Label17" runat="server" CssClass ="col-md-2 control-label" Text="30 Days Return"></asp:Label>
               <div class ="col-md-3">
                   <asp:CheckBox ID="ch_30_Ret" runat="server" />
               </div>
           </div>


            <div class ="form-group">
               <asp:Label ID="Label18" runat="server" CssClass ="col-md-2 control-label" Text="COD"></asp:Label>
               <div class ="col-md-3">
                   <asp:CheckBox ID="cb_COD" runat="server" />
               </div>
           </div>


           <div class ="form-group">
                    <div class ="col-md-2 "> </div>
                    <div class ="col-md-6 ">

                        <asp:Button ID="btn_Add" CssClass ="btn btn-success " runat="server" 
                            Text="ADD Product" onclick="btn_Add_Click"/>
                        
                    </div>
                </div>
       </div>

    </div>
</asp:Content>

