<%@ Page Title="" Language="C#" MasterPageFile="~/lawyer/AdminMasterPageHeader.master" AutoEventWireup="true" CodeFile="office_info.aspx.cs" Inherits="lawyer_office_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <script type="text/javascript">
    function deletefunction(id1, uid) { //This function call on text change.     
        if (confirm("Are you sure you want to delete?")) {
            $.ajax({
                type: "POST",
                url: "office_info.aspx/Deleteoffice", // this for calling the web method function in cs code.  
                data: '{eid: "' + id1 + '"}', // user name or email value  
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response);
                }
            });
        }
    }
    // function OnSuccess  
    function OnSuccess(response) {
        switch (response.d) {
            case "1":

                break;
            case "true":
                $.ajax({
                    type: 'POST',
                    url: 'office_info.aspx',
                    success: function () {
                        setTimeout(function () {
                            location.reload();
                        }, 500);
                    }
                });
                break;
            case "false":

                break;
        }
    }
</script>
    <form id="Form1" runat="server">
        <div class="content-wrapper">
            <div class="container-fluid">
                <!-- Breadcrumbs-->
                <ol class="breadcrumb">
                    <li class="breadcrumb-item">Office Information
                    </li>
                </ol>
                <div class="row">
                    <div class="col-md-6">
                        <div class="box_general padding_bottom">
                            <div class="header_box version_2">
                                <h2>Office Information</h2>
                            </div>
                            <div class="form-group">
                                <label>Name</label>
                                <asp:TextBox ID="txtname" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" ControlToValidate="txtname" runat="server" ErrorMessage="Please Enter Name*" ForeColor="Red" ></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label>Address</label>
                                <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" ControlToValidate="txtaddress" runat="server" ErrorMessage="Please Enter Address*" ForeColor="Red" ></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label>Area</label>
                                <asp:DropDownList ID="cmbarea" runat="server" CssClass="form-control" >
                                    <asp:ListItem Value="select" >Select Area</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" ControlToValidate="cmbarea" runat="server" ErrorMessage="Please select area*" ForeColor="Red" InitialValue="select"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label>Postal Code:</label>
                                <asp:TextBox ID="txtpostalcode" runat="server" CssClass="form-control" TextMode="Number" />
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" ControlToValidate="txtpostalcode" runat="server" ErrorMessage="Please Enter Postal code*" ForeColor="Red" ></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label>Mobile No:</label>
                                <asp:TextBox ID="txtmobile" runat="server" CssClass="form-control" TextMode="Number" />
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" ControlToValidate="txtmobile" runat="server" ErrorMessage="Please Enter Mobile No*" ForeColor="Red" ></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label>Email:</label>
                                <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" TextMode="Email" />
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" ControlToValidate="txtemail" runat="server" ErrorMessage="Please Enter Email Address*" ForeColor="Red" ></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
                                <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                            </div>

                        </div>
                    </div>
                </div>

                <div class="card mb-3">
                    <div class="card-body" style="margin-top:-50px;">
                        <div class="table-responsive">
                            <table class="table table-bordered" style="width: 100%;" id="dataTable">
                                <thead>
                                    <tr>
                                        <th>Office Name</th>
                                        <th>Address</th>
                                        <th>Email Id</th>
                                        <th>Edit</th>
                                        <th>Delete</th>
                                    </tr>
                                </thead>
                                <tbody runat="server" id="displayOffice">
                                    
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

