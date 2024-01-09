using Analytics;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class FirstSceneView 
{
    private FirstSceneCanvasElement _canvas;
    public FirstSceneView(FirstSceneCanvasElement firstSceneCanvasElement)
    {
        _canvas = firstSceneCanvasElement;
        _canvas.SwitchSceneButton.onClick.AddListener(SwitchLvl);
    }
    public void ChangeCoinsTextView(int coins)
    {
        _canvas.CoinsText.text = "Coins: " + coins.ToString();
    }
    public void SwitchAdvertisingButtonEnabled(bool enabled)
    {
        _canvas.DisableAdvertisingButton.interactable = enabled;
    }
    private void SwitchLvl()
    {
        GameAnalytics.gameAnalytics.LogEvent("Level2Visit");
        Addressables.LoadSceneAsync(AddressablesConstants.SecondSceneName, LoadSceneMode.Single);
    }
}
