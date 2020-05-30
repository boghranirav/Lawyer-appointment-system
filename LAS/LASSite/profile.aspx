<%@ Page Title="" Language="C#" MasterPageFile="~/MstHeaderFooter.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <main>
		<div id="hero_register">
			<div class="container margin_120_95">			
				<div class="row">
					<div class="col-lg-12 ml-auto">
                        <h2 style="color:white;">User Profile <a href="view_appointment.aspx">View Appointments</a></h2>
						<div class="box_form">
							<div id="message-register"></div>
								<div class="row">
									<div class="col-md-6 ">
										<div class="form-group">
                                            <label>First Name</label>
											<asp:TextBox id="txtFirstName" runat="server" CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Enter First Name" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>
									<div class="col-md-6">
										<div class="form-group">
                                            <label>Last Name</label>
											<asp:TextBox id="txtLastName" runat="server" CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName" ErrorMessage="Enter Last Name" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>

                                    <div class="col-md-6">
										<div class="form-group">
                                            <label>Email</label>
											<asp:Label ID="lblEmai" runat="server" CssClass="form-control" />
										</div>
									</div>
                                    <div class="col-md-6">
										<div class="form-group">
                                            <label>Mobile</label>
											<asp:TextBox id="txtMobile" runat="server" CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMobile" ErrorMessage="Enter Mobile" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>

                                    <div class="col-md-6">
										<div class="form-group">
                                            <label>Address</label>
											<asp:TextBox id="txtAddress1" runat="server" CssClass="form-control" />
                                            <asp:TextBox id="txtAddress2" runat="server" CssClass="form-control" />
                                            <asp:TextBox id="txtAddress3" runat="server" CssClass="form-control" />
										</div>
									</div>

                                    <div class="col-md-6">
										<div class="form-group">
                                            <label>Gender</label>
											<asp:DropDownList ID="cmbGender" runat="server" CssClass="form-control" >
                                                <asp:ListItem Value="s">Select</asp:ListItem>
                                                <asp:ListItem Value="m">Male</asp:ListItem>
                                                <asp:ListItem Value="f">Female</asp:ListItem>
											</asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cmbGender" ErrorMessage="Select gender" InitialValue="s" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Date of birth</label>
											<asp:TextBox id="txtDOB" runat="server" CssClass="form-control" TextMode="Date" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDOB" ErrorMessage="Enter Date of birth" ForeColor="Red"></asp:RequiredFieldValidator>
										</div>
									</div>

                                   

								</div>
								<div><asp:Button id="btnSubmit" runat="server" CssClass="btn_1" Text="Update" OnClick="btnSubmit_Click" /></div>
						
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

