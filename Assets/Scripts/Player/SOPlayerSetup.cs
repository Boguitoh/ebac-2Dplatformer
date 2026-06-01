using DG.Tweening;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    [Header("Speed")]
    public float speedWalk = 15f;
    public float speedSprint = 25f;
    public float jumpForce = 30f;
    public Vector2 friction = new Vector2(0.65f,0);

    [Header("Animation Scaling")]
    public Vector2 initialSize;
    public float soJumpScaleY = 0.6f;
    public float soJumpScaleX = 1.3f;
    public float soJumpDuration = 0.1f;
    public Ease jumpEase = Ease.InBounce;
    public float swipeDuration = 0.2f;
    public float runningAccel = 1.75f;

    [Header("Animation Change")]
    public string boolRun = "Run";
    public string triggerAttack = "Attack";
    public string triggerDeath = "Death";
}
