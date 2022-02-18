<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddCategory.aspx.cs" Inherits="AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br<<br /><br /><br />
<div class ="container ">
            <div class ="form-horizontal ">
                <h2>Add Category</h2>
                <hr />
                <div class ="form-group">
                    <asp:Label ID="Label1" CssClass ="col-md-2 control-label " runat="server" Text="Category Name"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:TextBox ID="tb_Category" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategoryName" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter Category" ControlToValidate="tb_Category" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class ="form-group">
                    <div class ="col-md-2 "> </div>
                    <div class ="col-md-6 ">

                        <asp:Button ID="btn_Add_Category" CssClass ="btn btn-success " runat="server" 
                            Text="Add Category" onclick="btn_Add_Category_Click"/>
                        
                    </div>
                </div>

            </div>

        <h1>Category</h1>
        <hr />

 <div class="panel panel-default">

     <div class="panel-heading"> All Category</div>

      <asp:repeater ID="rptrCategory" runat="server">

         <HeaderTemplate>
             <table class="table">
                  <thead>
                    <tr>
                        <th>ID</th>
                        <th>Category</th>
                        <th>Edit</th>

                    </tr>
                 </thead>
            <tbody>
         </HeaderTemplate>

         <ItemTemplate>
             <tr>
                 <th> <%# Eval("Category_ID")%> </th>
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

