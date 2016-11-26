using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class SpaceWalker : MonoBehaviour {

    [SerializeField]
    GameObject cockpit;

    [SerializeField]
    GameObject ship;

    [SerializeField]
    private VRCameraFade m_VRCameraFade;

    [SerializeField]
    private SelectionRadial CockpitRadial;

    [SerializeField]
    private SelectionRadial ShipRadial;

    bool isInside = true;

    private void OnEnable()
    {
        CockpitRadial.OnSelectionComplete += OnRadialCompleted;
        ShipRadial.OnSelectionComplete += OnRadialCompleted;
    }


    private void OnDisable()
    {
        CockpitRadial.OnSelectionComplete -= OnRadialCompleted;
        ShipRadial.OnSelectionComplete -= OnRadialCompleted;
    }

    // Use this for initialization
    void Start ()
    {
        isInside = true;
        cockpit.SetActive(true);
        ship.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {}

    public void OnRadialCompleted()
    {
        StartCoroutine(Shift());
    }

    private IEnumerator Shift()
    {
        yield return StartCoroutine(m_VRCameraFade.BeginFadeOut(true));
        if (isInside)
        {
            cockpit.SetActive(false);
            ship.SetActive(true);
        }
        else
        {
            cockpit.SetActive(true);
            ship.SetActive(false);
        }

        CockpitRadial.Show();
        ShipRadial.Show();

        isInside = !isInside;
        yield return StartCoroutine(m_VRCameraFade.BeginFadeIn(true));
    }
}
