using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource effectAudio;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip reloadClip;
    [SerializeField] private AudioClip energyClip;
    [SerializeField] private AudioClip zombieDeadClip;
    [SerializeField] private AudioClip healClip;
    [SerializeField] private AudioClip damageMaleClip;

    public void PlayShootSound()
    {
        effectAudio.PlayOneShot(shootClip);
    }
    public void PlayReloadSound()
    {
        effectAudio.PlayOneShot(reloadClip);
    }
    public void PlayEnergySound()
    {
        effectAudio.PlayOneShot(energyClip);
    }

    public void PlayZombieDeadSound()
    {
        effectAudio.PlayOneShot(zombieDeadClip);
    }

    public void PlayHealSound()
    {
        effectAudio.PlayOneShot(healClip);
    }

    public void PlayDamageMaleSound()
    {
        effectAudio.PlayOneShot(damageMaleClip);
    }

}
