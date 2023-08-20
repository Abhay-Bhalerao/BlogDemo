<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlogPage.aspx.cs" Inherits="Blogs.BlogPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
        }
        form {
            border: 3px solid #f1f1f1;
        }
        input[type=text], input[type=password] {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }
        button:hover {
            opacity: 0.8;
        }
        .cnbtn {
            background-color: #ec3f3f;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 49%;
        }
        .lgnbtn {
            background-color: #4CAF50;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 20%;
        }
        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
        }
        img.avatar {
            width: 40%;
            border-radius: 50%;
        }
        .container {
            padding: 16px;
        }
        span.psw {
            float: right;
            padding-top: 16px;
        }
        /* Change styles for span and cancel button on extra small screens */
        @media screen and (max-width: 300px) {
            span.psw {
                display: block;
                float: none;
            }
            .cnbtn {
                width: 100%;
            }
        }
        .frmalg {
            margin: auto;
            width: 40%;
        }
        .auto-style1 {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #4CAF50;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            cursor: pointer;
        }
       .container {
  font-family:Calibri;
  font-size: 24px;
  align-content:center;
  margin: 25px;
  width: 350px;
  height: 20px;
  outline: dashed 1px black;
}
    </style>
 <meta name="viewport" content="width=device-width, initial-scale=1">
</head>
<body>
<form id="form1" runat="server">
<div style="width:800px; margin:0 auto;"><asp:Label ID="lblName" runat="server" Text="Label"/>   </div>
<div style="overflow-x:auto;">
<table border="0" cellpadding="0" cellspacing="0">
        <tr>
             <td >             
                <asp:HiddenField ID="idfield" runat="server" />
            </td>
         </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    <tr>
        <td>
            Select Post:
        </td>
        
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="ddlPost" runat="server" Height="30px" Width="550" AutoPostBack="true" OnSelectedIndexChanged="ddlPost_SelectedIndexChanged"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
        <tr>
        <td>
            Title:
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtTitle" runat="server" Width = "550" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
     <tr>
        <td>
            Author:
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtAuthor" runat="server"  Enabled="false" Width = "550" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            Content:
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Width = "550" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            Status
        </td>
    </tr>
    <tr>     
        <td>
            <asp:DropDownList ID="ddlStatus" runat="server" Height="30px" Width="550" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                <asp:ListItem>Select Status</asp:ListItem>
                <asp:ListItem Value="Draft">Draft</asp:ListItem>
                <asp:ListItem Value="Publish">Publish</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
     <tr>
        <td>
            &nbsp;
        </td>
     </tr>
    <div id="divcreate" runat="server">
         <tr>
        <td>
            Create Date
        </td>
    </tr>
         <tr>     
        <td>     
              <asp:Calendar  ID="Calendar1" runat="server" Visible="False" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" OnSelectionChanged="Calendar1_SelectionChanged" ShowGridLines="True" Width="220px">
                  <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                  <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                  <OtherMonthDayStyle ForeColor="#CC9966" />
                  <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                  <SelectorStyle BackColor="#FFCC66" />
                  <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                  <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
              </asp:Calendar>
              <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Show Date</asp:LinkButton>
              <asp:TextBox ID="txtCalender" runat="server"></asp:TextBox>

        </td>
    </tr> 
    </div>
    <div id="divpublish" runat="server">
        <tr>
             <td>
                      Publish Date
             </td>
         </tr>
        <tr>     
        <td>     
              <asp:Calendar  ID="Calendar2" runat="server" Visible="False" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" OnSelectionChanged="Calendar2_SelectionChanged" ShowGridLines="True" Width="220px">
                  <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                  <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                  <OtherMonthDayStyle ForeColor="#CC9966" />
                  <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                  <SelectorStyle BackColor="#FFCC66" />
                  <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                  <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
              </asp:Calendar>
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Show Date</asp:LinkButton>
              <asp:TextBox ID="txtCalender2" runat="server"></asp:TextBox>

        </td>
    </tr>
    </div>
    <tr>

        <td>
            <asp:Button ID="btnDraft" Text="Save" runat="server" CssClass="lgnbtn" OnClick="btnDraft_Click"  />&nbsp&nbsp&nbsp
             <asp:Button ID="btnViewPost" Text="ViewPost" runat="server" CssClass="lgnbtn" Width="83px" OnClick="btnViewPost_Click"  />
       </td>
       
    </tr>
</table>
</div>
 </form>
</body>
</html>
 
