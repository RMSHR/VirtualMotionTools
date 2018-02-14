using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ADSR_WaveStruct
{
    public float intensity;
    public float delay;
}

public class ADSR_WaveShape
{
    public ADSR_WaveStruct attack;
    public ADSR_WaveStruct delay;
    public ADSR_WaveStruct sustain;
    public ADSR_WaveStruct release;

    public float intensity;
    public float time;
    public bool isReleasing = false;

    public ADSR_WaveShape()
    {

    }
}