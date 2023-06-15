<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TurnoverRate.aspx.cs" Inherits="TurnoverRate_TurnoverRate" %>

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
                <h4>Turnover Rate Calculator of Employee</h4>
                <br />
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server">Calculate average number of employees ?</asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlFindAverage" runat="server" AutoPostBack="True" DataTextField="Select Yes or No" DataValueField="-1" OnSelectedIndexChanged="ddlFindAverage_SelectedIndexChanged">
                        <asp:ListItem Value="yes">Yes</asp:ListItem>
                        <asp:ListItem Value="no">No</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row" runat="server" id="divAverageNumber">
                <br />
                <div class="col-md-4">
                    <asp:Label runat="server" ID="lblAverageNumber" Text="Average Number of Employees"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtAverageNumber" runat="server" ToolTip="Enter a Average Number of Employees"></asp:TextBox>

                </div>
                <div class="col-md-4">
                    <asp:RequiredFieldValidator ID="rfvAverageNumber" runat="server" ErrorMessage="Enter a Average Number of Employee " ControlToValidate="txtAverageNumber" Display="Dynamic" ForeColor="Red" ValidationGroup="Calculate"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="reAverageNumber" runat="server" ControlToValidate="txtAverageNumber" Display="Dynamic" ErrorMessage="Enter a only Positive Number" ForeColor="Red" ValidationExpression="([0-9])[0-9]*[.]?[0-9]*" ValidationGroup="Calculate"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row" runat="server" id="divEmployeeBegin" visible="false">
                <br />

                <div class="col-md-4">
                    <asp:Label runat="server" ID="lblEmployeeBegin" Text="Employees at the begining"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtEmployeeBegin" runat="server" ToolTip="Enter total number of employee at the begining"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:RequiredFieldValidator ID="rfvEmployeeBegin" runat="server" ErrorMessage="Enter a Total number of employees at the begining" ControlToValidate="txtEmployeeBegin" Display="Dynamic" ForeColor="Red" ValidationGroup="Calculate"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="reEmployeeBegin" runat="server" ControlToValidate="txtEmployeeBegin" Display="Dynamic" ErrorMessage="Enter a only Positive Number" ForeColor="Red" ValidationExpression="[0-9]*" ValidationGroup="Calculate"></asp:RegularExpressionValidator>
                </div>


            </div>
            <div class="row" runat="server" id="divEmployeeEnd" visible="false">
                <br />
                <div class="col-md-4">
                    <asp:Label runat="server" ID="lblEmployeeEnd" Text="Employees at the ending"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtEmployeeEnd" runat="server" ToolTip="Enter total number of employee at the ending"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:RequiredFieldValidator ID="rfvEmployeeEnd" runat="server" ErrorMessage="Enter a Total number of employees at the ending" ControlToValidate="txtEmployeeEnd" Display="Dynamic" ForeColor="Red" ValidationGroup="Calculate"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="reEmployeeEnd" runat="server" ControlToValidate="txtEmployeeEnd" Display="Dynamic" ErrorMessage="Enter a only Positive Number" ForeColor="Red" ValidationExpression="[0-9]*" ValidationGroup="Calculate"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <br />
                <div class="col-md-4">
                    <asp:Label runat="server" ID="lblEmployeeLeft" Text="Number of Employees who left"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtEmployeeLeft" runat="server" ToolTip="Enter a Number of Employee Left"></asp:TextBox>

                </div>
                <div class="col-md-4">
                    <asp:RequiredFieldValidator ID="rfvEmployeeLeft" runat="server" ErrorMessage="Enter a Number of Employee Left" ControlToValidate="txtEmployeeLeft" Display="Dynamic" ForeColor="Red" ValidationGroup="Calculate"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="reEmployeeLeft" runat="server" ControlToValidate="txtEmployeeLeft" Display="Dynamic" ErrorMessage="Enter a only Positive Number" ForeColor="Red" ValidationExpression="[0-9]*" ValidationGroup="Calculate"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <br />
                <div class="col-md-1">
                </div>
                <div class="col-md-3">
                </div>
                <div class="col-md-4" align="right">
                    <asp:Button runat="server" ID="btnCalculate" Text="Calculate" CssClass="btn btn-success" OnClick="btnCalculate_Click" ValidationGroup="Calculate" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <br />
                    <asp:Label runat="server" ID="lblMessage" Visible="False" BorderColor="#FF0066" CssClass="alert-danger" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="row" runat="server" id="divAnswer">
                <br />
                <div class="col-md-4">
                    <asp:Label runat="server" ID="lblTurnOverRate" CssClass="active" Font-Bold="True" Font-Names="Bahnschrift SemiLight" Font-Size="Medium" ForeColor="Green"></asp:Label>
                </div>
            </div>
            <div class="row" runat="server" id="divMathCalculation" visible="false">
                <hr />
                <br />
                <div class="col-md-12" id="divContent">
                    <h1>Calculation</h1>
                </div>
                <div runat="server" class="col-md-12" id="divMethod1" visible="true">
                    <br />
                    <math xmlns="http://www.w3.org/1998/Math/MathML">
                      <mrow>
                        <mo>Average Number of Employees = &#xA0;</mo>
                        <mrow>
                          <mfrac>
                            <mrow>
                              <mo>(Employees at the begining</mo>
                              <mi>+</mi>
                              <mo>Employees at the ending)</mo>
                            </mrow>
                            <mrow>
                              <mo>2</mo>
                            </mrow>
                          </mfrac>
                        </mrow>
                      </mrow>
                    </math>
                    <br />
                    <br />
                    <math xmlns="http://www.w3.org/1998/Math/MathML">
                    <mrow>
                        <mo>Average Number of Employees = &#xA0;</mo>
                        <mrow>
                          <mfrac>
                            <mrow>
                              <mi>(</mi>
                              <mi runat="server" id="miCalEmployeebegin"></mi>
                              <mi>+</mi>
                              <mi runat="server" id="miCalEmployeeend"></mi>
                              <mi>)</mi>
                            </mrow>
                            <mrow>
                              <mi>2</mi>
                            </mrow>
                          </mfrac>
                          </mrow>
                          <mrow>
                              <mo>&equals;</mo>
                              <mi runat="server" id="miCalAverage"></mi>
                          </mrow>
                      </mrow>
                    </math>
                    <br />
                    <br />
                    <math xmlns="http://www.w3.org/1998/Math/MathML">
                      <mrow>
                        <mo>Turnover Ratio = &#xA0;</mo>
                        <mrow>
                          <mfrac>
                            <mrow>
                              <mo>Number of Employees who left</mo>
                            </mrow>
                            <mrow>
                              <mo>Average Number of Employee</mo>
                            </mrow>
                          </mfrac>
                          <mrow>
                              <mi>x 100 %</mi>
                          </mrow>
                        </mrow>
                      </mrow>
                    </math>
                    <br />
                    <br />
                    <math xmlns="http://www.w3.org/1998/Math/MathML">
                    <mrow>
                        <mo>Turnover Ratio = &#xA0;</mo>
                        <mrow>
                          <mfrac>
                            <mrow>
                              <mi runat="server" id="miCalEmployeeLeft"></mi>
                            </mrow>
                            <mrow>
                              <mi runat="server" id="miDisAverage"></mi>
                            </mrow>
                          </mfrac>
                          <mrow>
                              <mi>x 100 %</mi>
                          </mrow>
                          </mrow>
                          <mrow>
                              <mo>&equals;</mo>
                              <mi runat="server" id="miCalTurnoverRatio"></mi>
                          </mrow>
                          <mrow>
                              <mi>%</mi>
                          </mrow>
                      </mrow>
                    </math>
                </div>
                <div runat="server" class="col-md-12" id="divMethod2">
                     <br />
                    <math xmlns="http://www.w3.org/1998/Math/MathML">
                      <mrow>
                        <mo>Turnover Ratio = &#xA0;</mo>
                        <mrow>
                          <mfrac>
                            <mrow>
                              <mo>Number of Employees who left</mo>
                            </mrow>
                            <mrow>
                              <mo>Average Number of Employee</mo>
                            </mrow>
                          </mfrac>
                          <mrow>
                              <mi>x 100 %</mi>
                          </mrow>
                        </mrow>
                      </mrow>
                    </math>
                    <br />
                    <br />
                    <math xmlns="http://www.w3.org/1998/Math/MathML">
                    <mrow>
                        <mo>Turnover Ratio = &#xA0;</mo>
                        <mrow>
                          <mfrac>
                            <mrow>
                              <mi runat="server" id="miCalEmployeeLeftMethod2"></mi>
                            </mrow>
                            <mrow>
                              <mi runat="server" id="miDisAverageMethod2"></mi>
                            </mrow>
                          </mfrac>
                          <mrow>
                              <mi>x 100 %</mi>
                          </mrow>
                          </mrow>
                          <mrow>
                              <mo>&equals;</mo>
                              <mi runat="server" id="miCalTurnoverRatioMethod2"></mi>
                          </mrow>
                          <mrow>
                              <mi>%</mi>
                          </mrow>
                      </mrow>
                    </math>
                </div>
            </div>
            
            <div class="row">
                <br />
                <hr />
                <div class="col-md-12" id="divContent">
                    <h1>What is Turn Over Rate ?</h1>
                </div>
                <div class="col-md-12">
                    <br />
                    <p align="justify">Turnover rate refers to the percentage of employees leaving a company within a certain period of time. High turnover can be costly to an organization because departing employees frequently need to be replaced. For employers or hiring managers, filling open positions can be a time-consuming activity, and leaving critical positions open for too long can have negative effects on an organization. For this reason, companies should strive to avoid high turnover rates.</p>
                </div>
            </div>
            <div class="row">
                <hr />
                <div class="col-md-12" id="divContent">
                    <h1>Why to Calculate Turn Over Rate ?</h1>
                </div>
                <div class="col-md-12">
                    <br />
                    <p align="justify">Businesses often calculate their rate of employee turnover as a means of predicting the impact on productivity, customer service, or even morale. The U.S. Bureau of Labor Statistics (BLS) also calculates employee turnover at a national level.</p>
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
                        <td>Calculate average number of employees </td>
                        <td>If you know the average value of employees than you should select No then Yes.</td>
                    </tr>
                    <tr>
                        <td>Average Number of Employees</td>
                        <td>Average Number of Employees field is used for if you know the average of employees.</td>
                    </tr>
                    <tr>
                        <td>Employees at the begining</td>
                        <td>Employees at the begining field is used for enter the number of employee who can join company at the starting a financial year.</td>
                    </tr>
                    <tr>
                        <td>Employees at the ending</td>
                        <td>Employees at the ending field is used for enter the number of employee who can join company at the ending a financial year.</td>
                    </tr>
                    <tr>
                        <td>Number of employees who left</td>
                        <td>Number of employees who left is used for enter the number of employee who left the company during the running year.</td>
                    </tr>
                </table>
                <br />
                <hr />
                <div class="col-md-12" style="border: 3px solid black; box-shadow: 5px 10px rgba(219, 219, 219)">
                    <h1>Example  Based on Number of employees at the begining and ending</h1>
                    <hr />
                    <h5>Philip's Industry, during 2009 Number of employees joined this company at the begining and ending with respect to were 500 and 600 and during this year 15 employee left the company. Find the Turn over ratio.</h5>
                    <hr />
                    <p>
                            Employees at the begining = 500<br />
                            Employees at the ending = 600<br />
                            Number of Employees who left = 15<br />
                    </p>
                    <p>
                        Average Number of Employees = (Employees at the begining + Employees at the ending)/2<br />
                        Average Number of Employees = (500 + 600)/2<br />
                        Average Number of Employees = 550        
                    </p>
                    <br />
                    <p>
                            Turnover Ratio = (Number of Employees who left/Average Number of Employees)*100 %<br />
                            Turnover Ratio = (15/500)*100 %<br />
                            Turnover Ratio = 3 %
                    </p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
