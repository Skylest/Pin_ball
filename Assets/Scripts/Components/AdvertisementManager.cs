using UnityEngine;
using UnityEngine.Advertisements;

/// <summary>
/// Класс реализовывающий управление рекламой
/// </summary>
public class AdvertisementManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    /// <summary>
    /// Game Id
    /// </summary>
    private readonly string _adUnitId = "4593761";

    /// <summary>
    /// Id типа рекламы
    /// </summary>
    private readonly string _androidAdUnitId = "Interstitial_Android";
    
    /// <summary>
    /// Количество рестартов
    /// </summary>
    private int restartCnt = 0;

    /// <summary>
    /// Готовность рекламы
    /// </summary>
    private bool isLoaded = false;

    /// <summary>
    /// Экземпляр AdvertisementManager
    /// </summary>
    private static AdvertisementManager instance;

    /// <summary>
    /// Получение единственного экземпляра AdvertisementManager
    /// </summary>
    public static AdvertisementManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        // Проверяем, существует ли уже экземпляр AdvertisementManager
        if (instance != null && instance != this)
        {
            // Если экземпляр уже существует и это не текущий объект, уничтожаем его
            Destroy(gameObject);
            return;
        }

        // Сохраняем текущий экземпляр AdvertisementManager
        instance = this;

        // Делаем этот объект неуничтожаемым при загрузке новых сцен
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {       
        if (Advertisement.isSupported)
        {
            restartCnt = 0;
            Advertisement.Initialize(_adUnitId, false, this);            
        }
    }

    /// <summary>
    /// Проверка условий показа рекламы при рестарте
    /// </summary>
    public  void CheckRestarts()
    {
        if (restartCnt > 5 && isLoaded)
        {
            Advertisement.Show(_androidAdUnitId, this);
            restartCnt = 0;
        }
        else        
            restartCnt++;
        
    }

    /// <summary>
    /// Проверка условий показа рекламы при возврате в меню
    /// </summary>
    public void CheckBackToMenu()
    {
        if (restartCnt > 2 && isLoaded)
        {
            Advertisement.Show(_androidAdUnitId, this);
            restartCnt = 0;
        }
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
