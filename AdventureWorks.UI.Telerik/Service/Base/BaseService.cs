namespace AdventureWorks.UI.Telerik.Service.Base
{
    using System;

    public abstract class BaseService
    {
        protected String Token { get; set; }

        public void SetToken(String token)
        {
            Token = token;
        }

        public abstract void SetDependencys();
    }
}
