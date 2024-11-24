using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerupStrenght = 10.0f;
    public float speed;
    public bool hasPowerup = false;
    public GameObject powerupIndicator;
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
       powerupIndicator.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Powerup")) {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false;
         powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup) {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPLayer = collision.gameObject.transform.position - transform.position;
            enemyRigidBody.AddForce(awayFromPLayer * powerupStrenght, ForceMode.Impulse);
            Debug.Log("Collided with " + collision.gameObject.name + "With power set to " + hasPowerup);
        }
    }
}
