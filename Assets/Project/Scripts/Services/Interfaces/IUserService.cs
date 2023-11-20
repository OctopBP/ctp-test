using RedPanda.Project.Helpers;

namespace RedPanda.Project.Services.Interfaces
{
    public interface IUserService
    {
        RxProperty<int> CurrencyRx { get; }
        void AddCurrency(int delta);
        void ReduceCurrency(int delta);
        bool HasCurrency(int amount);
    }
}