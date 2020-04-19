using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcaveObjectController : MonoBehaviour
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
    }
    private void Update()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        if (gm.isPlaying) rotation = new Vector3(-Input.GetAxis("Vertical") * rotationspeed * Time.deltaTime, 0, Input.GetAxis("Horizontal") * rotationspeed * Time.deltaTime);
        else rotation = Vector3.zero;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (eggIn)
        {
            transform.Rotate(rotation, Space.World);
        }
        
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
