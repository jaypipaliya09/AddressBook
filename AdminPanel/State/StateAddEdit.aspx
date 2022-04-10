<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="AdminPanel_State_StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="row" align="justify">
        <h2 align="center">State ADD - EDIT</h2>
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
                <asp:Label runat="server" Text="Select Country" ID="lblSelectCountry"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:DropDownList runat="server" ID="ddlCountryID"></asp:DropDownList><br />
            </div>
            <div class="col-md-2">

                <asp:RequiredFieldValidator ID="rfvddlCountryID" runat="server" ControlToValidate="ddlCountryID" Display="Dynamic" ErrorMessage="Select Country" ForeColor="Red" InitialValue="-1" ToolTip="Country - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>

            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="State Name" ID="lblStateName"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtStateName" runat="server"></asp:TextBox>
                <br />
            </div>
            <div class="col-md-2">
                <asp:RequiredFieldValidator ID="rfvStateName" runat="server" ControlToValidate="txtStateName" Display="Dynamic" ErrorMessage="Enter State Name" ForeColor="Red" ToolTip="State Name - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>

            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="State Code" ID="lblStateCode"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtStateCode" runat="server"></asp:TextBox><br />
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

