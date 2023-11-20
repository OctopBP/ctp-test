using RedPanda.Project.Services.Interfaces;
using TMPro;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public class BalanceView : View
    {
        [SerializeField] private TextMeshProUGUI balanceText;
        
        void Start()
        {
            var userService = Container.Locate<IUserService>(); 
            
            SetBalance(userService.CurrencyRx.Value);
            userService.CurrencyRx.Subscribe(SetBalance);
        }

        private void SetBalance(int amount)
        {
            balanceText.SetText(amount.ToString());
        }
    }
}