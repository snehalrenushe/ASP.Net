<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddSize.aspx.cs" Inherits="AddSize" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class ="container ">
            <div class ="form-horizontal ">
                <br />
                <br />

                <h2>Add Size</h2>
                <hr />

                <div class ="form-group">
                    <asp:Label ID="Label1" CssClass ="col-md-2 control-label " runat="server" Text="Size Name"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:TextBox ID="tb_Size" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSize" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter Size" ControlToValidate="tb_Size" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                 <div class ="form-group">
                    <asp:Label ID="Label3" CssClass ="col-md-2 control-label " runat="server" Text="Brand"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:DropDownList ID="ddlBrand" CssClass ="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorddlBrand" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter Main CategoryID" ControlToValidate="ddlBrand" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class ="form-group">
                    <asp:Label ID="Label4" CssClass ="col-md-2 control-label " runat="server" Text="Category"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:DropDownList ID="ddlCategory" CssClass ="form-control" runat="server" 
                            AutoPostBack="true" onselectedindexchanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategory" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter  Category" ControlToValidate="ddlCategory" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
              
                <div class ="form-group">
                    <asp:Label ID="Label2" CssClass ="col-md-2 control-label " runat="server" Text="Sub Category"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:DropDownList ID="ddlSubCategory" CssClass ="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSubCategory" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter Sub Category" ControlToValidate="ddlSubCategory" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>                   

                <div class ="form-group">
                    <asp:Label ID="Label5" CssClass ="col-md-2 control-label " runat="server" Text="Gender"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:DropDownList ID="ddlGender" CssClass ="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter Gender" ControlToValidate="ddlGender" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>    

                <div class ="form-group">
                    <div class ="col-md-2 "> </div>
                    <div class ="col-md-6 ">

                        <asp:Button ID="btn_Add_Size" CssClass ="btn btn-success " runat="server" 
                            Text="Add Size" onclick="btn_Add_Size_Click"/>
                        
                    </div>
                </div>
            </div>

<h1>Size</h1>
        <hr />

 <div class="panel panel-default">

               <div class="panel-heading"> All Sizes</div>

     <asp:repeater ID="rptrSize" runat="server">

         <HeaderTemplate>
             <table class="table">
                  <thead>
                    <tr>
                        <th>ID</th>
                        <th>Size Name</th>
                        <th>Brand</th>
                        <th>Category</th>
                         <th>Subcategory</th>
                         <th>Gender ID</th>
                        <th>Edit</th>

                    </tr>

                </thead>



            <tbody>
         </HeaderTemplate>

         <ItemTemplate>
             <tr>
                    <th> <%# Eval("Size_ID") %> </th>
                    <td><%# Eval("Size_Name") %>   </td>
                  <td><%# Eval("Brand_Name") %>   </td>
                  <td><%# Eval("Category_Name") %>   </td>
                   <td><%# Eval("SubCategory_Name") %>   </td>
                   <td><%# Eval("Gender_Name") %>   </td>
                    <td>Edit</td>
                </tr>
         </ItemTemplate>

         <FooterTemplate>
             </tbody>

              </table>
         </FooterTemplate>

     </asp:repeater>

    </div>
</div>

</asp:Content>

