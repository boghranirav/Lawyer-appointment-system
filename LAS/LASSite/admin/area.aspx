﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMst1.master" AutoEventWireup="true" CodeFile="area.aspx.cs" Inherits="admin_area" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <script type="text/javascript">
    function deletefunction(id1, uid) { //This function call on text change.     
        if (confirm("Are you sure you want to delete?")) {
            $.ajax({
                type: "POST",
                url: "area.aspx/Deletearea", // this for calling the web method function in cs code.  
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
                    url: 'area.aspx',
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
                    <li class="breadcrumb-item">Area
                    </li>
                </ol>

                <div class="row">
                    <div class="col-md-6">
                        <div class="box_general padding_bottom">
                            <div class="header_box version_2">
                                <h2>Area</h2>
                            </div>

                            <div class="form-group">
                                <label>Select Country</label>
                                <asp:DropDownList runat="server" ID="cmbCountry" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cmbCountry_SelectedIndexChanged">
                                    <asp:ListItem Value="select"> Select Country</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="Please select country" ControlToValidate="cmbCountry" InitialValue="select"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label>Select City</label>
                                <asp:DropDownList runat="server" ID="cmbCity" CssClass="form-control">
                                    <asp:ListItem Value="select"> Select City</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="Please select City" ControlToValidate="cmbCity" InitialValue="select"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label>Area Name</label>
                                <asp:TextBox runat="server" ID="txtArea" CssClass="form-control" OnTextChanged="txtArea_TextChanged" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="Please enter area" ControlToValidate="txtArea"></asp:RequiredFieldValidator>
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
                    <div class="card-body" style="margin-top:-50px;">
                        <div class="table-responsive">
                            <table class="table table-bordered" style="width: 100%;"  id="dataTable">
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                        <th>Area</th>
                                        <th>Edit</th>
                                        <th>Delete</th>
                                    </tr>
                                </thead>
                                <tbody runat="server" id="displayArea">
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

            </div>
        </div>

    </form>
</asp:Content>

