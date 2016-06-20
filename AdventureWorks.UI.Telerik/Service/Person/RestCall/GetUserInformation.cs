namespace AdventureWorks.UI.Telerik.Service.Person.RestCall
{
    using API.Model.Module.User;
    using API.Route.Module.User;
    using RestClient;
    using Service.Base;

    public class GetUserInformation : RestData<GetUserInformationModel>
    {
        public GetUserInformation()
        {
        }

        public GetUserInformation(string token) : base(token)
        {
        }

        protected override string GetConnectionUrl()
        {
            return GetDataNancyUrl(UserInformationRoute.Base + UserInformationRoute.GetUserInformation);
        }

        protected override RestClient.ClientData GetClientData()
        {
            return new ClientData(Token);
        }
    }
}
