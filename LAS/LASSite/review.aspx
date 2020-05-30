<%@ Page Title="" Language="C#" MasterPageFile="~/MstHeaderFooter.master" AutoEventWireup="true" CodeFile="review.aspx.cs" Inherits="review" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        	<main>
            <div class="bg_color_2">
			<div class="container margin_60_35">
				<div id="register">
					<h1>Write Review</h1>
					<div class="row justify-content-center">
						<div class="col-md-5">
								<div class="box_form">
									<div class="form-group">
                                    <label>Review</label>
							        <asp:TextBox ID="txtReview" runat="server" CssClass="form-control" placeholder="Your review" TextMode="MultiLine" Rows="5" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtReview" ForeColor="Red" ErrorMessage="Please enter your review." ></asp:RequiredFieldValidator>
								</div>
								<div class="form-group">
									<asp:Button runat ="server"  CssClass="btn_1" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" />
                                    <asp:Button runat ="server"  CssClass="btn_1" ID="btnDelete" Text="Delete" OnClick="btnDelete_Click" />
								</div>
								</div>
						</div>
					</div>
					<!-- /row -->
				</div>
				<!-- /register -->
			</div>
		</div>
	</main>
</asp:Content>

