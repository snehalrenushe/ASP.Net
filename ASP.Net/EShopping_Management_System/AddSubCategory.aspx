<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddSubCategory.aspx.cs" Inherits="AddSubCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br<<br /><br /><br />
<div class ="container ">
            <div class ="form-horizontal ">
                <h2>Add SubCategory</h2>
                <hr />
                <div class ="form-group">
                    <asp:Label ID="Label2" CssClass ="col-md-2 control-label " runat="server" Text="Main Category ID"></asp:Label>
                    <div class ="col-md-3 ">
                        <asp:DropDownList ID="ddl_Main_Category_ID" CssClass="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorMainCategoryID" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter Brandname" ControlToValidate="ddl_Main_Category_ID" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>


                <div class ="form-group">
                    <asp:Label ID="Label1" CssClass ="col-md-2 control-label " runat="server" Text="SubCategory"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:TextBox ID="tb_SubCategory" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSubCategoryName" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter Brandname" ControlToValidate="tb_SubCategory" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class ="form-group">
                    <div class ="col-md-2 "> </div>
                    <div class ="col-md-6 ">

                        <asp:Button ID="btn_Add_SubCategory" CssClass ="btn btn-success " runat="server" 
                            Text="Add Subcategory" onclick="btn_Add_SubCategory_Click"/>
                        
                    </div>
                </div>

            </div>

        <h1>Subcategory</h1>
        <hr />

 <div class="panel panel-default">

     <div class="panel-heading"> All Subcategory</div>

      <asp:repeater ID="rptrSubCat" runat="server">

         <HeaderTemplate>
             <table class="table">
                  <thead>
                    <tr>
                        <th>ID</th>
                        <th>Subcategory</th>
                        <th>Main Category</th>
                        <th>Edit</th>

                    </tr>
                 </thead>
            <tbody>
         </HeaderTemplate>

         <ItemTemplate>
             <tr>
                 <th> <%# Eval("Subcategory_ID") %> </th>
                 <td><%# Eval("Subcategory_Name") %>   </td>
                 <td><%# Eval("Category_Name") %>   </td>
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

