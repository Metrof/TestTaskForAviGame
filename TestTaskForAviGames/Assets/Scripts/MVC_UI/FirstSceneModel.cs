using System;
using UnityEngine;

public class FirstSceneModel 
{
    public Action<int> OnChangeCoins;
    public Action<bool> OnAdvertisingStateChange;

    private int _coins;
    private bool _isAdvertisingDisable;

    protected int Coins
    {
        get { return _coins; }
        set
        {
            _coins = value;
            if (_coins < 0) _coins = 0;
            OnChangeCoins?.Invoke(_coins);
        }
    }
    public void Initialization()
    {
        Coins = PlayerPrefs.GetInt("coins");

        int ad = PlayerPrefs.GetInt("advertising");
        if (ad == 1)
        {
            _isAdvertisingDisable = true;
            OnAdvertisingStateChange?.Invoke(!_isAdvertisingDisable);
        }
    }
    public void ChangeCoinsModel(int coins)
    {
        Coins += coins;
        PlayerPrefs.SetInt("coins", Coins);
    }
    public void ChangeAdvertisingState(bool isAdvertisingDisable)
    {
        _isAdvertisingDisable = isAdvertisingDisable;
        OnAdvertisingStateChange?.Invoke(!_isAdvertisingDisable);
        PlayerPrefs.SetInt("advertising", 1);
    }
}
