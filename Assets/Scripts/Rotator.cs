using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float startTime = 2f;
    public float rotationSpeed = 100f;

    private bool isTurning;
    private float totalTraveled;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("RotateObject", startTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTurning)
        {
            totalTraveled += rotationSpeed * Time.deltaTime;
            transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
            rotationSpeed *= 1.001f;
        }
        if (totalTraveled < -180) isTurning = false;
        
    }
    void RotateObject()
    {
        isTurning = true;
    }
}
