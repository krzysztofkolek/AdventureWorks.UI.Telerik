namespace AdventureWorks.UI.Telerik.Service.Person.Base
{
    using API.Model.Module.User;
    using Ninject;
    using RestCall;
    using Service.Base;

    public class BasePersonService : BaseService
    {
        [Inject]
        GetUserInformation _userInformation { get; set; }

        public override void SetDependencys()
        {
            _userInformation.SetUrlAndCreateClientInstance(Token);
        }

        public virtual GetUserInformationModel GetUserInformation()
        {
            return _userInformation.Result();
        }
    }
}