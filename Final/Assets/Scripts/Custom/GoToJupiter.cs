using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;

public class GoToJupiter : MonoBehaviour {

    [SerializeField]
    private GameObject Loaders;
    [SerializeField]
    private Animation FinalAnim;
    [SerializeField]
    private SelectionRadial Radial;
    [SerializeField]
    private VRCameraFade m_VRCameraFade;
    [SerializeField]
    private string m_SceneToLoad;

    private void OnEnable()
    {
        Radial.OnSelectionComplete += OnRadialCompleted;
    }
    private void OnDisable()
    {
        Radial.OnSelectionComplete -= OnRadialCompleted;
    }

    public void OnRadialCompleted()
    {
        StartCoroutine(travel());
    }

    private IEnumerator travel()
    {
        FinalAnim.Play();
        Loaders.SetActive(false);
        yield return new WaitForSeconds(FinalAnim.clip.length);
        Loaders.SetActive(true);
        yield return StartCoroutine(m_VRCameraFade.BeginFadeOut(true));
        SceneManager.LoadScene(m_SceneToLoad, LoadSceneMode.Single);
    }
}
