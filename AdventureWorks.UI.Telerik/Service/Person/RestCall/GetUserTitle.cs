namespace AdventureWorks.UI.Telerik.Service.Person.RestCall
{
    using API.Route.Module.User;
    using RestClient;
    using Service.Base;
    using API.Model.Module.User;

    public class GetUserTitle : RestData<GetUserTitleModel>
    {
        public GetUserTitle()
        {
        }

        public GetUserTitle(string token) : base(token)
        {
        }

        protected override string GetConnectionUrl()
        {
            return GetDataNancyUrl(UserTitleRoute.Base + UserTitleRoute.GetUserTitle);
        }

        protected override RestClient.ClientData GetClientData()
        {
            return new ClientData(Token);
        }
    }
}
