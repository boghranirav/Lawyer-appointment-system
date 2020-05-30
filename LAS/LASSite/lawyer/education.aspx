<%@ Page Title="" Language="C#" MasterPageFile="~/lawyer/AdminMasterPageHeader.master" AutoEventWireup="true" CodeFile="education.aspx.cs" Inherits="lawyer_education" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="Form1" runat="server">
        <div class="content-wrapper">
            <div class="container-fluid">
                <!-- Breadcrumbs-->
                <ol class="breadcrumb">
                    <li class="breadcrumb-item">Education
                    </li>
                </ol>
                <div class="row">
                    <div class="col-md-6">
                        <div class="box_general padding_bottom">
                            <div class="header_box version_2">
                                <h2>Education</h2>
                            </div>
                            <div class="form-group">
                                <label>From Year:</label>
                                <asp:TextBox ID="txtfromyr" runat="server" CssClass="form-control" TextMode="Date" />
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" ControlToValidate="txtfromyr" runat="server" ErrorMessage="Please Enter proper date*" ForeColor="Red" InitialValue="select"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label>TO Year:</label>
                                <asp:TextBox ID="txttoyr" runat="server" CssClass="form-control" TextMode="Date" />
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" ControlToValidate="txttoyr" runat="server" ErrorMessage="Please Enter proper date*" ForeColor="Red" InitialValue="select"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label>Title:</label>
                                <asp:TextBox ID="txttitle" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" ControlToValidate="txttitle" runat="server" ErrorMessage="Please Enter Title*" ForeColor="Red" InitialValue="select"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

