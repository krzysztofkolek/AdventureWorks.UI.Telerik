namespace AdventureWorks.UI.Telerik.Configuration
{
    using System;
    using System.Configuration;

    public sealed class NancyServerConfiguration : ConfigurationSection
    {
        //private static NancyServerConfiguration settings = ConfigurationManager.GetSection("NancyServerConfiguration") as NancyServerConfiguration;

        //public static NancyServerConfiguration Settings
        //{
        //    get
        //    {
        //        return settings;
        //    }
        //}

        ConfigurationProperty _SomeStuff;
        public NancyServerConfiguration()
        {
            _SomeStuff = new ConfigurationProperty("Url", typeof(string), "<UNDEFINED>");

            this.Properties.Add(_SomeStuff);
        }

        //[ConfigurationProperty("Url", IsRequired = false, DefaultValue = "http://localhost:5656/")] 
        //public String Url
        //{
        //    get { return (String)base["Url"]; }
        //    set { base["Url"] = value; }
        //}
    }
}
