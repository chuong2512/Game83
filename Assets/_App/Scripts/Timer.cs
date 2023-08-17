using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;


    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        timerIsRunning = false;
    }

    /// <summary>
    /// /
    /// </summary>
    /// <param name="timeToDisplay"></param>
    public void SetTimer(float timeToDisplay)
    {
        /////////////////////////////////////////////////////////////////////////
        AudioManager.Instance.musicSource.Play();
        timeText.gameObject.SetActive(true);
        timerIsRunning = true;
        timeRemaining = timeToDisplay;

        DisplayTime(timeToDisplay);
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float hours = Mathf.FloorToInt(timeToDisplay / 60 / 60);
        float minutes = Mathf.FloorToInt((timeToDisplay - hours * 60 * 60) / 60);
        ///
        float seconds = Mathf.FloorToInt((timeToDisplay - hours * 60 * 60) % 60);
        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    /// <summary>
    /// 
    /// </summary>
    public void StopSOund()
    {
        /////////////////////////////////////////////////////////////////////////
        timeText.gameObject.SetActive(false);
        timeRemaining = 0;
        timerIsRunning = false;
        AudioManager.Instance.musicSource.Stop();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining); /////////////////////////////////////////////////////////////////////////
            }
            else
            {
                AudioManager.Instance.musicSource.Stop();
                timeText.gameObject.SetActive(false);
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
}