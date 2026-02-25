using UnityEngine;
using DG.Tweening;
using System;

public class Player : MonoBehaviour
{
    #region VARIABLES
    public Rigidbody2D myRigidBody;
    public HealthBase healthBase;

    [Header("Setup")]
    public SOPlayerSetup sOPlayerSetup;

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
        animator.SetTrigger(sOPlayerSetup.triggerAttack);
    }

    private void PlayDeathAnimation()
    {
        animator.SetTrigger(sOPlayerSetup.triggerDeath);
    }

    private void HandleMovement()
    {
        // Running movement
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = sOPlayerSetup.speedSprint;
            animator.speed = sOPlayerSetup.runningAccel;
        }
        else
        {
            _currentSpeed = sOPlayerSetup.speedWalk;
            animator.speed = 1;
        }

        // Left/Right movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.linearVelocity = new Vector2(-_currentSpeed, myRigidBody.linearVelocity.y);
            if(myRigidBody.transform.localScale.x != -1)
            {
                myRigidBody.transform.DOScaleX(-1, sOPlayerSetup.swipeDuration);
            }
            animator.SetBool(sOPlayerSetup.boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.linearVelocity = new Vector2(_currentSpeed, myRigidBody.linearVelocity.y);
            if(myRigidBody.transform.localScale.x != 1)
            {
                myRigidBody.transform.DOScaleX(1, sOPlayerSetup.swipeDuration);
            }
            animator.SetBool(sOPlayerSetup.boolRun, true);
        }

        else
        {
            animator.SetBool(sOPlayerSetup.boolRun, false);
        }

        // Left/Right friction
        if (myRigidBody.linearVelocity.x > 0)
        {
            myRigidBody.linearVelocity -= sOPlayerSetup.friction;
        }
        else if (myRigidBody.linearVelocity.x < 0)
        {
            myRigidBody.linearVelocity += sOPlayerSetup.friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.linearVelocity = Vector2.up * sOPlayerSetup.jumpForce;

            myRigidBody.transform.localScale = sOPlayerSetup.initialSize;
            DOTween.Kill(myRigidBody.transform);

            animator.SetTrigger("Jump");

            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        myRigidBody.transform.DOScaleY(sOPlayerSetup.soJumpScaleY, sOPlayerSetup.soJumpDuration).SetLoops(2, LoopType.Yoyo).SetEase(sOPlayerSetup.jumpEase);
        myRigidBody.transform.DOScaleX(sOPlayerSetup.soJumpScaleX, sOPlayerSetup.soJumpDuration).SetLoops(2, LoopType.Yoyo).SetEase(sOPlayerSetup.jumpEase);
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
