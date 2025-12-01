using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    #region VARIABLES

    public int damage;

    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();

        if(health != null)
        {
            health.Damage(damage);
        }
    }
}
