using ShopForBussiness.Dto;
using ShopForBussiness.Framework;
using ShopForBussiness.Services;
using System;
using System.Collections.Generic;

namespace ShopForBussiness
{
    public partial class Products : MyPage
    {
        public IUserService UserService { get; set; }
        public IProductService ProductService { get; set; }
        public UserDto LoggedUser { get; private set; }
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null) LoggedUser = await UserService.GetUser((int)Session["id"]);
            if(LoggedUser!=null)
            {
                lbLogout.Visible = true;
            }
            DataList1.DataSource = await ProductService.GetAll();
            DataList1.DataBind();
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Response.Redirect("./Login.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

    }
}