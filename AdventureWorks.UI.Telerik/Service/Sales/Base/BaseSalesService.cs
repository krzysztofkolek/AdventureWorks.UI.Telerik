namespace AdventureWorks.UI.Telerik.Service.Sales.Base
{
    using System;
    using System.Collections.Generic;
    using API.Model.Module.Sales;
    using Ninject;
    using RestCall;
    using Service.Base;

    public class BaseSalesService : BaseService
    {
        [Inject]
        private GetAllProductsSold _getAllProductsSold { get; set; }
        [Inject]
        private GetProductsSoldByPerson _getProductsSoldByPerson { get; set; }
        [Inject]
        private GetAllTerritorysFor _getAllTerritorysFor { get; set; }


        public override void SetDependencys()
        {
            _getAllProductsSold.SetUrlAndCreateClientInstance(Token);
            _getAllTerritorysFor.SetUrlAndCreateClientInstance(Token);
            _getProductsSoldByPerson.SetUrlAndCreateClientInstance(Token);
        }

        /// <summary>
        /// Gets all products sold.
        /// </summary>
        /// <returns></returns>
        public virtual GetAllProductsSoldModel GetAllProductsSold()
        {
            return _getAllProductsSold.Result();
        }
        
        /// <summary>
        /// Gets the products sold by person.
        /// </summary>
        /// <returns></returns>
        public virtual GetProductsSoldByPersonModel GetProductsSoldByPerson()
        {
            return _getProductsSoldByPerson.Result();
        }

        /// <summary>
        /// Gets all territorys for passed parameters.
        /// </summary>
        /// <returns></returns>
        public virtual GetAllTerritorysForModel GetAllTerritorysFor(Dictionary<String, String> parameters)
        {
            return _getAllTerritorysFor.SetParameters(parameters)
                                       .Result();
        }

    }
}