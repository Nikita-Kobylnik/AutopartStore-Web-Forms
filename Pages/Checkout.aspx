<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" 
    Inherits="AutopartStore2.Pages.Checkout" 
    MasterPageFile="~/Pages/Store.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="order" id="content">

        <div class="order__main-info checkout" id="checkoutForm" runat="server">
            <h2 class="order__title">Оформить заказ</h2>
            <p class="order__text">Пожалуйста, введите свои данные, и мы отправим Ваш товар прямо сейчас!</p>

        <div id="errors" data-valmsg-summary="true">
            <ul>
                <li style="display:none"></li>
            </ul>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>

            <h3 class="order__customer-title">Заказчик</h3>
            <div class="order__customer-info">
                <label class="order__name" for="name">Имя:</label>
                <SX:VInput Property="Name" runat="server" />
            </div>

            <h3 class="order__adres-title">Адрес доставки</h3>
            <div class="order__adres-wrapper">
                <%--<div class="order__adres-item">
                    <label class="order__adres-subtitle" for="line1">Адрес отделения почты:</label>
                    <SX:VInput Property="Line1" runat="server" />
                </div>
                <div class="order__adres-item">
                    <label class="order__adres-subtitle" for="line2">Домашний адрес:</label>
                    <SX:VInput Property="Line2" runat="server" />
                </div>
                <div class="order__adres-item">
                    <label class="order__adres-subtitle" for="line3">Дополнительный адрес:</label>
                    <SX:VInput Property="Line3" runat="server" />
                </div>
                <div class="order__adres-item">
                    <label class="order__adres-subtitle" for="city">Город:</label>
                    <SX:VInput Property="City" runat="server" />
                </div>--%>
                <div class="order__adres-left">
                    <label class="order__adres-subtitle" for="line1">Адрес отделения почты:</label>
                    <label class="order__adres-subtitle" for="line2">Домашний адрес:</label>
                    <label class="order__adres-subtitle" for="line3">Дополнительный адрес:</label>
                    <label class="order__adres-subtitle" for="city">Город:</label>
                </div>
                <div class="order__adres-right">
                    <SX:VInput Property="Line1" runat="server" />
                    <SX:VInput Property="Line2" runat="server" />
                    <SX:VInput Property="Line3" runat="server" />
                    <SX:VInput Property="City" runat="server" />
                </div>
            </div>

<%--            <h3>Детали заказа</h3>
            <input type="checkbox" id="giftwrap" name="giftwrap" value="true" />
            Использовать подарочную упаковку?--%>
        
            
                <button class="order__btn btn" type="submit">Обработать заказ</button>
            
        </div>
        <div id="checkoutMessage" runat="server">
            <h2>Спасибо!</h2>
            Спасибо что выбрали наш магазин! Мы постараемся максимально быстро отправить ваш заказ   
        </div>
    </div>
</asp:Content>