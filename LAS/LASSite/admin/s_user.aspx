<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMst1.master" AutoEventWireup="true" CodeFile="s_user.aspx.cs" Inherits="admin_s_user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
    function deletefunction(id1, uid) { //This function call on text change.     
        if (confirm("Are you sure you want to delete?")) {
            $.ajax({
                type: "POST",
                url: "s_user.aspx/UserActiveDeActive", // this for calling the web method function in cs code.  
                data: '{eid: "' + id1 + '",uid:"' + uid + '"}', // user name or email value  
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
                    url: 's_user.aspx',
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
                    <li class="breadcrumb-item">User Information
                    </li>
                </ol>

                <div class="card mb-3">
                    <div class="card-body" style="margin-top:-50px;">
                        <div class="table-responsive">
                            <table class="table table-bordered" style="width: 100%;" id="dataTable">
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                        <th>EmailId</th>
                                        <th>Mobile</th>
                                        <th>Status</th>
                                        <th>Validate</th>
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

