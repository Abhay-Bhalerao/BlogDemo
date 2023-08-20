<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiplayBlog.aspx.cs" Inherits="Blogs.DiplayBlog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
        }
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border-color: #ccc;
        }
        .list1
        {
            float: left;
        }
        .list2
        {
            float: right;
        }
        .list3
        {
            clear: both;
            float: left;
        }
        .list4
        {
            float: right;
        }
    </style>
</head>
<body>
<form id="form1" runat="server">
    
<asp:ListView ID="lvPost" runat="server" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1">
<LayoutTemplate>
    <table cellpadding="0" cellspacing="0">
        <tr>
            <th>
                Id
            </th>
            <th>
                Title
            </th>
            <th>
                Author
            </th>
            <th>
                Content
            </th>
            <th>
                Status
            </th>
            <th>
                Created Date
            </th>
            <th>
                Publish Date
            </th>
        </tr>
        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
        <%--<tr>
            <td colspan = "3">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvCustomers" PageSize="10">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                            ShowNextPageButton="false" />
                        <asp:NumericPagerField ButtonType="Link" />
                        <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton = "false" />
                    </Fields>
                </asp:DataPager>
            </td>
        </tr>--%>
    </table>
</LayoutTemplate>
<GroupTemplate>
    <tr>
        <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
    </tr>
</GroupTemplate>
<ItemTemplate>
    <asp:Panel runat="server" CssClass="newsBox">
    <td>
        <%# Eval("Id") %>
    </td>
    <td>
        <%# Eval("title") %>
    </td>
    <td>
        <%# Eval("author") %>
    </td>
    <td>
        <%# Eval("content") %>
    </td>
    <td>
        <%# Eval("status") %>
    </td>
    <td>
        <%# Eval("create_date") %>
    </td>
    <td>
        <%# Eval("publish_date") %>
    </td>
     </asp:Panel>
</ItemTemplate>
</asp:ListView>


    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Back to Blog Page</asp:LinkButton>


</form>
</body>
</html>
