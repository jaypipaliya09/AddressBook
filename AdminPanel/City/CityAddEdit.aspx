<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="row" align="justify">
        <h2 align="center">City ADD - EDIT</h2>
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
                <asp:Label runat="server" Text="Select State" ID="lblSelectState"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:DropDownList runat="server" ID="ddlStateID"></asp:DropDownList><br />
            </div>
            <div class="col-md-2">

                <asp:RequiredFieldValidator ID="rfvddlStateID" runat="server" ControlToValidate="ddlStateID" Display="Dynamic" ErrorMessage="Select State" ForeColor="Red" InitialValue="-1" ToolTip="State - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>

            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="City Name" ID="lblCityName"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtCityName" runat="server"></asp:TextBox>
                <br />
            </div>
            <div class="col-md-2">
                <asp:RequiredFieldValidator ID="rfvCityName" runat="server" ControlToValidate="txtCityName" Display="Dynamic" ErrorMessage="Enter City Name" ForeColor="Red" ToolTip="City Name - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>

            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="STD Code" ID="lblSTDCode"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtSTDCode" runat="server"></asp:TextBox><br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="Pin Code" ID="lblPinCode"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtPinCode" runat="server"></asp:TextBox><br />
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

