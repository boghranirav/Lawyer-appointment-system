<%@ Page Title="" Language="C#" MasterPageFile="~/lawyer/AdminMasterPageHeader.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="admin_index" %>

<asp:Content ID="Content3" ContentPlaceHolderID="title" runat="server">

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
           <script type="text/javascript">
    function deletefunction(id1, uid) { //This function call on text change.     
        if (confirm("Are you sure you want to delete?")) {
            $.ajax({
                type: "POST",
                url: "Upcoming_appointments.aspx/Deleteappointment", // this for calling the web method function in cs code.  
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
                    url: 'Upcoming_appointments.aspx',
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
                    <li class="breadcrumb-item">Today Appointments
                    </li>
                </ol>

                <div class="row">
                    <div class="col-md-6">
                        <div class="box_general padding_bottom">
                            <div class="header_box version_2">
                                <h2>Select Office</h2>
                            </div>
                            <div class="form-group">
                                <label>Office</label>
                                <asp:DropDownList runat="server" ID="cmbOffice" CssClass="form-control" OnTextChanged="cmbOffice_TextChanged"  AutoPostBack="true" >
                                    <asp:ListItem Value="select">Select Office</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="card mb-3" >
                    <div class="card-body" style="margin-top:-50px;">
                        <div class="table-responsive">
                            <table class="table table-bordered" style="width: 100%;" id="dataTable">
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                        <th>EmailId</th>
                                        <th>Mobile</th>
                                        <th>Date Time</th>
                                        <th>Status</th>
                                        <th>Cancel</th>
                                    </tr>
                                </thead>
                                <tbody id="displayLawyer" runat="server">
                                        
                                        
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

            </div>
        </div>
              
    </form>
</asp:Content>

