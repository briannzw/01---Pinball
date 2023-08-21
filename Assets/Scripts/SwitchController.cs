using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }

    public Material onMaterial;
    public Material offMaterial;
    public int blinkTimes = 2;

    public AudioManager audioManager;
    public VFXManager vfxManager;

    public ScoreManager scoreManager;
    public int score = 5;

    private Renderer renderer;

    private SwitchState state;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = offMaterial;

        Set(false);
        StartCoroutine(BlinkTimerStart(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Toggle();
        }
    }

    private void Set(bool active)
    {
        renderer.material = active ? onMaterial : offMaterial;
        state = active ? SwitchState.On : SwitchState.Off;
        if (active)
            StopAllCoroutines();
        else
            StartCoroutine(BlinkTimerStart(5));
    }

    private void Toggle()
    {
        Set(state != SwitchState.On);
        scoreManager.AddScore(score);

        // SFX
        audioManager.PlaySwitchSFX(transform.position, state == SwitchState.On);

        // VFX
        vfxManager.PlaySwitchVFX(transform.position, state == SwitchState.On);
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;

        for (int i = 0; i < times; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.Off;

        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(blinkTimes));
    }
}
