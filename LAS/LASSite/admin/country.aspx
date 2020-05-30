<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMst1.master" AutoEventWireup="true" CodeFile="country.aspx.cs" Inherits="admin_country" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <script type="text/javascript">
    function deletefunction(id1, uid) { //This function call on text change.     
        if (confirm("Are you sure you want to delete?")) {
            $.ajax({
                type: "POST",
                url: "country.aspx/Deletecountry", // this for calling the web method function in cs code.  
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
                    url: 'country.aspx',
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

<form runat="server">
             
        <div class="content-wrapper">
            <div class="container-fluid">
                <!-- Breadcrumbs-->
                <ol class="breadcrumb">
                    <li class="breadcrumb-item">Country
                    </li>
                </ol>

                <div class="row">
                    <div class="col-md-6">
                        <div class="box_general padding_bottom">
                            <div class="header_box version_2">
                                <h2>Country</h2>
                            </div>

                            <div class="form-group">
                                <label>Country</label>
                                <asp:TextBox runat="server" ID="txtCountry" CssClass="form-control" OnTextChanged="txtCountry_TextChanged" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="Please enter country name" ControlToValidate="txtCountry"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblDErrorMsg" runat="server" ForeColor="Red"  ></asp:Label>
                            </div>
                            
                            <div class="form-group">
                                <label></label>
                                <asp:Button runat="server" CssClass="btn_1 medium" Text="Save" ID="btnSubmit" OnClick="btnSubmit_Click" />
                            </div>

                        </div>
                    </div>
                </div>

                <div class="card mb-3">
                    <div class="card-header">
                        Data Table Example
                    </div>
                    <div class="card-body" style="margin-top:-50px;">
                        <div class="table-responsive" >
                            <table class="table table-bordered" style="width:100%;" id="dataTable" >
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                        <th>Edit</th>
                                        <th>Delete</th>
                                    </tr>
                                </thead>
                                <tbody runat="server" id="displayCountry">
                                    
                                </tbody>
                            </table>
                        </div>
                    </div>
                  </div>

            </div>
        </div>
            
    </form>
</asp:Content>

