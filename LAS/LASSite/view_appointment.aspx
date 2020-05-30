<%@ Page Title="" Language="C#" MasterPageFile="~/MstHeaderFooter.master" AutoEventWireup="true" CodeFile="view_appointment.aspx.cs" Inherits="view_appointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
	<link rel="stylesheet" type="text/css" href="css/util.css">
	<link rel="stylesheet" type="text/css" href="css/main.css">       

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <script type="text/javascript">
    function deletefunction(id1, uid) { //This function call on text change.     
        if (confirm("Are you sure you want to cancel this appointment?")) {
            $.ajax({
                type: "POST",
                url: "view_appointment.aspx/Deleteappointment", // this for calling the web method function in cs code.  
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
                    url: 'view_appointment.aspx',
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
            <main>
		<div id="hero_register">
			<div class="container margin_120_95">			
				<div class="row">
					<div class="col-lg-12 ml-auto">
                        <h2 style="color:white;"><a href="profile.aspx">User Profile </a> View Appointments</h2>
						<div class="box_form">
							<div id="message-register">
                                <div class="container-table100">
			<div class="wrap-table100" >
				<div class="table100">
					<table style="width:100%;" >
						<thead>
							<tr class="table100-head">
								<th style="width:20%;text-align:left;">Lawyer Name</th>
                                <th style="width:25%;text-align:left;">Office Name</th>
								<th style="width:15%;text-align:left;">Date</th>
								<th style="width:10%;text-align:left;">Time</th>
                                <th style="width:10%;text-align:left;">Status</th>
								<th style="width:10%;text-align:left;">Cancel</th>
								<th style="width:10%;text-align:left;">Feedback</th>
							</tr>
						</thead>
						<tbody runat="server" id="displayData">
								<tr>
									<td >Mrs. Hema Jani</td>
									<td >13-July-2018</td>
									<td >12.30 PM</td>
									<td > </td>
									<td >Good </td>
								</tr>
						</tbody>
					</table>
				</div>
			</div>
		</div>
							</div>
						</div>
						<!-- /box_form -->
					</div>
					<!-- /col -->
				</div>
				<!-- /row -->
			</div>
			<!-- /container -->
		</div>
		<!-- /hero_register -->
	</main>


</asp:Content>

