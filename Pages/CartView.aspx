<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartView.aspx.cs" Inherits="AutopartStore2.Pages.CartView" 
    MasterPageFile="~/Pages/Store.Master"
    %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <h2 class="cart__title">Ваша корзина</h2>
        <table id="cartTable">
            <thead>
                <tr>
                    <th>Кол-во товаров</th>
                    <th>Название</th>
                    <th>Цена</th>
                    <th>Общая стоимость</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeater1" ItemType="AutopartStore2.Models.CartLine"
                    SelectMethod="GetCartLines" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <tr>
                            <td><%# Item.Quantity %></td>
                            <td><%# Item.Autopart.Name %></td>
                            <td><%# Item.Autopart.Price%> грн</td>
                            <td><%# ((Item.Quantity * Item.Autopart.Price))%> грн</td>
                            <td>
                                <button type="submit" class="cart__delete" name="remove" value="<%#Item.Autopart.AutopartId %>">
                                    Удалить</button>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3">Итого:</td>
                    <td><%= CartTotal %> грн</td>
                </tr>
            </tfoot>
        </table>
        <div class="cart__btn">
            <a class="actionButtons btn" href="<%= ReturnUrl %>">Продолжить покупки</a>
            <a class="actionButtons btn" href="<%= CheckoutUrl %>">Оформить заказ</a>
        </div>
    </div>
</asp:Content>