/*
 * Version par FSM
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADSR_v1 : MonoBehaviour {

	public enum ADSRenum {attack, delay, sustain, release};

	public AnimationCurve attack;
	public AnimationCurve delay;
	public AnimationCurve sustain;
	public AnimationCurve release;

	public float speed;

	public ADSRenum adsr = ADSRenum.attack;

	[Range(0f, 1f)]
	public float slider;

	void Update()
	{
		float h = Input.GetAxisRaw ("Horizontal");

		if (h != 0f) {
			slider += Time.deltaTime;
			slider = Mathf.Clamp01 (slider);
			if (adsr == ADSRenum.attack) {
				speed = attack.Evaluate (slider);
				if (slider >= 1f) {
					adsr = ADSRenum.delay;
					slider = 0f;
				}
			}

			if (adsr == ADSRenum.delay) {
				speed = delay.Evaluate (slider);
				if (slider >= 1f) {
					adsr = ADSRenum.sustain;
					slider = 0f;
				}
			} 

			if (adsr == ADSRenum.sustain) {
				speed = sustain.Evaluate (slider);
				if (slider >= 1f) {
					adsr = ADSRenum.release;
					slider = 0f;
				}
			} 

			if (adsr == ADSRenum.release) {
				speed = release.Evaluate (slider);
			}
		} else {
			slider = Mathf.MoveTowards (slider, 0f, Time.deltaTime);
		}

		transform.Translate (Vector3.right * h * speed * Time.deltaTime);
	}
}