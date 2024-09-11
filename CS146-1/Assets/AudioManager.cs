using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource shoot_sound;
    [SerializeField] AudioSource explosion_sound;
    [SerializeField] AudioSource background_sound;
    [SerializeField] AudioSource click_sound;
    [SerializeField] AudioSource game_over_sound;
    public void PlayShootSound()
    {
        shoot_sound.Play();
    }

    public void PlayExplosionSound()
    {
        explosion_sound.Play();
    }

    public void PlayBackgroundSound()
    {
        background_sound.Play();
    }

    public void PlayClickSound()
    {
        click_sound.Play();
    }

    public void PlayGameOverSound()
    {
        game_over_sound.Play();
    }

    public void StopBackgroundSound()
    {
        background_sound.Stop();
    }
}
