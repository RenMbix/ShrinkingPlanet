using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerCollision : MonoBehaviour
{
    // public variables
    public GameObject deathEffect;
    public Animator ScreenAnimator;

    // private variables
    private AudioSource audioSource;
    private PlayerController playerController;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        playerController = this.GetComponent<PlayerController>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Meteror")
        {
            audioSource.Stop();

            // creates the deathEffect instance of the car
            Instantiate(deathEffect, this.transform.position, this.transform.rotation);

            PlayerController movement = this.GetComponent<PlayerController>();

            ScreenAnimator.SetTrigger("PlayerDead");
            playerController.isDead = true;

            this.gameObject.SetActive(false);
        }
    }
}