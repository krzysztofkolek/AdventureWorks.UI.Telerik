namespace AdventureWorks.UI.Telerik.Service.Base
{
    using System; 
    using Configuration;
    using Ninject;
    using RestClient;
    using RestSharp;

    public abstract class RestData<T>
        where T: class, new()
    { 
        protected BaseRestClient<T> Client { get; set; }
        protected String Token { get; set; }

        public RestData()
        {
        } 

        public RestData(String token)
        {
            SetUrlAndCreateClientInstance(token);
        }


        protected abstract String GetConnectionUrl();
        protected abstract ClientData GetClientData();
        protected virtual Method GetWhatMethod()
        {
            return Method.GET;
        }

        public RestData<T> SetUrlAndCreateClientInstance(String token)
        {
            var data = GetClientData();
            data.Token = token;

            Client = new BaseRestClient<T>(GetConnectionUrl(), data, GetWhatMethod());
            return this;
        }

        public T Result()
        {
            return Client.ExecuteAndGetRestResult();
        }


        protected String GetDataNancyUrl(String pathWithoughtServer)
        {
            return String.Format("{0}{1}", BaseConfiguration.Url, pathWithoughtServer);
        }
    }
}
