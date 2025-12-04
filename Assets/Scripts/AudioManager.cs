using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        BasketLogic.OnGoodThrow += PlayGoodSound;
    }

    private void OnDisable()
    {
        BasketLogic.OnGoodThrow -= PlayGoodSound;
    }

    void PlayGoodSound()
    {
        Debug.Log("MOAI SOUND");
        audioSource.clip = Resources.Load<AudioClip>("Audio/VineBoom");
        audioSource.Play();
    }
}
