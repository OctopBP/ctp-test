using Grace.DependencyInjection;
using RedPanda.Project.UI;
using UnityEngine;

namespace RedPanda.Project.Services.UI
{
    public class UIBalanceFactory : IFactory<BalanceView>
    {
        private IExportLocatorScope _exportLocatorScope;
        private BalanceView _prefab;

        public UIBalanceFactory(IExportLocatorScope exportLocatorScope)
        {
            _exportLocatorScope = exportLocatorScope;
            _prefab = Resources.Load<BalanceView>($"UI/Balance");
        }

        public BalanceView Create(Transform parent)
        {
            var balanceView = Object.Instantiate(_prefab, parent);
            _exportLocatorScope.Inject(balanceView);
            return balanceView;
        }
    }
}