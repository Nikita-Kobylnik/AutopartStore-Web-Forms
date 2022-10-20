using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutopartStore2.Models;
using AutopartStore2.Models.Repository;
using System.Web.ModelBinding;

namespace AutopartStore2.Pages.Admin
{
    public partial class Autoparts : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IEnumerable<Autopart> GetAutoparts()
        {
            return repository.Autoparts;
        }

        public void UpdateAutopart(int AutopartID)
        {
            Autopart myAutopart = repository.Autoparts
                .Where(p => p.AutopartId == AutopartID).FirstOrDefault();
            if (myAutopart != null && TryUpdateModel(myAutopart,
                new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.SaveAutopart(myAutopart);
            }
        }
        public void DeleteAutopart(int AutopartID)
        {
            Autopart myAutopart = repository.Autoparts
                .Where(p => p.AutopartId == AutopartID).FirstOrDefault();
            if (myAutopart != null)
            {
                repository.DeleteAutopart(myAutopart);
            }
        }
        public void InsertAutopart()
        {
            Autopart myAutopart = new Autopart();
            if (TryUpdateModel(myAutopart,
                new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.SaveAutopart(myAutopart);
            }
        }
    }
}