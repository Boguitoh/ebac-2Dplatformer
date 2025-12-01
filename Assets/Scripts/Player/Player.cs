using UnityEngine;
using DG.Tweening;
using System;

public class Player : MonoBehaviour
{
    #region VARIABLES

    [Header("Speed")]
    public Rigidbody2D myRigidBody;
    public float speedNormal;
    public float speedRunning;
    public float jumpForce;
    public Vector2 friction;
    private float _currentSpeed;

    [Header("Animation Scaling")]
    public Vector2 initialSize;
    public float jumpScaleY;
    public float jumpScaleX;
    public float jumpDuration;
    public Ease jumpEase;
    public float swipeDuration;
    public float runningAccel;
    
    [Header("Animation Change")]
    public string boolRun = "Run";
    public Animator animator;



    #endregion

    private void HandleMovement()
    {
        // Running movement
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRunning;
            animator.speed = runningAccel;
        }
        else
        {
            _currentSpeed = speedNormal;
            animator.speed = 1;
        }

        // Left/Right movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.linearVelocity = new Vector2(-_currentSpeed, myRigidBody.linearVelocity.y);
            if(myRigidBody.transform.localScale.x != -1)
            {
                myRigidBody.transform.DOScaleX(-1, swipeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.linearVelocity = new Vector2(_currentSpeed, myRigidBody.linearVelocity.y);
            if(myRigidBody.transform.localScale.x != 1)
            {
                myRigidBody.transform.DOScaleX(1, swipeDuration);
            }
            animator.SetBool(boolRun, true);
        }

        else
        {
            animator.SetBool(boolRun, false);
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

            myRigidBody.transform.localScale = initialSize;
            DOTween.Kill(myRigidBody.transform);

            animator.SetTrigger("Jump");

            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        myRigidBody.transform.DOScaleY(jumpScaleY, jumpDuration).SetLoops(2, LoopType.Yoyo).SetEase(jumpEase);
        myRigidBody.transform.DOScaleX(jumpScaleX, jumpDuration).SetLoops(2, LoopType.Yoyo).SetEase(jumpEase);
    }

    private void Update()
    {
        HandleJump();
        HandleMovement();
    }
}
