using UnityEngine;
using DG.Tweening;
using System;

public class Player : MonoBehaviour
{
    #region VARIABLES
    public Rigidbody2D myRigidBody;
    public HealthBase healthBase;

    [Header("Setup")]
    public SOPlayerSetup SOPlayerSetup;

    private float _currentSpeed;
    public Animator animator;

    /*[Header("Speed")]
    public float speedWalk;
    public float speedSprint;
    public float jumpForce;
    public Vector2 friction;*/


    /*[Header("Animation Scaling")]
    public Vector2 initialSize;
    public float soJumpScaleY;
    public float soJumpScaleX;
    public float soJumpDuration;
    public SO_Float soJumpScaleY;
    public SO_Float soJumpScaleX;
    public SO_Float soJumpDuration;
    public Ease jumpEase;
    public float swipeDuration;
    public float runningAccel;*/

    /*[Header("Animation Change")]
    public string boolRun = "Run";
    public string triggerAttack = "Attack";
    public string triggerDeath = "Death";*/



    #endregion

    private void Awake()
    {
        if (healthBase != null)
            healthBase.OnKill += OnEnemyKill;
    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;
        PlayDeathAnimation();
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(SOPlayerSetup.triggerAttack);
    }

    private void PlayDeathAnimation()
    {
        animator.SetTrigger(SOPlayerSetup.triggerDeath);
    }

    private void HandleMovement()
    {
        // Running movement
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = SOPlayerSetup.speedSprint;
            animator.speed = SOPlayerSetup.runningAccel;
        }
        else
        {
            _currentSpeed = SOPlayerSetup.speedWalk;
            animator.speed = 1;
        }

        // Left/Right movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.linearVelocity = new Vector2(-_currentSpeed, myRigidBody.linearVelocity.y);
            if(myRigidBody.transform.localScale.x != -1)
            {
                myRigidBody.transform.DOScaleX(-1, SOPlayerSetup.swipeDuration);
            }
            animator.SetBool(SOPlayerSetup.boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.linearVelocity = new Vector2(_currentSpeed, myRigidBody.linearVelocity.y);
            if(myRigidBody.transform.localScale.x != 1)
            {
                myRigidBody.transform.DOScaleX(1, SOPlayerSetup.swipeDuration);
            }
            animator.SetBool(SOPlayerSetup.boolRun, true);
        }

        else
        {
            animator.SetBool(SOPlayerSetup.boolRun, false);
        }

        // Left/Right friction
        if (myRigidBody.linearVelocity.x > 0)
        {
            myRigidBody.linearVelocity -= SOPlayerSetup.friction;
        }
        else if (myRigidBody.linearVelocity.x < 0)
        {
            myRigidBody.linearVelocity += SOPlayerSetup.friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.linearVelocity = Vector2.up * SOPlayerSetup.jumpForce;
            //myRigidBody.transform.localScale = Vector2.one;

            //myRigidBody.transform.localScale = SOPlayerSetup.initialSize;
            DOTween.Kill(myRigidBody.transform);

            //animator.SetTrigger("Jump");

            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        myRigidBody.transform.DOScaleY(SOPlayerSetup.soJumpScaleY, SOPlayerSetup.soJumpDuration).SetLoops(2, LoopType.Yoyo).SetEase(SOPlayerSetup.jumpEase);
        //myRigidBody.transform.DOScaleX(SOPlayerSetup.soJumpScaleX, SOPlayerSetup.soJumpDuration).SetLoops(2, LoopType.Yoyo).SetEase(SOPlayerSetup.jumpEase);
    }

    private void Update()
    {
        HandleJump();
        HandleMovement();
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
