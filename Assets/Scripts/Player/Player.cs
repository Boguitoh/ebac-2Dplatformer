using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    #region VARIABLES

    [Header("Speed")]
    public Rigidbody2D myRigidBody;
    public float speed;
    public float speedRun;
    public float jumpForce;
    public Vector2 friction;
    private float _currentSpeed;

    [Header("Animation")]
    public float jumpScaleY;
    public float jumpScaleX;
    public float animationDuration;

    #endregion

    private void HandleMovement()
    {
        // Running movement
        if (Input.GetKey(KeyCode.LeftShift))
            _currentSpeed = speedRun;
        else
            _currentSpeed = speed;

        // Left/Right movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidBody.MovePosition(myRigidBody.position - velocity * Time.deltaTime);
            myRigidBody.linearVelocity = new Vector2(-_currentSpeed, myRigidBody.linearVelocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidBody.MovePosition(myRigidBody.position + velocity * Time.deltaTime);
            myRigidBody.linearVelocity = new Vector2(_currentSpeed, myRigidBody.linearVelocity.y);
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

            DOTween.Kill(myRigidBody.transform);
            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        myRigidBody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo);
        myRigidBody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo);
    }

    private void Update()
    {
        HandleJump();
        HandleMovement();
    }
}
