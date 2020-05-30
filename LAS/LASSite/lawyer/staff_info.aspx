<%@ Page Title="" Language="C#" MasterPageFile="~/lawyer/AdminMasterPageHeader.master" AutoEventWireup="true" CodeFile="staff_info.aspx.cs" Inherits="lawyer_staff_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form1" runat="server">
    <div class="content-wrapper">
    <div class="container-fluid">
      <!-- Breadcrumbs-->
      <ol class="breadcrumb">
        <li class="breadcrumb-item">
          Staff Information
        </li>
      </ol>
        <div class="row">
            <div class="col-md-12">
                <div class="box_general padding_bottom">
                    <div class="header_box version_2">
                        <h2>Staff Information</h2>
                    </div>

                    <div class="col-md-12">
                        <div class="row" style="margin-left:4px;">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>First name</label>
                                    <asp:TextBox ID="txtfirstname" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator9" ControlToValidate="txtfirstname" runat="server" ErrorMessage="Please Enter  firstName*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Last name</label>
                                    <asp:TextBox ID="txtlname" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" ControlToValidate="txtlname" runat="server" ErrorMessage="Please Enter LastName*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Address:</label>
                                <asp:TextBox ID="txtAdd" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" ControlToValidate="txtAdd" runat="server" ErrorMessage="Please Enter Address*" ForeColor="Red"></asp:RequiredFieldValidator>

                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>City:</label>
                                <asp:TextBox ID="txtcity" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" ControlToValidate="txtcity" runat="server" ErrorMessage="Please Enter City*" ForeColor="Red"></asp:RequiredFieldValidator>

                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Mobile No.:</label>
                                <asp:TextBox ID="txtmob" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator7" ControlToValidate="txtmob" runat="server" ErrorMessage="Please Enter Mobile Number*" ForeColor="Red"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Email:</label>
                                <asp:TextBox ID="txtemail" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator8" ControlToValidate="txtemail" runat="server" ErrorMessage="Please Enter Email Id*" ForeColor="Red"></asp:RequiredFieldValidator>

                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Button ID="btnsubmit" runat="server" Text="Submit" />
                            <asp:Button ID="btncancel" runat="server" Text="cancel" />
                        </div>
                    </div>
                </div>
            </div>

        </div>
   	</div>
        </form>
</asp:Content>

