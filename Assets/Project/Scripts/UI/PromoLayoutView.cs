using System.Linq;
using RedPanda.Project.Services.Interfaces;
using RedPanda.Project.Services.UI;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public class PromoLayoutView : View
    {
        [SerializeField] private Transform balanceContainer;
        [SerializeField] private Transform categoriesContainer;

        private void Start()
        {
            var promoService = Container.Locate<IPromoService>();
            var categoryFactory = Container.Locate<IFactory<CategoryView>>();
            var balanceFactory = Container.Locate<IFactory<BalanceView>>();
            
            balanceFactory.Create(parent: balanceContainer);
            
            var promoGroups = promoService.GetPromos().GroupBy(promo => promo.Type);
            foreach (var promoGroup in promoGroups)
            {
                var category = categoryFactory.Create(parent: categoriesContainer);
                category.Setup(title: promoGroup.Key.ToString(), promoGroup);
            }
        }
    }
}