using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _sfxSource;
    private AudioSource _musicSource;

    private AudioClip _boomClip;
    private AudioClip _musicClip;
    private AudioClip _hehehehaClip;
    private void Awake()
    {
        _musicSource = gameObject.AddComponent<AudioSource>();
        _musicSource.loop = true;

        _sfxSource = gameObject.AddComponent<AudioSource>();


        _boomClip = Resources.Load<AudioClip>("Audio/VineBoom");
        _hehehehaClip = Resources.Load<AudioClip>("Audio/Heheheha");
        _musicClip = Resources.Load<AudioClip>("Audio/Music");
        
    }
    private void OnEnable()
    {
        BasketLogic.OnGoodThrow += PlayGoodSound;
        BasketLogic.OnGoodThrow += PlayBadSound;
    }

    private void OnDisable()
    {
        BasketLogic.OnGoodThrow -= PlayGoodSound;
        BasketLogic.OnGoodThrow -= PlayBadSound;
    }

    void PlayGoodSound()
    {
        if (_boomClip != null)
        {
            _sfxSource.PlayOneShot(_boomClip);
        }
    }

    void PlayBadSound()
    {
        if (_boomClip != null)
        {
            _sfxSource.PlayOneShot(_hehehehaClip);
        }
    }

    public void StartMusic()
    {
        if (_musicSource.isPlaying) return;

        if (_musicClip != null)
        {
            _musicSource.clip = _musicClip;
            _musicSource.Play();
        }
    }

}
