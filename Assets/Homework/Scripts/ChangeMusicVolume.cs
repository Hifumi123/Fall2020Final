using UnityEngine;
using UnityEngine.UI;

public class ChangeMusicVolume : MonoBehaviour
{
    public AudioSource audioSource;

    public Slider slider;

    void Start()
    {
        slider.value = audioSource.volume;
    }

    void Update()
    {
        
    }

    public void ChangeVolume()
    {
        audioSource.volume = slider.value;
    }
}
