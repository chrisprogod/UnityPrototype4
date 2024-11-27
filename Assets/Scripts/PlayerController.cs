using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float powerupStrenght = 15.0f;
    public float speed;
    public bool hasPowerup = false;
    public GameObject powerupIndicator;
    private GameManager gameManager;
    public SoundManager soundManager;  
    void Start()
    {
        speed = 7;
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.restartButton.SetActive(false);
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>(); 
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float fowardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * speed * fowardInput);
        powerupIndicator.transform.position = transform.position;

        if (transform.position.y < -4)
        {
            gameManager.ShowRestartButton();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            soundManager.PlayPowerupCollectSound();
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
        yield return new WaitForSeconds(10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPLayer = collision.gameObject.transform.position - transform.position;
            enemyRigidBody.AddForce(awayFromPLayer * powerupStrenght, ForceMode.Impulse);
            Debug.Log("Collided with " + collision.gameObject.name + "With power set to " + hasPowerup);
        }
    }
}
