using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADSR_Point {
	public enum PointEnum {Linear, Curved};

	public float offset; // from 0 to x
	public float intensity; // from 0 to 1
	public PointEnum pointCurve = PointEnum.Linear;

	public ADSR_Point(float _o, float _i){
		offset = _o;
		intensity = _i;
	}
}

[System.Serializable]
public class ADSR_Point_Visualizer {
	public enum PointEnum {Linear, Curved};

	public float offset; // from 0 to x
	public float intensity; // from 0 to 1
	public PointEnum pointCurve = PointEnum.Linear;

	public ADSR_Point_Visualizer(float _o, float _i){
		offset = _o;
		intensity = _i;
	}
}