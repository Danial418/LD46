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
    private Rigidbody rb;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.isPlaying || gm.hasFinished)
        {
            rb.isKinematic = false;
        }
        else rb.isKinematic = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.impulse.magnitude > breakForce || collision.gameObject.tag == "Ground")
        {
            eggCells = Instantiate(eggCellsPrefab, transform.position, transform.rotation);
            rbs = eggCells.GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rbs)
            {
                rb.velocity = transform.GetComponent<Rigidbody>().velocity;
            }
            gameObject.SetActive(false);
            Invoke("Restart", 2f);

        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
