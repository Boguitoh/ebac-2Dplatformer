using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    #region VARIABLES

    public int damage;

    public Animator animator;
    public string triggerAttack = "Attack";

    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();

        if(health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }
}
