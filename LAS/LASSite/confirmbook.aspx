<%@ Page Title="" Language="C#" MasterPageFile="~/MstHeaderFooter.master" AutoEventWireup="true" CodeFile="confirmbook.aspx.cs" Inherits="confirmbook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <main>
        <div class="bg_color_2">
			<div class="container margin_60_35">
				<div id="login-2">
					<h1>Confirm your booking</h1>
						<div class="box_form clearfix" >
							<div class="box_login">
								<div class="form-group">
									<label>Email Id</label>
                                    <asp:Label runat="server" ID="txtEmail" CssClass="form-control" />
								</div>
                                <div class="form-group">
									<label>Name</label>
                                    <asp:Label runat="server" ID="txtName" CssClass="form-control" />
								</div>
                                <div class="form-group">
									<label>Reason Of Visit</label>
                                    <asp:TextBox runat="server" ID="txtReason" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="txtReason" ErrorMessage="Please write reason of visit" ForeColor="Red" ></asp:RequiredFieldValidator>
								</div>
							</div>
							<div class="box_login last">
								<div class="form-group">
									<label>Layer Name</label>
                                    <asp:Label runat="server" ID="lblLName" class="form-control" />
								</div>
                                <div class="form-group">
									<label>Office</label>
                                    <label runat="server" ID="lblOffice" class="form-control" ></label>
								</div>
                                <div class="form-group">
									<label>Booking Date</label>
                                    <asp:Label runat="server" ID="lblLDate" class="form-control" />
								</div>
                                <div class="form-group">
									<label>Booking Time</label>
                                    <asp:Label runat="server" ID="lblLTime" class="form-control" />
								</div>
								<div class="form-group">
									<asp:Button runat="server" ID="btnSubmit" CssClass="btn_1" Text="Book" OnClick="btnSubmit_Click" />
								</div>
							</div>
						</div>
				</div>
				<!-- /login -->
			</div>
		</div>
    </main>
</asp:Content>

