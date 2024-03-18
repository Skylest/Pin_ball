using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    private readonly string _androidAdUnitId = "Interstitial_Android";
    private int restartCnt = 0;
    private bool isLoaded = false;
    private readonly string _adUnitId = "4593761";


    void Start()
    {       
        if (Advertisement.isSupported)
        {
            restartCnt = 0;
            Advertisement.Initialize(_adUnitId, false, this);
            
        }
    }

    public  void CheckRestarts()
    {

        if (restartCnt > 5 && isLoaded)
        {

            Advertisement.Show(_androidAdUnitId, this);
            restartCnt = 0;
        }
        else
        {
            restartCnt++;
        }
    }
    public  void CheckBackToMenu()
    {
        //TODO
       /* if ((CreatorController.score > 15 || restartCnt > 3) && isLoaded)
        {
            Advertisement.Show(_androidAdUnitId, this);
            restartCnt = 0;
        }*/
    }

    

    public void OnInitializationComplete()
    {
        Advertisement.Load(_androidAdUnitId, this);

    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Initialization Failed");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        isLoaded = true;
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        isLoaded = false;
        Advertisement.Load(_androidAdUnitId, this);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Advertisement.Load(_androidAdUnitId, this);
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Advertisement.Load(_androidAdUnitId, this);
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Advertisement.Load(_androidAdUnitId, this);
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Advertisement.Load(_androidAdUnitId, this);
    }
}
