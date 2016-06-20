namespace AdventureWorks.UI.Telerik.Service.Sales.RestCall
{
    using API.Model.Module.Sales;
    using Service.Base;

    public class GetAllProductsSold : RestData<GetAllProductsSoldModel>
    {
        protected override string GetConnectionUrl()
        {
            throw new System.NotImplementedException();
        }

        protected override RestClient.ClientData GetClientData()
        {
            throw new System.NotImplementedException();
        }
    }
}
