using RedPanda.Project.Interfaces;

namespace RedPanda.Project.Services.Interfaces
{
    public enum BuyPromoResult
    {
        Success,
        NotEnoughCurrency
    }
    
    public interface IPurchaseService
    {
        BuyPromoResult TryToBuy(IPromoModel promo);
    }
}