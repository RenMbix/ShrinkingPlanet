using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public variables
    [Range(0, 15)]
    public float moveSpeed;

    [Range(50, 250)]
    public float rototionSpeed;

    [HideInInspector]
    public bool isDead;


    // private variables
    private Rigidbody rb;
    private float rotation;
    private float score;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // initailize the private varaibles
        rb = this.GetComponent<Rigidbody>();
        isDead = false;
    }

    void Update()
    {
        // gets the rotation value from input axis
        rotation = Input.GetAxisRaw("Horizontal");
        if (scoreText == null)
            return;
        if (!isDead)
        {
            score = score + Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        // moves the player in its front direction
        rb.MovePosition(rb.position + this.transform.forward * -moveSpeed * Time.fixedDeltaTime);

        // rotates the car with input
        Vector3 rotationY = Vector3.up * rotation * rototionSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(rotationY);
        Quaternion targetRotation = rb.rotation * deltaRotation;
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.fixedDeltaTime));
    }
}