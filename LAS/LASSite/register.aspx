<%@ Page Title="" Language="C#" MasterPageFile="~/MstHeaderFooter.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <main>
        <div class="bg_color_2">
            <div class="container margin_60_35">
                <div id="register">
                    <h1>Please register!</h1>
                    <div class="row justify-content-center">
                        <div class="col-md-5">
                                <div class="box_form">
                                    <div class="form-group">
                                        <label>Select Your Type</label>
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="cmbUserType">
                                            <asp:ListItem Value="select"> Select</asp:ListItem>
                                            <asp:ListItem Value="lawyer"> Lawyer</asp:ListItem>
                                            <asp:ListItem Value="user">User</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ControlToValidate="cmbUserType" runat="server" ErrorMessage="Select User Type" ForeColor="Red" ID="RequiredFieldValidator7" InitialValue="select" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label>First Name</label>
                                        <asp:TextBox ID="txtFName" runat="server" CssClass="form-control" placeholder="Your first name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtFName" runat="server" ErrorMessage="Enter first name" ForeColor="Red" ID="RequiredFieldValidator1" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label>Last name</label>
                                        <asp:TextBox ID="txtLName" runat="server" CssClass="form-control" placeholder="Your last name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtLName" runat="server" ErrorMessage="Enter last name" ForeColor="Red" ID="RequiredFieldValidator2" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label>Email</label>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Your email" OnTextChanged="txtEmail_TextChanged" AutoPostBack="true" TextMode="Email"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtEmail" runat="server" ErrorMessage="Enter email" ForeColor="Red" ID="RequiredFieldValidator3" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:Label Text="" ID="lblEmail_V" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div class="form-group">
                                        <label>Mobile</label>
                                        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Your Mobile" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtMobile" runat="server" ErrorMessage="Enter Mobile" ForeColor="Red" ID="RequiredFieldValidator4" Display="Dynamic"></asp:RequiredFieldValidator>

                                    </div>
                                    <div class="form-group">
                                        <label>Password</label>
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Your Password" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtPassword" runat="server" ErrorMessage="Enter Password" ForeColor="Red" ID="RequiredFieldValidator5" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label>Confirm password</label>
                                        <asp:TextBox ID="txtRePass" runat="server" CssClass="form-control" placeholder="Re-Enter Password" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtRePass" runat="server" ErrorMessage="Re-Enter Password" ForeColor="Red" ID="RequiredFieldValidator6" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="txtRePass" ControlToCompare="txtPassword" ErrorMessage="Both Password does not match" ID="CompareValidator" runat="server" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                                    </div>
                                    <div class="form-group text-center add_top_30">
                                        <asp:Button CssClass="btn_1" ID="btnSubmit" Text="Sign Up" runat="server" OnClick="btnSubmit_Click" />
                                    </div>
                                </div>
                        </div>
                    </div>
                    <!-- /row -->
                </div>
                <!-- /register -->
            </div>
        </div>
    </main>
</asp:Content>

