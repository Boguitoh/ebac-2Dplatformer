using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float timeToDestroy;
    public Vector3 direction;

    public float side;

    public int bulletDamage;

    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void Update()
    {
        transform.Translate(direction * Time.deltaTime * side);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<EnemyBase>();

        if (enemy != null)
        {
            enemy.Damage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
