<%@ Page Title="" Language="C#" MasterPageFile="~/MstSearch.master" AutoEventWireup="true" CodeFile="view_lawyer.aspx.cs" Inherits="view_lawyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contbody" runat="Server">
    
    <main>
        <div class="container margin_60">
            <div class="row">
                <aside class="col-xl-3 col-lg-4" id="sidebar">
                    <div class="box_profile">
                        <figure>
                            <asp:Image runat="server" ID="imgLawyer" alt="" class="img-fluid" Width="255px" Height="255px" />
                        </figure>
                        <small runat="server" id="lblSpec"></small>
                        <h1><label runat="server" id="lblLawyerName"></label></h1>
                        <ul class="contacts">
                            <li>
                                <h6 runat="server" id="lblOfficename"></h6>
                            </li>
                            <li>
                                <h6>Phone</h6>
                                <label runat="server" id="lblPhone"></label>
                            </li>
                            <li>
                                <h6>Email-Id</h6>
                                <label runat="server" id="lblEmail"></label>
                            </li>
                        </ul>
                    </div>
                </aside>
                <!-- /asdide -->

                <div class="col-xl-9 col-lg-8">

                    <div class="tabs_styled_2">
                        <ul class="nav nav-tabs" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link active" id="book-tab" data-toggle="tab" href="#book" role="tab" aria-controls="book">Book an appointment</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" id="general-tab" data-toggle="tab" href="#general" role="tab" aria-controls="general" aria-expanded="true">General info</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" id="reviews-tab" data-toggle="tab" href="#reviews" role="tab" aria-controls="reviews">Reviews</a>
                            </li>
                        </ul>
                        <!--/nav-tabs -->

                        <div class="tab-content">

                            <div class="tab-pane fade show active" id="book" role="tabpanel" aria-labelledby="book-tab">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="cmbDate" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                    <ContentTemplate>

                                        <div class="indent_title_in">
                                            <i class="pe-7s-cash"></i>
                                            <h3>Office Timing</h3>
                                        </div>
                                        <div class="wrapper_indent">
                                            <table class="table table-responsive table-striped">
                                                <thead>
                                                    <tr>
                                                        <th>Day</th>
                                                        <th>Morning</th>
                                                        <th>Evening</th>
                                                    </tr>
                                                </thead>
                                                <tbody runat="server" id="displayTiming">
                                                </tbody>
                                            </table>
                                        </div>

                                        <div runat="server" id="displayOtherOfffice" visible="false">
                                            <div class="indent_title_in">
                                                <i class="pe-7s-cash"></i>
                                                <h3>Other Office</h3>
                                            </div>
                                            <div class="wrapper_indent" runat="server" id="displayOfficeDetails">
                                                klmlkmkl
                                            </div>
                                        </div>
                                        <div class="main_title_3">
                                            <h3><strong>1</strong>Select your date</h3>
                                        </div>
                                        <div class="form-group add_bottom_45">
                                            <asp:DropDownList runat="server" ID="cmbDate" class="form-control" OnSelectedIndexChanged="cmbDate_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="select">Select Date</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="main_title_3">
                                            <h3><strong>2</strong>Select your time</h3>
                                        </div>

                                        <div class="row justify-content-center add_bottom_45" runat="server" id="displayTimeHoliday">
                                            
                                        </div>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <!-- /tab_1 -->

                            <div class="tab-pane fade" id="general" role="tabpanel" aria-labelledby="general-tab">
                                <div class="indent_title_in">
                                    <i class="pe-7s-user"></i>
                                    <h3>Professional statement</h3>
                                </div>
                                <div class="wrapper_indent">
                                    <p><label runat="server" id="lblSDescription"></label></p>
                                </div>
                                <!-- /wrapper indent -->

                                <hr>

                                <div class="indent_title_in">
                                    <i class="pe-7s-news-paper"></i>
                                    <h3>Education </h3>
                                </div>
                                <div class="wrapper_indent">
                                    <ul class="list_edu" runat="server" id="lblEducation">
                                        <li><strong>New York Medical College</strong> - Doctor of Medicine</li>
                                    </ul>

                                </div>
                                <!--  End wrapper indent -->

                                <hr>

                                <div class="indent_title_in">
                                    <i class="pe-7s-cash"></i>
                                    <h3>Prices &amp; and Services</h3>
                                </div>
                                <div class="wrapper_indent">
                                    <table class="table table-responsive table-striped">
                                        <thead>
                                            <tr>
                                                <th>Service - Visit</th>
                                                <th>Price</th>
                                            </tr>
                                        </thead>
                                        <tbody runat="server" id="lblServices">
                                        </tbody>
                                    </table>
                                </div>
                                <!--  End wrapper_indent -->

                            </div>
                            <!-- /tab_2 -->

                            <div class="tab-pane fade" id="reviews" role="tabpanel" aria-labelledby="reviews-tab">
                                <div class="reviews-container">
                                    <div class="review-box clearfix" runat="server" id="displayReview">
                                        
                                    </div>

                                </div>
                                <!-- End review-container -->
                            </div>
                            <!-- /tab_3 -->
                        </div>
                        <!-- /tab-content -->
                    </div>
                    <!-- /tabs_styled -->
                </div>
                <!-- /col -->
            </div>
            <!-- /row -->
        </div>
        <!-- /container -->
    </main>
</asp:Content>

