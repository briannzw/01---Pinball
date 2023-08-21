using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public float multiplier = 1;
    public Color color;
    public int score = 10;

    public AudioManager audioManager;
    public VFXManager vfxManager;
    public ScoreManager scoreManager;

    private Renderer renderer;
    private Animator animator;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        renderer.material.color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            collision.collider.GetComponent<Rigidbody>().velocity *= multiplier;

            animator.SetTrigger("hit");
            StartCoroutine(ChangeColor());

            // SFX
            audioManager.PlayBumperSFX(collision.transform.position);

            // VFX
            vfxManager.PlayBumperVFX(collision.transform.position);

            // Score
            scoreManager.AddScore(score);
        }
    }

    private IEnumerator ChangeColor()
    {
        renderer.material.color = Color.white;
        yield return new WaitForSeconds(.1f);
        renderer.material.color = color;
    }
}
