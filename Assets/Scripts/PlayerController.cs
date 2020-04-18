using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject eggCellsPrefab;
    public float breakForce = 10;
    private GameObject eggCells;
    private Rigidbody[] rbs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.impulse.magnitude > breakForce)
        {
            eggCells = Instantiate(eggCellsPrefab, transform.position, transform.rotation);
            rbs = eggCells.GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rbs)
            {
                rb.velocity = transform.GetComponent<Rigidbody>().velocity;
            }
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}
