<%@ Page Title="" Language="C#" MasterPageFile="~/MstHeaderFooter.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    	<main>
            <div class="bg_color_2">
			<div class="container margin_60_35">
				<div id="register">
					<h1>Please Login!</h1>
					<div class="row justify-content-center">
						<div class="col-md-5">
								<div class="box_form">
									<div class="form-group">
                                    <label>Email Id</label>
							        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Your email address" TextMode="Email" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Please Enter Email." ></asp:RequiredFieldValidator>
								</div>
								<div class="form-group">
                                    <label>Password</label>
                                    <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Your password" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ForeColor="Red" ErrorMessage="Please Enter Password." ></asp:RequiredFieldValidator>
								   
                                </div>
                                <div class="form-group">
								    <asp:Label ID="lblLogin" runat="server" ForeColor="Red" CssClass="form-control" Visible="false" ></asp:Label>
                                </div>
								<div class="form-group">
									<asp:Button runat ="server"  CssClass="btn_1" ID="btnSubmit" Text="Login" OnClick="btnSubmit_Click" />
								</div>
								</div>
								<p class="text-center link_bright">Do not have an account yet? <a href="register.aspx"><strong>Register now!</strong></a></p>
						</div>
					</div>
					<!-- /row -->
				</div>
				<!-- /register -->
			</div>
		</div>
	</main>
</asp:Content>

