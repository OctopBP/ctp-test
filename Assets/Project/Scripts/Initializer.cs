using Grace.DependencyInjection;
using RedPanda.Project.Services;
using RedPanda.Project.Services.Interfaces;
using RedPanda.Project.Services.UI;
using RedPanda.Project.UI;
using UnityEngine;

namespace RedPanda.Project
{
    public sealed class Initializer : MonoBehaviour
    {
        private DependencyInjectionContainer _container = new();
        
        private void Awake()
        {
            _container.Configure(block =>
            {
                block.Export<LogServiceService>().As<ILogService>().Lifestyle.Singleton();
                block.Export<UserService>().As<IUserService>().Lifestyle.Singleton();
                block.Export<PromoService>().As<IPromoService>().Lifestyle.Singleton();
                block.Export<UIService>().As<IUIService>().Lifestyle.Singleton();
                block.Export<PurchaseService>().As<IPurchaseService>().Lifestyle.Singleton();
                block.Export<UIBalanceFactory>().As<IFactory<BalanceView>>().Lifestyle.Singleton();
                block.Export<UICategoriesFactory>().As<IFactory<CategoryView>>().Lifestyle.Singleton();
                block.Export<UIPromoViewFactory>().As<IFactory<PromoItemView>>().Lifestyle.Singleton();
            });

            _container.Locate<ILogService>();
            _container.Locate<IUserService>();
            _container.Locate<IPromoService>();
            _container.Locate<IPurchaseService>();
            _container.Locate<IUIService>().Show("LobbyView");
            _container.Locate<IFactory<BalanceView>>();
            _container.Locate<IFactory<CategoryView>>();
            _container.Locate<IFactory<PromoItemView>>();
        }
    }
}