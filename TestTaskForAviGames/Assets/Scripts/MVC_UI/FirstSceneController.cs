using UnityEngine;

public class FirstSceneController : MonoBehaviour
{
    [SerializeField] private FirstSceneCanvasElement _firstSceneCanvasElement;

    private Purchaser _purchaser;
    private FirstSceneView _view;
    private FirstSceneModel _model;

    private void Awake()
    {
        _purchaser = FindObjectOfType<Purchaser>();
    }
    private void Start()
    {
        _model = new FirstSceneModel();
        _view = new FirstSceneView(_firstSceneCanvasElement);

        _model.OnChangeCoins += _view.ChangeCoinsTextView;
        _model.OnAdvertisingStateChange += _view.SwitchAdvertisingButtonEnabled;
        _model.Initialization();
    }
    private void OnEnable()
    {
        _purchaser.CurrencyBuyEvent += AddCurrency;
        _purchaser.OtherBuyEvent += DisableAdvertisingButton;
    }
    private void OnDisable()
    {
        _purchaser.CurrencyBuyEvent -= AddCurrency;
        _purchaser.OtherBuyEvent -= DisableAdvertisingButton;
    }
    public void AddCurrency(int count, string currency)
    {
        if (string.Equals(currency, "Coins"))
        {
            _model.ChangeCoinsModel(count);
        }
    }
    public void DisableAdvertisingButton()
    {
        _model.ChangeAdvertisingState(true);
    }
}
