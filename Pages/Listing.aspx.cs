using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutopartStore2.Models;
using AutopartStore2.Models.Repository;
using AutopartStore2.Pages;
using AutopartStore2.Pages.Helpers;

namespace AutopartStore2.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private Repository repository = new Repository();
        private int pageSize = 6;
        protected int CurrentPage
        {
            get
            {
                int page;
                page = GetPageFromRequest();
                return page > MaxPage ? MaxPage : page;
            }
        }
        // Новое свойство, возвращающее наибольший номер допустимой страницы
        protected int MaxPage
        {
            get
            {
                int prodCount = FilterAutoparts().Count();
                return (int)Math.Ceiling((decimal)prodCount / pageSize);
            }
        }

        private int GetPageFromRequest()
        {
            int page;
            string reqValue = (string)RouteData.Values["page"] ??
                Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
        }

        public IEnumerable<Autopart> GetParts()
        {
            return repository.Autoparts.OrderBy(g => g.AutopartId)
                 .Skip((CurrentPage - 1) * pageSize)
                 .Take(pageSize);
        }

        // Новый вспомогательный метод для фильтрации игр по категориям
        private IEnumerable<Autopart> FilterAutoparts()
        {
            IEnumerable<Autopart> autoparts = repository.Autoparts;
            string currentCategory = (string)RouteData.Values["category"] ??
                Request.QueryString["category"];
            return currentCategory == null ? autoparts :
                autoparts.Where(p => p.Category == currentCategory);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int selectedAutopartId;
                if (int.TryParse(Request.Form["add"], out selectedAutopartId))
                {
                    Autopart selectedAutopart = repository.Autoparts
                        .Where(g => g.AutopartId == selectedAutopartId).FirstOrDefault();

                    if (selectedAutopart != null)
                    {
                        SessionHelper.GetCart(Session).AddItem(selectedAutopart, 1);
                        SessionHelper.Set(Session, SessionKey.RETURN_URL,
                            Request.RawUrl);

                        Response.Redirect(RouteTable.Routes
                            .GetVirtualPath(null, "cart", null).VirtualPath);
                    }
                }
            }

        }
    }
}