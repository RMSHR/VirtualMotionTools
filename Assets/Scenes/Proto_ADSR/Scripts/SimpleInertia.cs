using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInertia : MonoBehaviour {

    public Vector3 speed;
    public float accelerationMax;

    public Vector3 inputs;
    public Vector3 acceleration;

    void Update()
    {
        inputs = GetInputs();
    }

    void FixedUpdate()
    {
        transform.Translate(GetAcceleration());
    }

    protected Vector3 GetInputs()
    {
        Vector3 _i = Vector3.zero;
        _i.x = Input.GetAxisRaw("Horizontal");
        _i.y = Input.GetAxisRaw("Vertical");
        return _i;
    }

    Vector3 GetVelocity()
    {
        Vector3 v = Vector3.zero;
        v.x = inputs.x;
        v.y = inputs.y;
        return v;
    }

    Vector3 GetAcceleration()
    {
        if (inputs.x != 0f)
            acceleration.x += Time.deltaTime * inputs.x;
        else
            acceleration.x = Mathf.MoveTowards(acceleration.x, 0f, Time.deltaTime);

        acceleration = new Vector3(
            Mathf.Clamp(acceleration.x, 0f, accelerationMax),
            Mathf.Clamp(acceleration.y, 0f, accelerationMax),
            0f);

        return acceleration;
    }
}
