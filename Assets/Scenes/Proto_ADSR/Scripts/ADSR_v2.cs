/*
 * 	version inspirée de FL Studio
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADSR_v2 : MonoBehaviour {

	public List<ADSR_Point> curvePoints = new List<ADSR_Point> ();

	public ADSR_Point decayPoint;
	public ADSR_Point sustainPoint;

	public ADSR_Point_Visualizer vDecayPoint;
	public ADSR_Point_Visualizer vSustainPoint;

	public float speed;

	void Awake() {
		// if no new point, create a defaut one with standard values (= 1)
		if (curvePoints.Count == 0) {
			curvePoints.Add (new ADSR_Point (0f, 1f));
		}

		// by default, decayPoint is the default Point
		if (decayPoint == null)
			decayPoint = curvePoints [0];

		// by default, sustainPoint is the Point you created
		// exceptif you didn't create a Point, so it's the default Point
		if (sustainPoint == null) {
			if (curvePoints.Count == 1){
				sustainPoint = curvePoints [0];
			}
			else
				sustainPoint = new ADSR_Point(curvePoints [curvePoints.Count].offset, curvePoints [curvePoints.Count].intensity);
		}

		vDecayPoint.intensity = decayPoint.intensity;
		vSustainPoint.intensity = sustainPoint.intensity;
	}

	void Update () {
		float h = Input.GetAxisRaw ("Horizontal");

		transform.Translate (Vector3.right * h * speed * Time.deltaTime);
	}
}
