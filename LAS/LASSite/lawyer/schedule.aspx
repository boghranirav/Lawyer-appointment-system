<%@ Page Title="" Language="C#" MasterPageFile="~/lawyer/AdminMasterPageHeader.master" AutoEventWireup="true" CodeFile="schedule.aspx.cs" Inherits="lawyer_schedule" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
<%@   Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="aspajex"%>


<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
   <title></title>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cmbOffice" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="cb_day1" EventName="CheckedChanged" />
                <asp:AsyncPostBackTrigger ControlID="cb_day2" EventName="CheckedChanged" />
                <asp:AsyncPostBackTrigger ControlID="cb_day3" EventName="CheckedChanged" />
                <asp:AsyncPostBackTrigger ControlID="cb_day4" EventName="CheckedChanged" />
                <asp:AsyncPostBackTrigger ControlID="cb_day5" EventName="CheckedChanged" />
                <asp:AsyncPostBackTrigger ControlID="cb_day6" EventName="CheckedChanged" />
                <asp:AsyncPostBackTrigger ControlID="cb_day7" EventName="CheckedChanged" />
            </Triggers>
            <ContentTemplate>

                <div class="content-wrapper">
                    <div class="container-fluid">
                        <!-- Breadcrumbs-->
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item">Schedule
                            </li>
                        </ol>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="box_general padding_bottom">
                                    <div class="header_box version_2">
                                        <h2>Office Timing</h2>
                                    </div>

                                    <div class="form-group">
                                        <label>Name</label>
                                        <asp:DropDownList ID="cmbOffice" runat="server" CssClass="form-control" OnSelectedIndexChanged="cmbOffice_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Value="select">Select Office</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" ControlToValidate="cmbOffice" runat="server" ErrorMessage="Select office*" ForeColor="Red" InitialValue="select"></asp:RequiredFieldValidator>
                                    </div>


                                    <div class="form-group">
                                        <table class="table table-bordered">

                                            <thead>
                                                <tr>
                                                    <th>Day</th>
                                                    <th>First Half</th>
                                                    <th>Second Half</th>
                                                    <th>Holiday</th>
                                                </tr>
                                            </thead>
                                            <tbody>

                                                <tr>
                                                    <td>Monday</td>
                                                    <td>

                                                        <div class="row" style="margin-left: 2px;">
                                                            <label style="margin-top: 0.3cm; text-align: center;">From </label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickermo1"></asp:TextBox>
                                                            <label style="width: 1cm; margin-top: 0.3cm; text-align: center;">to</label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickermo2"></asp:TextBox>

                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="row" style="margin-left: 2px;">
                                                            <label style="margin-top: 0.3cm; text-align: center;">From </label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickermo3"></asp:TextBox>
                                                            <label style="width: 1cm; margin-top: 0.3cm; text-align: center;">to</label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickermo4"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="cb_day1" runat="server" AutoPostBack="True"
                                                            OnCheckedChanged="cb_day1_CheckedChanged1" /></td>
                                                </tr>



                                                <tr>
                                                    <td>Tuesday</td>
                                                    <td>
                                                        <div class="row" style="margin-left: 2px;">
                                                            <label style="margin-top: 0.3cm; text-align: center;">From </label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickertu1"></asp:TextBox>
                                                            <label style="width: 1cm; margin-top: 0.3cm; text-align: center;">to</label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickertu2"></asp:TextBox>
                                                        </div>

                                                    </td>
                                                    <td>
                                                        <div class="row" style="margin-left: 2px;">
                                                            <label style="margin-top: 0.3cm; text-align: center;">From </label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickertu3"></asp:TextBox>
                                                            <label style="width: 1cm; margin-top: 0.3cm; text-align: center;">to</label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickertu4"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="cb_day2" runat="server" AutoPostBack="True"
                                                            OnCheckedChanged="cb_day2_CheckedChanged" /></td>
                                                </tr>

                                                <tr>
                                                    <td>Wednesday</td>
                                                    <td>
                                                        <div class="row" style="margin-left: 2px;">
                                                            <label style="margin-top: 0.3cm; text-align: center;">From </label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickerwe1"></asp:TextBox>
                                                            <label style="width: 1cm; margin-top: 0.3cm; text-align: center;">to</label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickerwe2"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="row" style="margin-left: 2px;">
                                                            <label style="margin-top: 0.3cm; text-align: center;">From </label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickerwe3"></asp:TextBox>
                                                            <label style="width: 1cm; margin-top: 0.3cm; text-align: center;">to</label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickerwe4"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="cb_day3" runat="server" AutoPostBack="True"
                                                            OnCheckedChanged="cb_day3_CheckedChanged" /></td>
                                                </tr>
                                                <tr>
                                                    <td>Thursday</td>
                                                    <td>
                                                        <div class="row" style="margin-left: 2px;">
                                                            <label style="margin-top: 0.3cm; text-align: center;">From </label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickerthu1"></asp:TextBox>
                                                            <label style="width: 1cm; margin-top: 0.3cm; text-align: center;">to</label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickerthu2"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="row" style="margin-left: 2px;">
                                                            <label style="margin-top: 0.3cm; text-align: center;">From </label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickerthu3"></asp:TextBox>
                                                            <label style="width: 1cm; margin-top: 0.3cm; text-align: center;">to</label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickerthu4"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="cb_day4" runat="server" AutoPostBack="True"
                                                            OnCheckedChanged="cb_day4_CheckedChanged" /></td>
                                                </tr>
                                                <tr>
                                                    <td>Friday</td>
                                                    <td>
                                                        <div class="row" style="margin-left: 2px;">
                                                            <label style="margin-top: 0.3cm; text-align: center;">From </label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickerfri1"></asp:TextBox>
                                                            <label style="width: 1cm; margin-top: 0.3cm; text-align: center;">to</label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickerfri2"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="row" style="margin-left: 2px;">
                                                            <label style="margin-top: 0.3cm; text-align: center;">From </label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickerfri3"></asp:TextBox>
                                                            <label style="width: 1cm; margin-top: 0.3cm; text-align: center;">to</label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickerfri4"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="cb_day5" runat="server" AutoPostBack="True"
                                                            OnCheckedChanged="cb_day5_CheckedChanged" /></td>
                                                </tr>
                                                <tr>
                                                    <td>Saturday</td>
                                                    <td>
                                                        <div class="row" style="margin-left: 2px;">
                                                            <label style="margin-top: 0.3cm; text-align: center;">From </label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickersat1"></asp:TextBox>
                                                            <label style="width: 1cm; margin-top: 0.3cm; text-align: center;">to</label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickersat2"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="row" style="margin-left: 2px;">
                                                            <label style="margin-top: 0.3cm; text-align: center;">From </label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickersat3"></asp:TextBox>
                                                            <label style="width: 1cm; margin-top: 0.3cm; text-align: center;">to</label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickersat4"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="cb_day6" runat="server" AutoPostBack="True"
                                                            OnCheckedChanged="cb_day6_CheckedChanged" /></td>
                                                </tr>
                                                <tr>
                                                    <td>Sunday</td>
                                                    <td>
                                                        <div class="row" style="margin-left: 2px;">
                                                            <label style="margin-top: 0.3cm; text-align: center;">From </label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickersun1"></asp:TextBox>
                                                            <label style="width: 1cm; margin-top: 0.3cm; text-align: center;">to</label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickersun2"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="row" style="margin-left: 2px;">
                                                            <label style="margin-top: 0.3cm; text-align: center;">From </label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickersun3"></asp:TextBox>
                                                            <label style="width: 1cm; margin-top: 0.3cm; text-align: center;">to</label>
                                                            <asp:TextBox runat="server" TextMode="Time" CssClass="form-control" Width="3cm" ID="timepickersun4"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="cb_day7" runat="server" AutoPostBack="True"
                                                            OnCheckedChanged="cb_day7_CheckedChanged" /></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>


                                    <div class="form-group">
                                        <label>Average Time Per Client (In Minutes) </label>
                                        <asp:TextBox ID="tb_minutes" runat="server" CssClass="form-control" placeholder="Minutes" TextMode="Number" MaxLength="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_minutes" ErrorMessage="*Enter Average Time." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="*Enter Valid Average Time." ValidationExpression="[0-9]{2}" ForeColor="Red" ControlToValidate="tb_minutes"></asp:RegularExpressionValidator>
                                    </div>

                                    <div class="form-group">
                                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
                                        <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                                    </div>

                                </div>
                            </div>
                        </div>



                    </div>
                </div>
            </ContentTemplate>

        </asp:UpdatePanel>

    </form>


</asp:Content>

