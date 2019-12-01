using Autofac;
using Autofac.Integration.Web;
using ShopForBussiness.MySQL;
using System;
using System.Web;

namespace ShopForBussiness.Framework
{
    public abstract class MyPage : System.Web.UI.Page
    {
        public ShopForBusinessContext _dbContext { get; set; }
        private ILifetimeScope scope;
        protected void Page_PreInit(object sender, EventArgs e)
        {
            var cpa = (IContainerProviderAccessor)HttpContext.Current.ApplicationInstance;
            var cp = cpa.ContainerProvider;
            scope = cp.RequestLifetime.BeginLifetimeScope();
            cp.RequestLifetime.InjectUnsetProperties(this);

            if (!_dbContext.Database.Exists())
            {
                _dbContext.Database.CreateIfNotExists();
            }
        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            scope.Dispose();
        }
    }
}