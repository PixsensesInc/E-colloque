using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;

public class LoadLevelOnKey : MonoBehaviour {

    [SerializeField]
    private VRCameraFade VRCameraFade;
    [SerializeField]
    private string SceneToLoad;
    [SerializeField]
    private string keyToPress;

    private Coroutine routine;

    void  Update()
    {
        if (Input.GetButtonDown(keyToPress) && routine == null)
            routine = StartCoroutine(FadeToScene());
    }

    private IEnumerator FadeToScene()
    {
        yield return StartCoroutine(VRCameraFade.BeginFadeOut(true));
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
    }
}
