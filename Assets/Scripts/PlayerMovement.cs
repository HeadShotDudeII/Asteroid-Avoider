using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float maxVelocity = 10;
    [SerializeField] float forceMagnitude;
    [SerializeField] float roatationSpeed = 100;
    private Rigidbody playerRigidBody;
    private Vector3 movementDirection;
    private Camera mainCamera;
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        mainCamera = Camera.main;


    }

    // Update is called once per frame
    void Update()
    {
        KeepPlayerOnScreen();
        RotateToFaceVelocity();
    }

    private void RotateToFaceVelocity()
    {
        if (playerRigidBody.velocity == Vector3.zero) return;

        Quaternion targetRotation = Quaternion.LookRotation(playerRigidBody.velocity, Vector3.back);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, roatationSpeed * Time.deltaTime);

    }

    private void KeepPlayerOnScreen()
    {
        Vector3 newPostion = transform.position;

        Vector3 viewPortPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (viewPortPosition.x > 1)
        {
            newPostion.x = -newPostion.x + 0.1f;

        }
        if (viewPortPosition.x < 0)
        {
            newPostion.x = -newPostion.x - 0.1f;

        }

        if (viewPortPosition.y > 1)
        {
            newPostion.y = -newPostion.y + 0.1f;

        }
        if (viewPortPosition.y < 0)
        {
            newPostion.y = -newPostion.y - 0.1f;

        }



        transform.position = newPostion;

    }

    void FixedUpdate()
    {
        MoveDirection();
        Move();

    }

    private void MoveDirection()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(touchPos);

            movementDirection = worldPos - transform.position;
            movementDirection.z = 0;
            movementDirection.Normalize();

            //Debug.Log(movementDirection);



        }
        else
        {

            movementDirection = Vector3.zero;



        }
    }

    private void Move()
    {
        if (movementDirection == Vector3.zero) return;

        playerRigidBody.AddForce(movementDirection * forceMagnitude, ForceMode.Force);
        playerRigidBody.velocity = Vector3.ClampMagnitude(playerRigidBody.velocity, maxVelocity);
    }
}
