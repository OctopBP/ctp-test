using RedPanda.Project.Helpers;
using RedPanda.Project.Services.Interfaces;

namespace RedPanda.Project.Services
{
    public sealed class UserService : IUserService
    {
        public RxProperty<int> CurrencyRx { get; private set; }
        
        public UserService()
        {
            CurrencyRx = new RxProperty<int>(1000);
        }

        void IUserService.AddCurrency(int delta)
        {
            CurrencyRx.SetValue(CurrencyRx.Value + delta);
        }

        void IUserService.ReduceCurrency(int delta)
        {
            CurrencyRx.SetValue(CurrencyRx.Value - delta);
        }
        
        bool IUserService.HasCurrency(int amount)
        {
            return CurrencyRx.Value >= amount;
        }
    }
}