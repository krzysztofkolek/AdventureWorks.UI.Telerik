namespace AdventureWorks.UI.Telerik.Configuration
{
    using System;
    using System.Web.Configuration;

    public static class BaseConfiguration
    {
        //public NancyServerConfiguration GetNancyServerConfiguration
        //{
        //    get
        //    {
        //        return (NancyServerConfiguration)WebConfigurationManager.GetSection("NancyServer");
        //    }
        //} 

        public static String Url
        {
            get
            {
                return "http://localhost:5117/";
            }
        }
    }
}
