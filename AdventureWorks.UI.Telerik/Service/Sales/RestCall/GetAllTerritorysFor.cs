namespace AdventureWorks.UI.Telerik.Service.Sales.RestCall
{
    using System;
    using System.Collections.Generic;
    using API.Model.Module.Sales;
    using RestClient;
    using Service.Base;

    public class GetAllTerritorysFor : RestData<GetAllTerritorysForModel>
    {
        private Dictionary<String, String> _parameters;

        protected override string GetConnectionUrl()
        {
            throw new System.NotImplementedException();
        }

        protected override RestClient.ClientData GetClientData()
        {
            var clientData = new ClientData(Token);
            foreach (var parameter in _parameters)
            {
                clientData.SetParameters(new Parameters()
                {
                    Name = parameter.Key,
                    Value = parameter.Value
                });
            }
            return clientData;
        }

        public GetAllTerritorysFor SetParameters(Dictionary<String, String> parameters)
        {
            _parameters = parameters;
            return this;
        }
    }
}
