

using UnityEngine;
using System.Collections;

public class RendererFade : MonoBehaviour
{
    public float fadeTime;
    private Renderer[] renderers;
    private float currentTime;
    private bool fadeComplete = false;
    private bool isActive = false;

    // Use this for initialization
    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    public void Fade()
    {
        isActive = true;
    }

    public bool IsComplete()
    {
        return fadeComplete;
    }

    void Update()
    {
        if (isActive)
        {
            currentTime += Time.deltaTime;

            if (currentTime < fadeTime)
            {
                foreach (Renderer asteroidFace in renderers)
                {
                    Color previousColor = asteroidFace.material.color;
                    float time = currentTime / fadeTime;
                    float alpha = Mathf.Lerp((float)1.0, (float)0.0, time);
                    Color newColor = new Color(previousColor.r, previousColor.g, previousColor.b, alpha);
                    asteroidFace.material.color = newColor;
                }
            }
            else
            {
                foreach (Renderer asteroidFace in renderers)
                {
                    asteroidFace.enabled = false;
                }
                isActive = false;
                fadeComplete = true;
            }
        }
    }
}
