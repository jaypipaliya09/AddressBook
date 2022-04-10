<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryAddEdit.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="row" align="justify">
        <h2 align="center">Contact Category ADD - EDIT</h2>
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
                <asp:Label runat="server" Text="Contact Category Name" ID="lblContactCategoryName"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtContactCategoryName" runat="server"></asp:TextBox>
                <br />
            </div>
            <div class="col-md-2">
                <asp:RequiredFieldValidator ID="rfvContactCategoryName" runat="server" ControlToValidate="txtContactCategoryName" Display="Dynamic" ErrorMessage="Enter Contact Category Name" ForeColor="Red" ToolTip="Contact Category Name - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>

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

