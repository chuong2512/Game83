using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateApp : MonoBehaviour
{/// <summary>
    /// ////////////////////////////////////////////
    /// </summary>
    public void OnClickPrivacy()
    {
        /////////////////////////////////////////////////////////////////////////
        Application.OpenURL("");
    }
  
    public void OnClickRateUs()
    {
        /////////////////////////////////////////////////////////////////////////
        Application.OpenURL("market://details?id=" + Application.identifier);
    }
}