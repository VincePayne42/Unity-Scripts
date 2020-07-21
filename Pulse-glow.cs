using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingGlow : MonoBehaviour
{
    //TODO Determine why glow is so intense, or values are so skewed
    //TODO Use existing material color
    //TODO Add option for random seed to be used instead of the timer. allow seed to be changed to sync things up with random being 0
    //TODO add option to use sine wage instead
    //TODO add option to flicker like a dying light. 
    //TODO add option to change color of base material
    public Renderer RendererSource;
    public Material material;
    // public Color myColor = new Color(0,222,18);
    public Color myColor = new Color(0,5,191);

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
        float upper = glowMaximum / 1000;
        float lower = glowMinimum / 1000;

        //Learn to use the debug tools and debug prints to figure out why I have to to do this. 

        float upperBound = upper - lower;
        material.SetColor("_EmissionColor", myColor * (lower + Mathf.PingPong((Time.time * (upperBound)) * timeFactor, upperBound)));
    }
}
