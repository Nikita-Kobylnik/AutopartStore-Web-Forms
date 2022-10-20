<%@ Page Title="" Language="C#" 
    MasterPageFile="~/Pages/Admin/Admin.Master" 
    AutoEventWireup="true" CodeBehind="Orders.aspx.cs" 
    Inherits="AutopartStore2.Pages.Admin.Orders" EnableViewState="false" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="outerContainer">
        <table id="ordersTable">
            <tr>
                <th>Имя заказчика</th>
                <th>Город</th>
                <th>Товаров в заказе</th>
                <th>Сумма</th>
                <th></th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" SelectMethod="GetOrders"
                ItemType="AutopartStore2.Models.Order">
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.Name %></td>
                        <td><%#: Item.City %></td>
                        <td><%# Item.OrderLines.Sum(ol => ol.Quantity) %></td>
                        <td><%# Total(Item.OrderLines).ToString("C") %> </td>
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder1" Visible="<%# !Item.Dispatched %>" runat="server">
                                <button class="order__send" type="submit" name="dispatch"
                                    value="<%# Item.OrderId %>">
                                    Отправить в службу доставки</button>
                            </asp:PlaceHolder>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

    <div id="ordersCheck">
        <asp:CheckBox ID="showDispatched" runat="server" Checked="false" AutoPostBack="true" />
        Показать отправленные в службу доставки заказы?
    </div>
</asp:Content>
