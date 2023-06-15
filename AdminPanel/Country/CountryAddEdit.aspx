<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPanel_City_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="row" align="justify">

        <h2 align="center">Country ADD - EDIT</h2>
        <hr />
        <div class="row">
            <div class="col-md-7">
                <asp:Label runat="server" ID="lblHeading"></asp:Label>
            </div>
        </div>
        <asp:Label runat="server" ID="lblMessage" Text="" EnableViewState="false"></asp:Label>
        <br />
        <div class="row">
            <br />
            <br />
            <div class="col-md-4">
                <asp:Label runat="server" Text="Country Name" ID="lblCountryName"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtCountryName" runat="server"></asp:TextBox>
                <br />
            </div>
            <div class="col-md-2">
                <asp:RequiredFieldValidator ID="rfvCountryName" runat="server" ControlToValidate="txtCountryName" Display="Dynamic" ErrorMessage="Enter Country Name" ForeColor="Red" ToolTip="Country Name - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>

            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="Country Code" ID="lblCountryCode"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtCountryCode" runat="server"></asp:TextBox><br />
            </div>
        </div>

        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-8">
                <asp:Button runat="server" ID="btnSave" ToolTip="Submit" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-success" ValidationGroup="Save" />&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnCancel" ToolTip="Cancel" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
</asp:Content>

