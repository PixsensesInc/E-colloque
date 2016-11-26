using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class GoToMars : MonoBehaviour {

    [SerializeField]
    private GameObject Loaders;
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Animation GoToMarsAnim;
    [SerializeField]
    private SelectionRadial Radial;

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
        animator.Play("Deplacement_Mars");
        //GoToMarsAnim.Play();
        Loaders.SetActive(false);
        yield return new WaitForSeconds(GoToMarsAnim.clip.length);
        Loaders.SetActive(true);
    }
}
