using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ComingSoonPanel : MonoBehaviour
{
   public void SupportDevelopers()
   {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo");
        }
    }
    private void Start()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3819611", false);
        }

    }

}
