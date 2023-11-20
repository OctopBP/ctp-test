using System.Linq;
using RedPanda.Project.Data;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Services.UI;
using TMPro;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public class CategoryView : View
    {
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private Transform itemsContainer;

        public void Setup(string title, IGrouping<PromoType,IPromoModel> group)
        {
            var promoItemFactory = Container.Locate<IFactory<PromoItemView>>();
            
            titleText.SetText(title);
            
            var sortedGroup = group.OrderByDescending(item => item.Rarity);
            foreach (var promoItem in sortedGroup)
            {
                var item = promoItemFactory.Create(parent: itemsContainer);
                item.Setup(promoItem);
            }
        }
    }
}