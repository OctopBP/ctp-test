using RedPanda.Project.Interfaces;
using RedPanda.Project.Services.Interfaces;

namespace RedPanda.Project.Services
{
    public class PurchaseService : IPurchaseService
    {
        private IUserService _userService;
        
        public PurchaseService(IUserService userService)
        {
            _userService = userService;
        }

        public BuyPromoResult TryToBuy(IPromoModel promo)
        {
            var cost = promo.Cost;
            var hasEnoughCurrency = _userService.HasCurrency(cost);

            if (!hasEnoughCurrency)
                return BuyPromoResult.NotEnoughCurrency;

            _userService.ReduceCurrency(cost);
                
            return BuyPromoResult.Success;
        }
    }
}