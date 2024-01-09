using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FirstSceneCanvasElement : MonoBehaviour 
{
    [SerializeField] private Button _disableAdvertisingButton;
    [SerializeField] private Button _switchSceneButton;
    [SerializeField] private TextMeshProUGUI _coinsText;

    public Button DisableAdvertisingButton { get { return _disableAdvertisingButton; } }
    public Button SwitchSceneButton { get { return _switchSceneButton; } }
    public TextMeshProUGUI CoinsText { get { return _coinsText; } }
}
