using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.UI
{
    public sealed class LobbyView : View
    {
        [SerializeField] private Button startButton; 
        
        private void Start()
        {
            startButton.onClick.AddListener(OpenPromoLayout);
        }

        void OnDestroy()
        {
            startButton.onClick.RemoveListener(OpenPromoLayout);
        }

        private void OpenPromoLayout()
        {
            UIService.Show("PromoLayout");
        }
    }
}