using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADSR_v3 : MonoBehaviour {

    [Header("Attack")]
    public float attack_intensity;
    public float attack_delay;
    [Header("Delay")]
    public float delay_intensity;
    public float delay_delay;
    [Header("Sustain")]
    public float sustain_intensity;
    public float sustain_delay;
    [Header("Release")]
    public float release_intensity;
    public float release_delay;

    [Header("Entity Motion")]
    public float speed = 1f;

    private ADSR_WaveShape motionBehaviour;

    void Awake()
    {
        motionBehaviour = new ADSR_WaveShape();

        motionBehaviour.attack.intensity = attack_intensity;
        motionBehaviour.attack.delay = attack_delay;

        motionBehaviour.delay.intensity = delay_intensity;
        motionBehaviour.delay.delay = delay_delay;

        motionBehaviour.sustain.intensity = sustain_intensity;
        motionBehaviour.sustain.delay = sustain_delay;

        motionBehaviour.release.intensity = release_intensity;
        motionBehaviour.release.delay = release_delay;
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if(h != 0f) // Input
        {
            if (motionBehaviour.isReleasing)
            {
                motionBehaviour.isReleasing = false;
                motionBehaviour.time = 0f;
            }
                
            motionBehaviour.time += Time.deltaTime;

            if(motionBehaviour.time < motionBehaviour.attack.delay)
            {
                motionBehaviour.intensity = Mathf.MoveTowards(motionBehaviour.intensity, motionBehaviour.attack.intensity, motionBehaviour.time);
                //motionBehaviour.intensity = Mathf.Clamp(motionBehaviour.intensity, 0f, motionBehaviour.attack.intensity); // security
            }

            if(motionBehaviour.time >= motionBehaviour.attack.delay && motionBehaviour.time < motionBehaviour.delay.delay)
            {
                motionBehaviour.intensity = Mathf.MoveTowards(motionBehaviour.intensity, motionBehaviour.delay.intensity, motionBehaviour.time + motionBehaviour.attack.intensity);
            }

            if(motionBehaviour.time >= motionBehaviour.delay.delay)
            {
                motionBehaviour.intensity = motionBehaviour.sustain.intensity;
            }
        }
        else // Release
        {
            if(!motionBehaviour.isReleasing)
            {
                motionBehaviour.time = 0f;
                motionBehaviour.isReleasing = true;
            }

            motionBehaviour.time += Time.deltaTime;

            if (motionBehaviour.time < motionBehaviour.release.delay)
            {
                motionBehaviour.intensity = Mathf.MoveTowards(motionBehaviour.intensity, motionBehaviour.release.intensity, motionBehaviour.time);
                motionBehaviour.intensity = Mathf.Clamp01(motionBehaviour.intensity);
            }
        }

        transform.Translate(Vector3.right * Time.deltaTime * motionBehaviour.intensity * speed);
    }
}