using UnityEngine;
using VRStandardAssets.Utils;
using UnityEngine.UI;
using System.Collections;

public class InfoItem : MonoBehaviour {


    [SerializeField]
    private SelectionRadial radial;

    [SerializeField]
    private Image icon;

    [SerializeField]
    private Image info;

    public AudioClip clip;

    private bool playingAudio=false;

    public delegate void AudioCallback();

    // Use this for initialization
    void Start () 
    {
        Color alphaInfo = info.color;
        alphaInfo.a = 0.0f;
        info.color = alphaInfo;

        InfoManager.AddInfoItem(this);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnEnable()
    {
        radial.OnSelectionComplete += OnRadialCompleted;
    }


    private void OnDisable()
    {
        radial.OnSelectionComplete -= OnRadialCompleted;
    }

    public void HideOrActivate()
    {
        radial.Hide();
        if (playingAudio)
        {
            Color alphaIcon = icon.color;
            alphaIcon.a = 0.0f;
            icon.color = alphaIcon;

            Color alphaInfo = info.color;
            alphaInfo.a = 1.0f;
            info.color = alphaInfo;
        }
        else
        {
            Color alphaIcon = icon.color;
            alphaIcon.a = 0.5f;
            icon.color = alphaIcon;
        }
            
    }

    public void ShowIcon()
    {
        playingAudio = false;

        Color alpha = icon.color;
        alpha.a = 1.0f;
        icon.color = alpha;

        Color alphaInfo = info.color;
        alphaInfo.a = 0.0f;
        info.color = alphaInfo;

        radial.Show();
    }

    public void OnRadialCompleted()
    {
        playingAudio = true;
        InfoManager.PlayBackItem(this);
        StartCoroutine(WaitTillAudioDone(clip.length));
    }

    private IEnumerator WaitTillAudioDone(float time)
    {
        yield return new WaitForSeconds(time);
        playingAudio = false;
        InfoManager.EnableAllItems();
    }
}
