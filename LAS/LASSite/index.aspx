<%@ Page Title="" Language="C#" MasterPageFile="~/MstSearch.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<%-- Add content controls here --%>
<asp:Content id="contenttitle" runat="server" ContentPlaceHolderID="title">
    Index
</asp:Content>

<asp:Content id="contenthead" runat="server" ContentPlaceHolderID="head">

</asp:Content>


<asp:Content id="content1" runat="server" ContentPlaceHolderID="contbody">
            <div class="container margin_120_95">
            <div class="main_title">
                <h2>Find by specialization</h2>
            </div>

            <div class="row" runat="server" id="displaySpec">
                
             </div>
            <!-- /row -->
        </div>
</asp:Content>

