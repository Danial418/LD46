using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongObjectController : MonoBehaviour
{
    public float rotationspeed;

    public bool eggIn;
    private Rigidbody rb;
    private Vector3 rotation;
    private GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
    }
    private void Update()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        if (gm.isPlaying) rotation = new Vector3(-Input.GetAxis("Vertical") * rotationspeed * Time.deltaTime, -Input.GetAxis("Horizontal") * rotationspeed * Time.deltaTime, 0);
        else rotation = Vector3.zero;
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
        if (other.tag == "Player")
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
