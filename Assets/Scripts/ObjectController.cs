using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float rotationspeed;

    public bool eggIn;
    private Rigidbody rb;
    private Vector3 rotation;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rotation = new Vector3(-Input.GetAxis("Vertical") * rotationspeed * Time.deltaTime, 0, Input.GetAxis("Horizontal") * rotationspeed * Time.deltaTime);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (eggIn)
        {
            rb.AddTorque(rotation, ForceMode.VelocityChange);
        }
        //transform.Rotate(Input.GetAxis("Vertical") * rotationspeed * Time.deltaTime, 0, Input.GetAxis("Horizontal") * rotationspeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        eggIn = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            eggIn = false;

        }

    }
}
