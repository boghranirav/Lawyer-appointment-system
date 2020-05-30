<%@ Page Title="" Language="C#" MasterPageFile="~/lawyer/AdminMasterPageHeader.master" AutoEventWireup="true" CodeFile="services.aspx.cs" Inherits="lawyer_services" %>

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
                url: "services.aspx/Deleteservice", // this for calling the web method function in cs code.  
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
                    url: 'services.aspx',
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
                    <li class="breadcrumb-item">Services
                    </li>
                </ol>
                <div class="row">
                    <div class="col-md-6">
                        <div class="box_general padding_bottom">
                            <div class="header_box version_2">
                                <h2>Services and Charge</h2>
                            </div>

                            <div class="form-group">
                                <label> Services</label>
                                <asp:TextBox runat="server" ID="txtService" CssClass="form-control" OnTextChanged="txtService_TextChanged" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="Please enter service" ControlToValidate="txtService"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblDErrorMsg" runat="server" ForeColor="Red"  ></asp:Label>
                            </div>
                            <div class="form-group">
                                <label>Charge</label>
                                <asp:TextBox runat="server" ID="txtCharge" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="Please enter charge" ControlToValidate="txtCharge"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"/>
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>

                        </div>
                    </div>
                </div>


                <div class="card mb-3">
                    <div class="card-header">
                        Services
                    </div>
                    <div class="card-body" style="margin-top:-50px;">
                        <div class="table-responsive">
                            <table class="table table-bordered" style="width: 100%;" id="dataTable">
                                <thead>
                                    <tr>
                                        <th>Service</th>
                                        <th>Charge</th>
                                        <th>Edit</th>
                                        <th>Delete</th>
                                    </tr>
                                </thead>
                                <tbody runat="server" id="displayService">
                                    
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

