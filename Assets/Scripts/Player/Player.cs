using UnityEngine;

public class Player : MonoBehaviour
{
    #region VARIABLES

    public Rigidbody2D myRigidBody;
    public float speed;
    public float jumpForce;
    public Vector2 friction;

    #endregion

    private void HandleMovement()
    {
        // Left/Right movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidBody.MovePosition(myRigidBody.position - velocity * Time.deltaTime);
            myRigidBody.linearVelocity = new Vector2(-speed, myRigidBody.linearVelocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidBody.MovePosition(myRigidBody.position + velocity * Time.deltaTime);
            myRigidBody.linearVelocity = new Vector2(speed, myRigidBody.linearVelocity.y);
        }

        // Left/Right friction
        if (myRigidBody.linearVelocity.x > 0)
        {
            myRigidBody.linearVelocity -= friction;
        }
        else if (myRigidBody.linearVelocity.x < 0)
        {
            myRigidBody.linearVelocity += friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.linearVelocity = Vector2.up * jumpForce;
        }
    }

    private void Update()
    {
        HandleJump();
        HandleMovement();
    }
}
