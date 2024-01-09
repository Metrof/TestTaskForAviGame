using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Analytics;

public class SwitchSceneButtonObject : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        GameAnalytics.gameAnalytics.LogEvent("Level1Visit");
        Addressables.LoadSceneAsync(AddressablesConstants.FirstSceneName, LoadSceneMode.Single);
    }
}
