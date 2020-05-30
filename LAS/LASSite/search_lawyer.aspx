<%@ Page Title="" Language="C#" MasterPageFile="~/MstSearch.master" AutoEventWireup="true" CodeFile="search_lawyer.aspx.cs" Inherits="search_lawyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contbody" Runat="Server">
    <div class="container margin_60_35">
        <div class="row">
            <div class="col-lg-8">
                <div class="row" runat="server" id="displayLawyers">

                    

                </div>
                
                <!-- /pagination -->
            </div>
            <!-- /col -->

            <aside class="col-lg-4" id="sidebar">
                <div id="map_listing" class="normal_list" style="border: 1px solid double; border-color: black; padding: 10px;">
                    <!-- State -->
                    <h3 style="text-align: left; color: blue; font-size: 150%;">Location</h3>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cmbCity" EventName="SelectedIndexChanged" />
                        </Triggers>
                        <ContentTemplate>
                            
                    <!-- City -->
                    <h4 style="text-align: left; color: blue; font-size: 100%;">Select City</h4>
                    <!-- Dropdown List -->
                    <div class="col-md-12">
                        <asp:DropDownList ID="cmbCity" runat="server" class="form-control" OnSelectedIndexChanged="cmbCity_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="select">Select City</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <!-- Area -->
                    <h4 style="text-align: left; color: blue; font-size: 100%;">Select Area</h4>
                    <!-- Dropdown List -->
                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:DropDownList class="form-control" runat="server" ID="cmbArea">
                                <asp:ListItem Value="select">Select Area</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>

                            </ContentTemplate>
                    </asp:UpdatePanel>
                    <h3 style="text-align: left; color: blue; font-size: 150%;">Type of Lawyer</h3>
                    <!-- Dropdown List -->
                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:DropDownList ID="cmbSpecialization" runat="server" class="form-control">
                                <asp:ListItem Value="select">Select Specialization</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div>
                        <asp:Button ID="btnSearch" CssClass="btn_1" Text="Search" runat="server" OnClick="btnSearch_Click" />
                    </div>

                </div>
            </aside>
            <!-- /aside -->

        </div>
        <!-- /row -->
    </div>
</asp:Content>

