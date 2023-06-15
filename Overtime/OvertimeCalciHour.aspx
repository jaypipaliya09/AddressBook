<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OvertimeCalciHour.aspx.cs" Inherits="Overtime_OvertimeCalciHour" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Content/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../Content/js/bootstrap.min.js"></script>
    <script>window.MathJax = { MathML: { extensions: ["mml3.js", "content-mathml.js"] } };</script>
    <script type="text/javascript" async src="https://cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.0/MathJax.js?config=MML_HTMLorMML"></script>
    <style>
        table {
            border-collapse: separate;
            border: 3px solid black;
            border-spacing: 10px;
            box-shadow: 5px 10px rgb(219, 219, 219);
            border-radius: 4px 4px;
        }

        tr :nth-child(2n+1) {
            background-color: #f2f2f2;
        }
        #divContent {
            box-shadow: 5px 10px rgb(219, 219, 219);
            border-radius: 4px 4px;
        }

        p {
            font-family: Bahnschrift;
            font-weight: bold;
            font-size: medium;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row" align="center">
                <h1 align="center">HRM</h1>
                <hr />
                <h4>Overtime Calculator</h4>
                <br />
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server">Calculation Type:</asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlCalculationType" runat="server" AutoPostBack="True" DataTextField="Select Calculation Type" DataValueField="-1" OnSelectedIndexChanged="ddlCalculationType_SelectedIndexChanged">
                        <asp:ListItem Value="hour"> Hour </asp:ListItem>
                        <asp:ListItem Value="day"> Day </asp:ListItem>
                        <asp:ListItem Value="week"> Week </asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <br />
                <div class="col-md-4">
                    <asp:Label runat="server">Currency:</asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlCurrency" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="-1"> Select Currency </asp:ListItem>
                        <asp:ListItem Value="&#8377;"> Rupees (&#8377;)</asp:ListItem>
                        <asp:ListItem Value="$"> Dollar ($) </asp:ListItem>
                        <asp:ListItem Value="&pound;"> Pound (&pound;)</asp:ListItem>
                    </asp:DropDownList>

                </div>
                <div class="col-md-4">
                    <asp:RequiredFieldValidator ID="rfvCurrency" runat="server" ErrorMessage="Select a Currency" ControlToValidate="ddlCurrency" Display="Dynamic" ForeColor="Red" InitialValue="-1" ValidationGroup="Calculate" EnableViewState="False"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <br />
                <div class="col-md-4">
                    <asp:Label runat="server" ID="lblRegularWorktime"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtRegularWorktime" runat="server" ToolTip="Enter a fix time in hours" Placeholder="Enter Fix Time"></asp:TextBox>

                </div>
                <div class="col-md-4">
                    <asp:Label runat="server" ID="lblRegularWorktimeType"></asp:Label><br />
                    <asp:RequiredFieldValidator ID="rfvWorktime" runat="server" ErrorMessage="Enter a WorkTime " ControlToValidate="txtRegularWorktime" Display="Dynamic" ForeColor="Red" ValidationGroup="Calculate"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="reWorktime" runat="server" ControlToValidate="txtRegularWorktime" Display="Dynamic" ErrorMessage="Enter a only Positive Number" ForeColor="Red" ValidationExpression="([0-9])[0-9]*[.]?[0-9]*" ValidationGroup="Calculate"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <br />
                <div class="col-md-4">
                    <asp:Label runat="server" ID="lblTotalWorktime"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtTotalWorktime" runat="server" ToolTip="Enter a time in hours" Placeholder="Enter Time"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Label runat="server" ID="lblTotalWorktimeType"></asp:Label><br />
                    <asp:RequiredFieldValidator ID="rfvTotalWorktime" runat="server" ErrorMessage="Enter a Total Worktime of Employee" ControlToValidate="txtTotalWorktime" Display="Dynamic" ForeColor="Red" ValidationGroup="Calculate"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="reTotalWorktime" runat="server" ControlToValidate="txtTotalWorkTime" Display="Dynamic" ErrorMessage="Enter a only Positive Number" ForeColor="Red" ValidationExpression="([0-9])[0-9]*[.]?[0-9]*" ValidationGroup="Calculate"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <br />
                <div class="col-md-4">
                    <asp:Label runat="server" ID="lblRegularPayPer"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtRegularPay" runat="server" ToolTip="Enter a Payment" Placeholder="Enter Fix Pay"></asp:TextBox>

                </div>
                <div class="col-md-4">
                    <asp:RequiredFieldValidator ID="rfvRegularPay" runat="server" ErrorMessage="Enter a Pay per hour" ControlToValidate="txtRegularPay" Display="Dynamic" ForeColor="Red" ValidationGroup="Calculate"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="reRegularPay" runat="server" ControlToValidate="txtRegularPay" Display="Dynamic" ErrorMessage="Enter a only Positive Number" ForeColor="Red" ValidationExpression="([0-9])[0-9]*[.]?[0-9]*" ValidationGroup="Calculate"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <br />
                <div class="col-md-4">
                    <asp:Label runat="server">Overtime Pay Multiplier:</asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtMultiplier" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:RequiredFieldValidator ID="rfvOvertimePay" runat="server" ErrorMessage="Enter a Multiplier for Overtime" ControlToValidate="txtMultiplier" Display="Dynamic" ForeColor="Red" ValidationGroup="Calculate"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="reOvertimePay" runat="server" ControlToValidate="txtMultiplier" Display="Dynamic" ErrorMessage="Enter a only Positive Number" ForeColor="Red" ValidationExpression="([0-9])[0-9]*[.]?[0-9]*" ValidationGroup="Calculate"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <br />
                <div class="col-md-1">
                </div>
                <div class="col-md-3">
                    <br />
                    <asp:Label runat="server" ID="lblMessage" Visible="False" BorderColor="#FF0066" CssClass="alert-danger" ForeColor="Red"></asp:Label>
                </div>
                <div class="col-md-4" align="right">
                    <asp:Button runat="server" ID="btnCalculate" Text="Calculate" CssClass="btn btn-success" OnClick="btnCalculate_Click" ValidationGroup="Calculate" />
                </div>
            </div>
            <div class="row" runat="server" id="divAnswer">
                <br />
                <div class="col-md-4">
                    <asp:Label runat="server" ID="lblTotalPay" CssClass="active" Font-Bold="True" Font-Names="Bahnschrift SemiLight" Font-Size="Medium" ForeColor="Green"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label runat="server" ID="lblRegularPay" CssClass="active" Font-Bold="True" Font-Names="Bahnschrift SemiLight" Font-Size="Medium" ForeColor="Green"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label runat="server" ID="lblOvertimePay" CssClass="active" Font-Bold="True" Font-Names="Bahnschrift SemiLight" Font-Size="Medium" ForeColor="Green"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label runat="server" ID="lblRegularHours" CssClass="active" Font-Bold="True" Font-Names="Bahnschrift SemiLight" Font-Size="Medium" ForeColor="Green"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label runat="server" ID="lblOvertimeHours" CssClass="active" Font-Names="Bahnschrift SemiLight" Font-Size="Medium" ForeColor="Green" Font-Bold="True"></asp:Label>
                </div>
            </div>
            <div runat="server" class="row" id="divMathCalculation" visible="false">
                <hr />
                <br />
                <div class="col-md-12" id="divContent">
                    <h1>Calculation</h1>
                </div>
                <div class="col-md-12">
                    <br />
                    <math xmlns="http://www.w3.org/1998/Math/MathML">
                      <mrow>
                        <mo>Overtime = &#xA0;</mo>
                        <mrow>
                            <mrow>
                              <mo>Total Worktime</mo>
                              <mi>&#xA0;-&#xA0;</mi>
                              <mo>Regular Worktime</mo>
                            </mrow>
                        </mrow>
                      </mrow>
                    </math>
                    <br />
                    <br />
                    <math xmlns="http://www.w3.org/1998/Math/MathML">
                    <mrow>
                        <mo>Overtime = &#xA0;</mo>
                        <mrow>
                            <mrow>
                              <mi runat="server" id="miCalTotalWorktime">&#xA0;</mi>
                              <mi>&#xA0;-&#xA0;</mi>
                              <mi runat="server" id="miCalRegularWorktime"></mi>
                            </mrow>
                          </mrow>
                          <mrow>
                              <mo>&equals;</mo>
                              <mi runat="server" id="miCalOvertime"></mi>
                          </mrow>
                      </mrow>
                    </math>
                     <br />
                    <br />
                    <math xmlns="http://www.w3.org/1998/Math/MathML">
                      <mrow>
                        <mo>Regular Pay</mo>
                        <mo>&#xA0;=&#xA0;</mo>
                        <mrow>
                            <mrow>
                              <mo>Regular Pay Per</mo>
                               <mo runat="server" id="milblMode3"></mo>
                              <mi>&#xA0;x&#xA0;</mi>
                              <mo>Regular Worktime</mo>
                            </mrow>
                        </mrow>
                      </mrow>
                    </math>
                     <br />
                    <br />
                    <math xmlns="http://www.w3.org/1998/Math/MathML">
                    <mrow>
                        <mo>Regular Pay</mo>
                        <mo>&#xA0;=&#xA0;</mo>
                        <mrow>
                            <mrow>
                              <mi runat="server" id="milblRegularPayModeWise">&#xA0;</mi>
                              <mi>&#xA0;x&#xA0;</mi>
                              <mi runat="server" id="milblRegularWorktime"></mi>
                            </mrow>
                          </mrow>
                          <mrow>
                              <mo>&equals;</mo>
                              <mi runat="server" id="miCalRegularPay1"></mi>
                              <mfrac>
                                  <mi runat="server" id="milblCurrency2"></mi>
                                  <mi runat="server" id="milblMode4"></mi>
                              </mfrac>
                          </mrow>
                      </mrow>
                    </math>
                    <br />
                    <br />
                    <math xmlns="http://www.w3.org/1998/Math/MathML">
                      <mrow>
                        <mo>Overtime Pay</mo>
                        <mo>&#xA0;=&#xA0;</mo>
                        <mrow>
                            <mrow>
                              <mo>Overtime Multiplier</mo>
                              <mi>&#xA0;x&#xA0;</mi>
                              <mo>Regular Pay Per </mo>
                              <mo runat="server" id="milblMode"></mo>
                            </mrow>
                        </mrow>
                      </mrow>
                    </math>
                    <br />
                    <br />
                    <math xmlns="http://www.w3.org/1998/Math/MathML">
                    <mrow>
                        <mo>Overtime Pay</mo>
                        <mo>&#xA0;=&#xA0;</mo>
                        <mrow>
                            <mrow>
                              <mi runat="server" id="miCalOvertimeMultiplier">&#xA0;</mi>
                              <mi>&#xA0;x&#xA0;</mi>
                              <mi runat="server" id="miCalRegularPay"></mi>
                            </mrow>
                          </mrow>
                          <mrow>
                              <mo>&equals;</mo>
                              <mi runat="server" id="miCalOvertimePay"></mi>
                              <mfrac>
                                  <mi runat="server" id="milblCurrency"></mi>
                                  <mi runat="server" id="milblMode1"></mi>
                              </mfrac>
                          </mrow>
                      </mrow>
                    </math>
                    <br />
                    <br />
                    <math xmlns="http://www.w3.org/1998/Math/MathML">
                      <mrow>
                        <mo>Total Salary</mo>
                        <mo>&#xA0;=&#xA0;</mo>
                        <mrow>
                            <mrow>
                              <mo>Regular Pay</mo>
                              <mi>&#xA0;+&#xA0;</mi>
                              <mo>Overtime Pay</mo>
                            </mrow>
                        </mrow>
                      </mrow>
                    </math>
                     <br />
                    <br />
                    <math xmlns="http://www.w3.org/1998/Math/MathML">
                    <mrow>
                        <mo>Total Salary</mo>
                        <mo>&#xA0;=&#xA0;</mo>
                        <mrow>
                            <mrow>
                              <mi runat="server" id="milblRegularPay">&#xA0;</mi>
                              <mi>&#xA0;+&#xA0;</mi>
                              <mi runat="server" id="milblOvertimePay"></mi>
                            </mrow>
                          </mrow>
                          <mrow>
                              <mo>&equals;</mo>
                              <mi runat="server" id="miCalTotal"></mi>
                              <mfrac>
                                  <mi runat="server" id="milblCurrency1"></mi>
                                  <mi runat="server" id="milblMode2"></mi>
                              </mfrac>
                          </mrow>
                      </mrow>
                    </math>
                </div>
            </div>
            <div class="row">
                <br />
                <hr />
                <div class="col-md-12" id="divContent">
                    <h1>What is Overtime ?</h1>
                </div>
                <div class="col-md-12">
                    <br />
                    <p align="justify">This overtime calculator is a tool that finds out how much you will earn if you have to stay longer at work. All you have to do is provide some information about your hourly wages, and it will calculate the total pay you will receive this month.</p>
                </div>
            </div>
            <div class="row">
                <hr />
                <br />
                <table>
                    <tr>
                        <th>Field Name</th>
                        <th>Description</th>
                    </tr>
                    <tr>
                        <td>Regular WorkTime</td>
                        <td>Regular Work Time is a duration of work for each employee. This contains a same duration for all employee.</td>
                    </tr>
                    <tr>
                        <td>Total WorkTime</td>
                        <td>Total Work Time is a total duration of work for each employee.</td>
                    </tr>
                    <tr>
                        <td>Regular Pay</td>
                        <td>Regular Pay is a regular salary with respect to duration.</td>
                    </tr>
                    <tr>
                        <td>Overtime Multiplier</td>
                        <td>Overtime Multiplier is to give a person who does extra work in multiples of regular pay.</td>
                    </tr>
                </table>
                <br />
                <hr />
                <div class="col-md-12" style="border: 3px solid black; box-shadow: 5px 10px rgba(219, 219, 219)">
                    <h1>Example  Based on Hour and Rupees</h1>
                    <hr />
                    <h5>Suresh's regular worktime is 10 hours but he works total 15hours and his regular salary per hour is 5 Rupees/hour, His worktime is more than the regular worktime so his salary is double than regular salary per hour so find Overtime salary per hour. and Total salary per hour</h5>
                    <hr />
                    <p>
                            Regular WorkTime = 10 hours<br />
                            Total WorkTime = 15 hours<br />
                            Regular Pay per hour = 5 Rupees/hour<br />
                            Overtime Multiplier = 2x
                    </p>
                    <p>
                        Overtime = Total WorkTime - Regular WorkTime
                        <br />
                        Overtime = 15 - 10<br />
                        Overtime = 5 hours
                    </p>
                    <br />
                    <p>
                        Overtime Pay Per hour = Overtime Multiplier *  Regular Pay Per hour<br />
                        Overtime Pay Per hour = 2*5<br />
                        Overtime Pay Per hour = 10 Rupees/hour<br />
                    </p>
                    <br />
                    <p>
                        <u>Overtime Pay = Overtime Multiplier * Regular Pay per hour * Overtime<br />
                            Overtime Pay = 2*5*5<br />
                            Total Overtime Pay = 50 Rupees</u>
                    </p>
                    <br />
                    <p>
                        <u>Regular Pay = Regular WorkTime * Regular Pay (per hour)<br />
                            Regular Pay = 10 * 5<br />
                            Regular Pay = 50 Rupees</u>
                    </p>
                    <p>
                            Total Salary Per day = Regular Pay + Overtime Pay<br />
                            Total Salary Per day = 50 + 50<br />
                            Total Salary Per day = 100 Rupees/day
                    </p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
