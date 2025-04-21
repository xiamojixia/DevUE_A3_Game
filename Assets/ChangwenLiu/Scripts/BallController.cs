using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public float jumpForce = 5f;
    public int maxJumps = 1;

    public AudioClip jumpSound;
    public AudioMixerGroup sfxMixerGroup;

    private Rigidbody rb;
    private float currentRotation = 0f;
    private int jumpsRemaining;

    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpsRemaining = maxJumps;

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.outputAudioMixerGroup = sfxMixerGroup;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpsRemaining--;

            if (jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }
    }

    void FixedUpdate()
    {
        float rotationInput = 0f;
        if (Input.GetKey(KeyCode.Q)) rotationInput = -1f;
        if (Input.GetKey(KeyCode.E)) rotationInput = 1f;

        currentRotation += rotationInput * rotationSpeed * Time.fixedDeltaTime;
        transform.rotation = Quaternion.Euler(0f, currentRotation, 0f);

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        Vector3 moveDir = transform.forward * moveZ + transform.right * moveX;
        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        jumpsRemaining = maxJumps;
    }
}