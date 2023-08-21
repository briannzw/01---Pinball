using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGBColor : MonoBehaviour
{
    public float changeColorSpeed;
    public List<Color> colors;

    private Material material;
    private int colorIndex = 0;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        StartCoroutine(ChangeColor(colors[0], colors[1]));
    }

    private IEnumerator ChangeColor(Color startColor, Color endColor)
    {
        float tick = 0f;
        while (material.color != endColor)
        {
            tick += Time.deltaTime * changeColorSpeed;
            material.color = Color.Lerp(startColor, endColor, tick);
            yield return null;
        }

        colorIndex++;
        colorIndex %= colors.Count;
        StartCoroutine(ChangeColor(colors[colorIndex], colors[(colorIndex + 1) % colors.Count]));
    }
}
