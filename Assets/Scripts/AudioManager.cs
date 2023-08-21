using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    public GameObject bumperSFX;
    public GameObject switchSFX;
    public GameObject switchOffSFX;

    private void Start()
    {
        PlayBGM();
    }

    private void PlayBGM()
    {
        bgmAudioSource.Play();
    }

    public void PlayBumperSFX(Vector3 spawnPosition)
    {
        GameObject.Instantiate(bumperSFX, spawnPosition, Quaternion.identity);
    }

    public void PlaySwitchSFX(Vector3 spawnPosition, bool active)
    {
        GameObject.Instantiate(active ? switchSFX : switchOffSFX, spawnPosition, Quaternion.identity);
    }
}
