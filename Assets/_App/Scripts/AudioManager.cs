using nhaccc;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-98)]
public class AudioManager : Singleton<AudioManager>
{
    public Image image;
    public Sprite iconOn, iconOff;
    public AudioSource musicSource;
    private SongSO _songSo;


    /// <summary>
    /// ////////////////////////////////////////////
    /// </summary>
    public void TurnMusicOff()
    {
        ChangeVolume(0.0f);
    }

    /// <summary>
    /// ////////////////////////////////////////////
    /// </summary>
    public void TurnMusicOn()
    {
        ChangeVolume(1.0f);
    }

    /// <summary>
    /// ////////////////////////////////////////////
    /// </summary>
    public void PlaySong(int id)
    {
        musicSource.clip = _songSo.GetSongWithID(id).song;
        musicSource.Play();
    }

    /// <summary>
    /// ////////////////////////////////////////////
    /// </summary>
    public Timer timer;

    protected override void Awake()
    {
        base.Awake();

        _songSo = GameDataManager.Instance.songSo;
        musicSource.loop = true;
    }

    /// <summary>
    /// ////////////////////////////////////////////
    /// </summary>
    void Update()
    {
        if (musicSource.isPlaying)
        {
            image.sprite = iconOff;
        }
        else
        {
            image.sprite = iconOn;
        }
    }

    public void Play()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
            timer.StopSOund();
        }
        else
        {
            musicSource.Play();
        }
    }

    public void ChangeVolume(float value)
    {
        musicSource.volume = value;
    }

    public void Stop()
    {
        musicSource.Stop();
    }

    public void Continue()
    {
        musicSource.Play();
    }
}