using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject bumperVFX;
    public GameObject switchVFX;
    public GameObject switchOffVFX;

    public void PlayBumperVFX(Vector3 spawnPosition)
    {
        GameObject.Instantiate(bumperVFX, spawnPosition, Quaternion.identity);
    }

    public void PlaySwitchVFX(Vector3 spawnPosition, bool active)
    {
        GameObject.Instantiate(active ? switchVFX : switchOffVFX, spawnPosition, Quaternion.identity);
    }
}
