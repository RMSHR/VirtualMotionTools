using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInputs : MonoBehaviour {

    protected Vector3 inputs;
	
	void Update () {
        inputs = GetInputs();
    }

    void FixedUpdate()
    {
        transform.Translate(inputs * GetVelocity());
    }

    protected virtual float GetVelocity()
    {
        return Time.deltaTime;
    }

    protected Vector3 GetInputs()
    {
        Vector3 _i = Vector3.zero;
        _i.x = Input.GetAxisRaw("Horizontal");
        _i.y = Input.GetAxisRaw("Vertical");
        return _i; 
    }
}
