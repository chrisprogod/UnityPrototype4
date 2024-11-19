using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float speed;
    public bool hasPowerup = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
       float fowardInput = Input.GetAxis("Vertical");

       playerRb.AddForce(focalPoint.transform.forward * speed * fowardInput); 
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Powerup")) {
            hasPowerup = true;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup) {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPLayer = collision.gameObject.transform.position - transform.position;
            enemyRigidBody.AddForce(awayFromPLayer * 10, ForceMode.Impulse);
            Debug.Log("Collided with " + collision.gameObject.name + "With power set to " + hasPowerup);
        }
    }
}
