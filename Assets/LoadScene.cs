using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    void Start()
    {
        if ((GameDataManager.Instance.playerData.time > 0))
        {
            StartCoroutine(IEStart());
        }
    }

    IEnumerator IEStart()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("App");
    }

    /// <summary>
    /// 
    /// </summary>
    public void Load()
    {
        StartCoroutine(IEStart());
    }
}