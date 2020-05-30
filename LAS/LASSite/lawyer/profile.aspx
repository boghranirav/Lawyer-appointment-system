<%@ Page Title="" Language="C#" MasterPageFile="~/lawyer/AdminMasterPageHeader.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="lawyer_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <script type="text/javascript">
        function previewFile() {
            var preview = document.querySelector('#<%=displayImg.ClientID %>');
        var file = document.querySelector('#<%=imgCategoryImage.ClientID %>').files[0];
        var reader = new FileReader();

        reader.onloadend = function () {
            preview.src = reader.result;
        }

        if (file) {
            reader.readAsDataURL(file);
        } else {
            preview.src = "";
        }
    }
    </script>
    <form id="Form1" runat="server" enctype="multipart/form-data" method="post"  action="profile.aspx">
        <div class="content-wrapper">
            <div class="container-fluid">
                <!-- Breadcrumbs-->
                <ol class="breadcrumb">
                    <li class="breadcrumb-item">My Profile
                    </li>
                </ol>
                <div class="row">
                    <div class="col-md-12">
                        <div class="box_general padding_bottom">
                            <div class="header_box version_2">
                                <h2>My Profile</h2>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <input type="file" runat="server" id="imgCategoryImage" onchange="previewFile()" name="imgCategoryImage" class="form-control" tabindex="1" />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Image ID="displayImg" runat="server" Height="150px" Width="150px" AlternateText="Category Image" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                    <div class="form-group col-md-6">
                                        <label>First Name</label>
                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"/>
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" ControlToValidate="txtFirstName" runat="server" ErrorMessage="Please enter first name*" ForeColor="Red" ></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Last Name:</label>
                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" ControlToValidate="txtLastName" runat="server" ErrorMessage="Please enter last name*" ForeColor="Red" ></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                            <div class="row">
                                    <div class="form-group col-md-6">
                                        <label>Email Id</label>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Enabled="false"/>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Mobile</label>
                                        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" ControlToValidate="txtMobile" runat="server" ErrorMessage="Please enter mobile number*" ForeColor="Red" ></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group col-md-6">
                                        <label>Address :</label>
                                        <asp:TextBox ID="txtaddress1" runat="server" CssClass="form-control" />
                                        <asp:TextBox ID="txtaddress2" runat="server" CssClass="form-control" />
                                        <asp:TextBox ID="txtaddress3" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Description :</label>
                                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" />
                                    </div>
                                </div>
                           
                                <div class="row">
                                    <div class="form-group col-md-6">
                                        <label>Specialization:</label>
                                        <asp:DropDownList ID="cmbSpec" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-3">
                                        <label>Date Of Birth:</label>
                                        <asp:TextBox ID="txtbirthdate" runat="server" CssClass="form-control" TextMode="Date" />
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator7" ControlToValidate="txtbirthdate" runat="server" ErrorMessage="Please Enter Birth Date*" ForeColor="Red" ></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group col-md-3">
                                        <label>License No:</label>
                                        <asp:TextBox ID="txtLicenseNo" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="form-group col-md-3">
                                        <label>Issued On:</label>
                                        <asp:TextBox ID="txtIssuedOn" runat="server" CssClass="form-control" TextMode="Date" />
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" ControlToValidate="txtIssuedOn" runat="server" ErrorMessage="Please Enter License Date*" ForeColor="Red" ></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
                                </div>
                            </div>



                    </div>
                </div>
            </div>
        </div>

    </form>
</asp:Content>

