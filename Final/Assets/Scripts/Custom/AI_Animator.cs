using UnityEngine;
using UnityEngine.UI;

public class AI_Animator : MonoBehaviour
{

    public AudioSource audioSource;
    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;
    public float effectBooster = 25.0f;

    [SerializeField]
    private Image CenterDot;
    [SerializeField]
    private Image[] RightDots;
    [SerializeField]
    private Image[] LeftDots;

    private float currentUpdateTime = 0f;

    private float clipLoudness;
    private float[] clipSampleData;



    // Use this for initialization
    void Start()
    {

        if (!audioSource)
        {
            Debug.LogError(GetType() + ".Start: there was no audioSource set.");
        }
        clipSampleData = new float[sampleDataLength];

        SetAudioVisuals(0.0f);

    }

    void SetAudioVisuals(float audioLevel)
    {
        float increment = 1.0f - (audioLevel* effectBooster);
        float value = 1.0f - increment;

        Color centerAlpha = CenterDot.color;
        centerAlpha.a = value;
        CenterDot.color = centerAlpha;

        foreach (Image dot in RightDots)
        {
            value = Mathf.Max(value - increment, 0.0f);
            Color dAlpha = dot.color;
            dAlpha.a = value;
            dot.color = dAlpha;
        }

        value = 1.0f - increment;
        foreach (Image dot in LeftDots)
        {
            value = Mathf.Max(value - increment, 0.0f);
            Color dAlpha = dot.color;
            dAlpha.a = value;
            dot.color = dAlpha;
        }

    }

    // Update is called once per frame
    void Update()
    {
        currentUpdateTime += Time.deltaTime;

        if (!audioSource.isPlaying)
        {
            return;
        }


        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); 
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength;

            SetAudioVisuals(clipLoudness);
        }

    }

}