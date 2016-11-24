using UnityEngine;
using VRStandardAssets.Utils;
using System.Collections;
using UnityEngine.SceneManagement;

public class Start_SpaceWalk : MonoBehaviour {

    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    [SerializeField] private VRCameraFade m_VRCameraFade;

    [SerializeField] private float m_TimeToActivate;
    [SerializeField] private string m_SceneToLoad;



    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
        m_InteractiveItem.OnClick += HandleClick;
        m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
    }


    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
        m_InteractiveItem.OnClick -= HandleClick;
        m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
    }

    private float timer = 0.0f;
    private bool isBeingLookedAt = false;
    private bool loadingScene = false;

    void Start()
    {
        timer = 0.0f;
        isBeingLookedAt = false;
        loadingScene = false;
    }

    void Update()
    {
        if (isBeingLookedAt && !loadingScene)
        {
            timer += Time.deltaTime;

            if (timer >= m_TimeToActivate)
            {
                loadingScene = true;
                StartCoroutine(FadeToScene());
            }
        }
    }

    //Handle the Over event
    private void HandleOver()
    {
        isBeingLookedAt = true;
    }


    //Handle the Out event
    private void HandleOut()
    {
        isBeingLookedAt = false;
        timer = 0.0f;
    }

    private IEnumerator FadeToScene()
    {
        yield return StartCoroutine(m_VRCameraFade.BeginFadeOut(true));
        SceneManager.LoadScene(m_SceneToLoad, LoadSceneMode.Single);
        loadingScene = false;
    }


    //Handle the Click event
    private void HandleClick()
    {
        //Debug.Log("Show click state");
    }


    //Handle the DoubleClick event
    private void HandleDoubleClick()
    {
        //Debug.Log("Show double click");
    }
}
