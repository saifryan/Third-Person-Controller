using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class PopupController : MonoBehaviour
{
    static PopupController Instance;
    [Header("----- Panel Data -----")]
    [SerializeField] Canvas MainCanvas;
    [SerializeField] RectTransform SpawnPanelParent;
    [Header("---- Fade Out Panel -----")]
    [SerializeField] GameObject CanvasObject;
    [SerializeField] UnityEngine.UI.Image PanelImage;

    public static bool AnyPanelOpen = false;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        AnyPanelOpen = false;
        FadeInPanelOpen();
    }

    #region BG Panel Function
    void SetLayerValue(int layerid)
    {
        MainCanvas.sortingOrder = layerid;
    }
    #endregion

    #region Alert Popup
    public static void AlertPanelOpen(string title, string description, int layerid, bool closebuttonstaus)
    {
        Instance.SetLayerValue(layerid);
        Instance.OpenPopup<AlertPopup>("Popups/AlertPopup", popup =>
        {
            popup.SetData(title, description, closebuttonstaus);
        });
        AnyPanelOpen = true;
    }
    #endregion

    #region Load Next Scene
    static string TempSceneName;
    public static void LoadScene(string scenename)
    {
        TempSceneName = scenename;
        FadeOutPanelOpen(Instance.LoadSceneCallBack);
    }

    void LoadSceneCallBack()
    {
        SceneManager.LoadScene(TempSceneName);
    }
    #endregion

    #region Open Popup
    public void OpenPopup<T>(string popupName, System.Action<T> onOpened = null) where T : Popup
    {
        StartCoroutine(OpenPopupAsync(popupName, onOpened));
    }

    protected IEnumerator OpenPopupAsync<T>(string popupName, System.Action<T> onOpened) where T : Popup
    {
        var request = Resources.LoadAsync<GameObject>(popupName);
        while (!request.isDone)
        {
            yield return null;
        }

        var popup = Instantiate(request.asset) as GameObject;
        Assert.IsNotNull((popup));
        popup.transform.SetParent(SpawnPanelParent, false);
        //popup.MainCanvasGroup.alpha = 0f;
        //popup.MainCanvasGroup.DOFade(1, 0.25f);
        if (onOpened != null)
        {
            onOpened(popup.GetComponent<T>());
        }
    }
    #endregion

    #region Fade Out Panel Open
    // Fade Out Panel Open
    public static void FadeOutPanelOpen(System.Action funRun)
    {
        Instance.CanvasObject.SetActive(true);
        Instance.StartCoroutine(AnimationEffect.FadeImage(Instance.PanelImage, 0f, 1f, 0f, 0.5f, () =>
        {
            funRun.Invoke();
        }));
    }

    // Fade In Panel Open
    public static void FadeInPanelOpen()
    {
        Instance.CanvasObject.SetActive(true);
        Instance.StartCoroutine(AnimationEffect.FadeImage(Instance.PanelImage, 1f, 0f, 0f, 0.5f, () =>
        {
            Instance.CanvasObject.SetActive(false);
        }));
    }
    #endregion
}