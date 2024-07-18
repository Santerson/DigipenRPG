using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{
    [Tooltip("The speed at which the player ACCELERATES at")]
    [SerializeField] float PlayerAccelerationSpeed = 5.0f;
    [Tooltip("The Player's max move speed")]
    [SerializeField] float PlayerMaxMoveSpeed = 3.0f;
    [Tooltip("The rate that the player slows down")]
    [SerializeField] float DampingCoefficient = 0.97f;
    Rigidbody2D RefRigidbody = null;
    Vector2 position = Vector2.zero;

    private void Awake()
    {
        RefRigidbody = GetComponent<Rigidbody2D>();
        if (RefRigidbody == null)
        {
            Debug.LogError("Player must have a rigidbody component");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

    }

    /// <summary>
    /// Detects player input and will move the character
    /// </summary>
    void MovePlayer()
    {
        if (RefRigidbody == null) return;
        //Creating a move vector
        Vector2 inputVector = Vector2.zero;

        //Checking for player input on the keyboard
        if (Input.GetKey(KeyCode.W)) { inputVector.y += 1; } //Up
        if (Input.GetKey(KeyCode.A)) { inputVector.x -= 1; } //Left
        if (Input.GetKey(KeyCode.S)) { inputVector.y -= 1; } //Down
        if (Input.GetKey(KeyCode.D)) { inputVector.x += 1; } //Right
        //Normalizing the vector so we can have the player actually move at the correct speed
        inputVector.Normalize();
        //Move the player
        RefRigidbody.AddForce(inputVector * PlayerAccelerationSpeed);

        //Checking if the player is moving faster than their maximum movement speed (this usually happens if you move diagonally)
        if (RefRigidbody.velocity.magnitude > PlayerMaxMoveSpeed)
        {
            //Slow down the player so they don't go faster than they can
            RefRigidbody.velocity = RefRigidbody.velocity.normalized * PlayerMaxMoveSpeed;
        }

        // We know the player let go of the controls if the input vector is nearly zero.
        if (inputVector.sqrMagnitude <= 0.1f)
        {
            // Quickly damp the movement when we let go of the inputs by multiplying the vector
            // by a value less than one each frame.
            RefRigidbody.velocity *= DampingCoefficient;
        }

        position = transform.position;
    }

    public void resetPosition()
    {
        transform.position = position;
    }
}
