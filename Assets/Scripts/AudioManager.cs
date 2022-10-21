using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _sfx;

    public void PlayOneShot(AudioClip clip) => _sfx.PlayOneShot(clip);
}
