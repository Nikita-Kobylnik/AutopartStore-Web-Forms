<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="AutopartStore2.Pages.Listing" 
    MasterPageFile="~/Pages/Store.Master"
    %>
<%@ Import Namespace="System.Web.Routing" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <%-- 
        <div class="product__wrapper">
            <%
                foreach (AutopartStore2.Models.Autopart autopart  in GetParts())
                {
                    Response.Write(String.Format(@"
                        <div class='product__item'>
                            <div class='product__item-inner'>
                                <img src='/Content/2.jpg' alt='product' />
                                <h3 class='product__item-name'>{0}</h3>
                                <p class='product__item-price'>Цена: <span>{2} грн</span></p>
                                <p class='product__item-desc'>Описание: </br> {1}</p>
                                <p class='product__item-amount'>В наличии: {3} шт.</p>
                                <button class='product__item-add' name='add' type='submit' value='{4}'>
                                    Добавить в корзину
                                </button>
                            </div>
                        </div>", 
                        autopart.Name, autopart.Description, autopart.Price, autopart.Amount, autopart.AutopartId));
                }
            %>
        </div>
     --%>
        <div class="product__wrapper">
            <asp:Repeater ItemType="AutopartStore2.Models.Autopart"
                SelectMethod="GetParts" runat="server">
                <ItemTemplate>
                    <div class="product__item">
                        <div class='product__item-inner'>
                            <img src='/Content/2.jpg' alt='product' />
                            <div class='product__item-info'>
                                <h3 class="product__item-name"><%# Item.Name %></h3>
                                <p class="product__item-price"><%# Item.Price %> грн</p>
                                <p class="product__item-desc"><%# Item.Description %></p>
                                <p class="product__item-amount">В наличии: <%# Item.Amount %> шт</p>
                            </div>
                            <button class="product__item-add" name="add" type="submit" value="<%# Item.AutopartId %>">
                                Добавить в корзину
                            </button>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    
</asp:Content>
<asp:Content ContentPlaceHolderID="footerContent" runat="server">
    <div class="pager">
        <%
            for (int i = 1; i <= MaxPage; i++)
            {
                string category = (string)Page.RouteData.Values["category"]
                    ?? Request.QueryString["category"];
                
                string path = RouteTable.Routes.GetVirtualPath(null, null,
                    new RouteValueDictionary() { {"category", category}, { "page", i } }).VirtualPath;
                Response.Write(
                    String.Format("<a href='{0}' {1}>{2}</a>",
                        path, i == CurrentPage ? "class='selected'" : "", i));
            }
        %>
    </div>
</asp:Content>
