using Grace.DependencyInjection;
using RedPanda.Project.UI;
using UnityEngine;

namespace RedPanda.Project.Services.UI
{
    public class UICategoriesFactory : IFactory<CategoryView>
    {
        private IExportLocatorScope _exportLocatorScope;
        private CategoryView _prefab;

        public UICategoriesFactory(IExportLocatorScope exportLocatorScope)
        {
            _exportLocatorScope = exportLocatorScope;
            _prefab = Resources.Load<CategoryView>($"UI/Category");
        }

        public CategoryView Create(Transform parent)
        {
            var category = Object.Instantiate(_prefab, parent);
            _exportLocatorScope.Inject(category);
            return category;
        }
    }
}