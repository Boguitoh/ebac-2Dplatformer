using UnityEngine;

public class HealthBase : MonoBehaviour
{
    #region VARIABLES

    public int startingLife;
    private int _currentLife;

    public float delayToKill;
    public bool destroyOnKill = false;
    private bool _isDead = false;

    #endregion

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startingLife;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;

        if (_currentLife <= 0)
            Kill();
    }

    private void Kill()
    {
        _isDead = true;
        if (destroyOnKill)
            Destroy(gameObject, delayToKill);
    }
}
