using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingGlow : MonoBehaviour
{
    //TODO Determine why glow is so intense 
    //TODO Use existing material color
    //TODO Add option for random seed to be used instead of the timer. 
    //TODO add option to use sine wage instead
    //TODO add option to flicker like a dying light. 
    public Renderer RendererSource;
    public Material material;
    public Color myColor = new Color(0,222,18);
    public float glowMaximum = 1f;
    public float timeFactor = 1;
    public float glowMinimum = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        RendererSource = GetComponent<Renderer>();
        material = RendererSource.material;
        material.SetColor("_EmissionColor", myColor);
    }

    // Update is called once per frame
    void Update()
    {
        float upperBound = glowMaximum - glowMinimum;
        material.SetColor("_EmissionColor", myColor * (glowMinimum + Mathf.PingPong((Time.time * (upperBound)) * timeFactor, upperBound)));
    }
}
