using Grace.DependencyInjection;
using RedPanda.Project.UI;
using UnityEngine;

namespace RedPanda.Project.Services.UI
{
    public class UIPromoViewFactory : IFactory<PromoItemView>
    {
        private IExportLocatorScope _exportLocatorScope;
        private PromoItemView _prefab;
        
        private UIControl<PromoItemView> _viewControl;

        public UIPromoViewFactory(IExportLocatorScope exportLocatorScope)
        {
            _exportLocatorScope = exportLocatorScope;
            _prefab = Resources.Load<PromoItemView>($"UI/Item");
        }

        public PromoItemView Create(Transform parent)
        {
            
            var promoView = Object.Instantiate(_prefab, parent);
            _exportLocatorScope.Inject(promoView);
            return promoView;
        }
    }
}