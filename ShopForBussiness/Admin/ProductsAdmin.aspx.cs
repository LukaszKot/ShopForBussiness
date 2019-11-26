using ShopForBussiness.Domain;
using ShopForBussiness.Framework;
using ShopForBussiness.Services;
using System;

namespace ShopForBussiness.Admin
{
    public partial class ProductsAdmin : MyPage
    {
        public IProductService ProductService { get; set; }
        public IUserService UserService { get; set; }
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("../Login.aspx",false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else if((await UserService.GetUser((int)Session["id"])).Role!=Roles.Admin)
            {
                Response.Redirect("../Index.aspx",false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Response.Redirect("../Login.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}