using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using Analytics;

public class Purchaser : MonoBehaviour
{
    public Action<int, string> CurrencyBuyEvent;
    public Action OtherBuyEvent;

    private Dictionary<PayoutType, Action<Product>> _purchaseActions = new();

    private void Start()
    {
        _purchaseActions.Add(PayoutType.Currency, OnCurrencyBuy);
        _purchaseActions.Add(PayoutType.Other, OnOtherBuy);
    }
    public void OnPurchaseComplete(Product product)
    {
        PayoutType type = product.definition.payout.type;
        if (_purchaseActions.ContainsKey(type))
        {
            _purchaseActions[type]?.Invoke(product);
        }
    }
    private void OnCurrencyBuy(Product product)
    {
        GameAnalytics.gameAnalytics.LogEvent("UserBuyCurrency");
        CurrencyBuyEvent?.Invoke((int)product.definition.payout.quantity, product.definition.payout.subtype);
    }
    private void OnOtherBuy(Product product)
    {
        if (string.Equals(product.definition.payout.subtype, "DisableAdvertising"))
        {
            GameAnalytics.gameAnalytics.LogEvent("UserBuy_DisableAdvertising");
            OtherBuyEvent?.Invoke();
        }
    }
}
