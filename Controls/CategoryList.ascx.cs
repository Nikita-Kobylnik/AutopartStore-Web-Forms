using AutopartStore2.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutopartStore2.Controls
{
    public partial class CategoryList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected IEnumerable<string> GetCategories()
        {
            return new Repository().Autoparts
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(x => x);
        }

        protected string CreateHomeLinkHtml()
        {
            string path = RouteTable.Routes.GetVirtualPath(null, null).VirtualPath;
            return string.Format("<li class='menu__list-item'> <a class='menu__list-link' href='{0}'>Главная</a> </li>", path);
        }

        protected string CreateLinkHtml(string category)
        {
            string path = RouteTable.Routes.GetVirtualPath(null, null,
                new RouteValueDictionary() { { "category", category },
                    {"page", "1"} }).VirtualPath;

            return string.Format("<li class='menu__list-item'> <a class='menu__list-link' href='{0}'>{1}</a> </li>",
                path, category);
        }
    }
}