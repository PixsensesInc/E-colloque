using UnityEngine;
using System.Collections.Generic;

public class InfoManager : MonoBehaviour {

    private static List<InfoItem> infoItems;

    private static AudioSource playback;

    [SerializeField]
    private AudioSource audioSource;

    public static void AddInfoItem(InfoItem item)
    {
        if (infoItems == null)
        {
            infoItems = new List<InfoItem>();
        }

        infoItems.Add(item);
    }

    public static void DisableUnactiveItems()
    {
        foreach (InfoItem item in infoItems)
        {
            item.HideOrActivate();
        }
    }

    public static void EnableAllItems()
    {
        foreach (InfoItem item in infoItems)
        {
            item.ShowIcon();
        }
    }

    public static void PlayBackItem(InfoItem item)
    {
        if (playback != null)
        {
            playback.clip = item.clip;
            playback.Play();
            //playback.PlayOneShot(item.clip);
        }
        DisableUnactiveItems();
    }

    // Use this for initialization
    void Start ()
    {
        if (audioSource != null && playback == null)
        {
            playback = audioSource;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
