<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="row" align="justify">
        <h2 align="center">Contact ADD - EDIT</h2>
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

                <asp:RequiredFieldValidator ID="rfvddlCountryID" runat="server" ControlToValidate="ddlCountryID" Display="Dynamic" ErrorMessage="Select County" ForeColor="Red" InitialValue="-1" ToolTip="Country - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>

            </div>
        </div>
        <div class="row">
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
                <asp:Label runat="server" Text="Select City" ID="lblSelectCity"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:DropDownList runat="server" ID="ddlCityID"></asp:DropDownList><br />
            </div>
            <div class="col-md-2">

                <asp:RequiredFieldValidator ID="rfvddlCityID" runat="server" ControlToValidate="ddlCityID" Display="Dynamic" ErrorMessage="Select City" ForeColor="Red" InitialValue="-1" ToolTip="City - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>

            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="Contact Category" ID="lblContactCategory"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:CheckBoxList runat="server" ID="cblContactCategoryID"></asp:CheckBoxList>
                <br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="Contact Name" ID="lblContactName"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtContactName" runat="server"></asp:TextBox><br />
            </div>
            <div class="col-md-2">

                <asp:RequiredFieldValidator ID="rfvContactName" runat="server" ControlToValidate="txtContactName" Display="Dynamic" ErrorMessage="Enter Your Name" ForeColor="Red" ToolTip="Contact - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>

            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="Contact No" ID="lblContactNo"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox><br />
            </div>
            <div class="col-md-2">

                <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ControlToValidate="txtContactNo" Display="Dynamic" ErrorMessage="Enter Your Number" ForeColor="Red" ToolTip="Contact Number - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>

            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="WhatsApp No" ID="lblWhtsAppNo"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtWhatsAppNo" runat="server"></asp:TextBox><br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="BirthDate" ID="lblBirthDate"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtBirthDate" runat="server" TextMode="DateTime"></asp:TextBox>
                
                <br />
            </div>
            <div class="col-md-2">
                <asp:CompareValidator ID="cvBirthDate" runat="server" ControlToValidate="txtBirthDate" ErrorMessage="Enter a Valid Date" ForeColor="Red" Operator="DataTypeCheck" Type="Date" ValidationGroup="Save" ToolTip="BirthDate - Error"></asp:CompareValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="Email" ID="lblEmail"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
            </div>
            <div class="col-md-2">

                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Enter Your Mail I'D" ForeColor="Red" ToolTip="Contact Email - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>

                <asp:RegularExpressionValidator ID="rgvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Enter a Valid email id" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Save"></asp:RegularExpressionValidator>

            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="Age" ID="lblAge"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox runat="server" ID="txtAge"></asp:TextBox>
                <br />
            </div>
            <div class="col-md-2">
                <asp:RangeValidator ID="rvAge" runat="server" ControlToValidate="txtAge" Display="Dynamic" ErrorMessage="Enter a Valid Number" ForeColor="Red" MaximumValue="110" MinimumValue="1" ToolTip="Age - Error" Type="Integer" ValidationGroup="Save"></asp:RangeValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="Address" ID="lblAddress"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox><br />
            </div>
            <div class="col-md-2">

                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="Enter Your Address" ForeColor="Red" ToolTip="Contact Address - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>

            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="BloodGroup" ID="lblBloodGroup"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtBloodGroup" runat="server"></asp:TextBox><br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="Facebook ID" ID="lblFacebookID"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtFacebookID" runat="server"></asp:TextBox><br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="LinkedIN ID" ID="lblLinkedINID"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtLinkedINID" runat="server"></asp:TextBox><br />
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

