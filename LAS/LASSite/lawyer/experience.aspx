<%@ Page Title="" Language="C#" MasterPageFile="~/lawyer/AdminMasterPageHeader.master" AutoEventWireup="true" CodeFile="experience.aspx.cs" Inherits="lawyer_experience" %>

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
                url: "experience.aspx/Deleteexperience", // this for calling the web method function in cs code.  
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
                    url: 'experience.aspx',
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
                    <li class="breadcrumb-item">Education and Experience
                    </li>
                </ol>
                <div class="row">
                    <div class="col-md-6">
                        <div class="box_general padding_bottom">
                            <div class="header_box version_2">
                                <h2>Education and Experience</h2>
                            </div>
                            <div class="form-group">
                                <label>From:</label>
                                <asp:TextBox ID="txtfrom" runat="server" CssClass="form-control" TextMode="Date" />
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" ControlToValidate="txtfrom" runat="server" ErrorMessage="Please Enter proper date*" ForeColor="Red" InitialValue="select"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label>To:</label>
                                <asp:TextBox ID="txttodate" runat="server" CssClass="form-control" TextMode="Date" />
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" ControlToValidate="txttodate" runat="server" ErrorMessage="Please Enter proper date*" ForeColor="Red" InitialValue="select"></asp:RequiredFieldValidator>
                                <asp:CompareValidator runat="server" Display="Dynamic" ID="CompareValidator" ControlToValidate="txttodate" ControlToCompare="txtFrom"  Operator="GreaterThan" Type="Date" ErrorMessage="To date must be greter then from date" ForeColor="Red" ></asp:CompareValidator>
                            </div>
                            <div class="form-group">
                                <label>Description:</label>
                                <asp:TextBox runat="server" ID="txtdescription" CssClass="form-control" TextMode="MultiLine" />
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" ControlToValidate="txtdescription" runat="server" ErrorMessage="Please Describe in detail*" ForeColor="Red" InitialValue="select"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
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
                                        <th>From</th>
                                        <th>To</th>
                                        <th>Description</th>
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

