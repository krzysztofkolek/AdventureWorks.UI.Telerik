namespace AdventureWorks.UI.Telerik.Service.HumanResources.RestCall
{
    using API.Model.Module.HumanResources;
    using API.Route.Module.HumanResources;
    using RestClient;
    using RestSharp;
    using Service.Base;

    public class GetEmployees : RestData<GetEmployeesModel>
    {
        private int _page { get; set; }

        public GetEmployees()
        {
        }

        public GetEmployees(string token)
            : base(token)
        {
        }

        public GetEmployees SetPage(int page)
        {
            _page = page;
            return this;
        }

        protected override string GetConnectionUrl()
        {
            return GetDataNancyUrl(EmployeesRoute.Base + EmployeesRoute.GetEmployees);
        }


        protected override ClientData GetClientData()
        {
            var clientdata = base.GetClientData();

            clientdata.Parameters = new Parameters()
            {
                Name = "page",
                Value = _page.ToString(),
                Type = ParameterType.QueryString,
            };

            return clientdata;
        }
    }
}
