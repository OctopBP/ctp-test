using Grace.DependencyInjection;
using Grace.DependencyInjection.Attributes;
using RedPanda.Project.Services.Interfaces;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public abstract class View : MonoBehaviour
    {
        protected IUIService UIService { get; private set; }
        protected ILogService LogService { get; private set; }
        protected IExportLocatorScope Container { get; private set; }
        
        [Import]
        public void Inject(IExportLocatorScope container, IUIService uiService, ILogService logService)
        {
            UIService = uiService;
            LogService = logService;
            Container = container;
        }
    }
}