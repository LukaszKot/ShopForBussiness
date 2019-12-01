using ShopForBussiness.Domain;
using ShopForBussiness.Dto;
using ShopForBussiness.Extensions;
using ShopForBussiness.Framework;
using ShopForBussiness.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

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
            var result = await ProductService.GetAll();
            result = result.Where(x => x.AmountInMagazine > 0);
            if(tbSearch.Text.IsNotEmpty())
            {
                result = result.Where(x => x.Name.Contains(tbSearch.Text));
            }
            if(ddlAuthors.SelectedValue!="Wszyscy")
            {
                result = result.Where(x => x.Author == ddlAuthors.SelectedValue);
            }
            switch(ddlOrder.SelectedValue)
            {
                case "Domyślnie":
                    result = result.OrderBy(x => x.ID);
                    break;
                case "Cena rosnąco":
                    result = result.OrderBy(x => x.Prize);
                    break;
                case "Cena malejąco":
                    result = result.OrderByDescending(x => x.Prize);
                    break;
                case "Alfabetycznie":
                    result = result.OrderBy(x => x.Name);
                    break;
                case "Odwrotnie do alfabetycznie":
                    result = result.OrderByDescending(x => x.Name);
                    break;
            }
            dlProducts.DataSource = result;
            dlProducts.DataBind();
            var lastSelected = ddlAuthors.SelectedValue;
            ddlAuthors.DataSource = (new List<string> { "Wszyscy" }).Union((await ProductService.GetAll())
                .Where(x=> x.Name.Contains(tbSearch.Text))
                .GroupBy(x=>x.Author,x=>x,(x,y)=>x));
            ddlAuthors.DataBind();
            ddlAuthors.SelectedValue = lastSelected;

            UpdateCart();
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Response.Redirect("./Login.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void bSearch_Click(object sender, EventArgs e)
        {
        }

        protected void ddlAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected async void lbAdd_Click(object sender, EventArgs e)
        {
            var cart= (Cart)Session["cart"];
            if(cart is null)
            {
                cart = new Cart();
            }
            LinkButton btn = (LinkButton)sender;
            DataListItem item = (DataListItem)btn.NamingContainer;
            var id = int.Parse(((Label)item.FindControl("idInfo")).Text);
            var product = await ProductService.Get(id);
            cart.Add(product);
            Session["cart"] = cart;
            UpdateCart();
        }

        private void UpdateCart()
        {
            if (Session["cart"] is Cart cart)
            {
                itemsCounter.Text = cart.GetSum().ToString();
                if (itemsCounter.Text != "0") itemsCounter.Visible = true;
            }
            if (itemsCounter.Text == "0") itemsCounter.Visible = false;
        }

        protected void ibBasket_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("Basket.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}