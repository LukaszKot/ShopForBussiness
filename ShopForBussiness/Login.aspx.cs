using ShopForBussiness.Domain;
using ShopForBussiness.Framework;
using ShopForBussiness.MySQL;
using ShopForBussiness.Services;
using System;
using System.Web.UI.WebControls;

namespace ShopForBussiness
{
    public partial class Index : MyPage
    {
        public IUserService _userService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        { 
            if(Session["id"]!=null)
            {
                Response.Redirect("Index.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected async void bRegister_Click(object sender, EventArgs e)
        {
            var result = await _userService.RegisterAsync(tbRegistrationEmail.Text, tbRegistrationPassword.Text, tbRegistrationRetypePassword.Text, cRegulation.Checked);
            Validate(result, "vgRegister");
        }

        protected async void bLogin_Click(object sender, EventArgs e)
        {
            var result = await _userService.LoginAsync(tbLoginEmail.Text, tbLoginPassword.Text);
            if(int.TryParse(result, out int id))
            {
                Session["id"] = id;
                if((await _userService.GetUser(id)).Role==Roles.Customer)
                {
                    Response.Redirect("Index.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    Response.Redirect("./Admin/ProductsAdmin.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                
            }
            else
            {
                Validate(result, "vgLogin");
            }
            
        }

        private void Validate(string message, string group)
        {
            var validator = new CustomValidator();
            validator.ValidationGroup = group;
            validator.IsValid = false;
            validator.ErrorMessage = message;
            Page.Validators.Add(validator);
        }
    }
}