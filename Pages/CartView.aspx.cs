using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutopartStore2.Models;
using AutopartStore2.Models.Repository;
using AutopartStore2.Pages.Helpers;

namespace AutopartStore2.Pages
{
    public partial class CartView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Repository repository = new Repository();
                int autopartId;
                if (int.TryParse(Request.Form["remove"], out autopartId))
                {
                    Autopart autopartToRemove = repository.Autoparts
                        .Where(g => g.AutopartId == autopartId).FirstOrDefault();
                    if (autopartToRemove != null)
                    {
                        SessionHelper.GetCart(Session).RemoveLine(autopartToRemove);
                    }
                }
            }
        }

        public IEnumerable<CartLine> GetCartLines()
        {
            return SessionHelper.GetCart(Session).Lines;
        }

        public decimal CartTotal
        {
            get
            {
                return SessionHelper.GetCart(Session).ComputeTotalValue();
            }
        }

        public string ReturnUrl
        {
            get
            {
                return SessionHelper.Get<string>(Session, SessionKey.RETURN_URL);
            }
        }

        public string CheckoutUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "checkout",
                    null).VirtualPath;
            }
        }

    }
}