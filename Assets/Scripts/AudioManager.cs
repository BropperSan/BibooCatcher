using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private AudioSource _sfxSource;
    private AudioSource _musicSource;

    [SerializeField] private Slider slider;

    private AudioClip _boomClip;
    private AudioClip _musicClip;
    private AudioClip _hehehehaClip;
    private AudioClip _moaiClip;
    private void Awake()
    {
        _musicSource = gameObject.AddComponent<AudioSource>();
        _musicSource.loop = true;

        _sfxSource = gameObject.AddComponent<AudioSource>();


        _boomClip = Resources.Load<AudioClip>("Audio/VineBoom");
        _hehehehaClip = Resources.Load<AudioClip>("Audio/Heheheha");
        _moaiClip = Resources.Load<AudioClip>("Audio/MoaiSound");
        _musicClip = Resources.Load<AudioClip>("Audio/Music");
        
    }

    private void Update()
    {
        _musicSource.volume = slider.value;
        _sfxSource.volume = slider.value;
    }
    private void OnEnable()
    {
        GrabReleaseLogic.OnGoodThrow += PlayGoodSound;
        GrabReleaseLogic.OnBadThrow += PlayBadSound;
        Score.OnShowScore += PlayMoai;
    }

    private void OnDisable()
    {
        GrabReleaseLogic.OnGoodThrow -= PlayGoodSound;
        GrabReleaseLogic.OnBadThrow -= PlayBadSound;
        Score.OnShowScore -= PlayMoai;
    }

    void PlayGoodSound(GameObject i)
    {
        if (_boomClip != null)
        {
            _sfxSource.PlayOneShot(_boomClip);
        }
    }

    void PlayBadSound(GameObject i)
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

    public void StopMusic()
    {
        _musicSource.Stop();
        _musicSource.clip = null;
    }

    public void PlayMoai()
    {
        if (_moaiClip != null)
        {
            _sfxSource.PlayOneShot(_moaiClip);
        }
    }
}
