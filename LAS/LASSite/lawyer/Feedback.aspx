<%@ Page Title="" Language="C#" MasterPageFile="~/lawyer/AdminMasterPageHeader.master" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="lawyer_Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="content-wrapper">
    <div class="container-fluid">
      <!-- Breadcrumbs-->
      <ol class="breadcrumb">
        <li class="breadcrumb-item">
          Feedback
        </li>
      </ol>
    
		
        <div class="card mb-3" >
                    <div class="card-body" style="margin-top:-50px;">
                        <div class="table-responsive">
                            <table class="table table-bordered" style="width: 100%;" id="dataTable">
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                        <th>EmailId</th>
                                        <th>Mobile</th>
                                        <th>App Date/Time</th>
                                        <th>Review</th>
                                    </tr>
                                </thead>
                                <tbody id="displayReview" runat="server">
                                        
                                        
                                </tbody>
                            </table>
                        </div>
                    </div>

	  </div>
   	</div>
</asp:Content>

