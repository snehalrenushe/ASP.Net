<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddGender.aspx.cs" Inherits="AddGender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br<<br /><br /><br />
<div class ="container ">
            <div class ="form-horizontal ">
                <h2>Add Gender</h2>
                <hr />
                <div class ="form-group">
                    <asp:Label ID="Label1" CssClass ="col-md-2 control-label " runat="server" Text="Gender"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:TextBox ID="tb_Gender" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter Gender" ControlToValidate="tb_Gender" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class ="form-group">
                    <div class ="col-md-2 "> </div>
                    <div class ="col-md-6 ">
                    
                        <asp:Button ID="btn_Add_Gender" CssClass ="btn btn-success " runat="server" 
                            Text="Add" onclick="btn_Add_Gender_Click"/>
                        
                    </div>
                </div>

            </div>

        <h1>Gender</h1>
        <hr />

 <div class="panel panel-default">

     <div class="panel-heading"> All Gender</div>

      <asp:repeater ID="rptrGender" runat="server">

         <HeaderTemplate>
             <table class="table">
                  <thead>
                    <tr>
                        <th>ID</th>
                        <th>Gender</th>
                        <th>Edit</th>

                    </tr>

                   </thead>
            <tbody>
         </HeaderTemplate>


         <ItemTemplate>
             <tr>
                    <th> <%# Eval("Gender_ID") %> </th>
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

