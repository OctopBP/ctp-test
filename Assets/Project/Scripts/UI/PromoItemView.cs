using System;
using System.Collections;
using System.Collections.Generic;
using RedPanda.Project.Data;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Services.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using LogType = RedPanda.Project.Services.Interfaces.LogType;

namespace RedPanda.Project.UI
{
    public class PromoItemView : View
    {
        [SerializeField] private Button backgroundImage;
        [SerializeField] private Image promoItemImage;
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI costText;

        [Header("Title Color")]
        [SerializeField] private Color commonColor;
        [SerializeField] private Color rareColor;
        [SerializeField] private Color epicColor;
        
        [Header("BG Sprite")]
        [SerializeField] private Sprite commonBg;
        [SerializeField] private Sprite rareBg;
        [SerializeField] private Sprite epicBg;
        
        const string COST_FORMAT = "x{0}";

        public void Setup(IPromoModel promoModel)
        {
            // Main info
            titleText.SetText(promoModel.Title);
            costText.SetText(string.Format(COST_FORMAT, promoModel.Cost));
            promoItemImage.sprite = Resources.Load<Sprite>($"Icons/{promoModel.GetIcon()}");
            
            // Setup rarity
            var rarityViewMap = new Dictionary<PromoRarity, (Sprite bg, Color titleColor)>
            {
                { PromoRarity.Common, (commonBg, commonColor)},
                { PromoRarity.Rare, (rareBg, rareColor)},
                { PromoRarity.Epic, (epicBg, epicColor)}
            };
            titleText.color = rarityViewMap[promoModel.Rarity].titleColor;
            backgroundImage.image.sprite = rarityViewMap[promoModel.Rarity].bg;
            
            // Add listener for click
            var purchaseService = Container.Locate<IPurchaseService>();
            backgroundImage.onClick.AddListener(() => OnBuyItem(promoModel, purchaseService));
        }

        private void OnBuyItem(IPromoModel promoModel, IPurchaseService purchaseService)
        {
            var result = purchaseService.TryToBuy(promoModel);
            var oneLineTitle = promoModel.Title.Replace("\n", "");
            
            switch (result)
            {
                case BuyPromoResult.Success:
                    AnimateClick();
                    LogService.Log($"Item bought ({oneLineTitle})"); break;

                case BuyPromoResult.NotEnoughCurrency:
                    LogService.Log($"Not enough currency for {oneLineTitle}", LogType.Error); break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AnimateClick()
        {
            StopAllCoroutines();
            StartCoroutine(ScaleDownAndUp(downScale: 0.95f, duration: 0.15f));
        }
        
        private IEnumerator ScaleDownAndUp(float downScale, float duration)
        {
            var initialScale = Vector3.one;

            for(var time = 0f; time < duration * 2 ; time += Time.deltaTime)
            {
                var progress = Mathf.PingPong(time, duration) / duration;
                transform.localScale = Vector3.Lerp(initialScale, initialScale * downScale, progress);
                yield return null;
            }

            transform.localScale = initialScale;
        }
    }
}