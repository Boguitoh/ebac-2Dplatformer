using System;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    #region VARIABLES

    public Action OnKill;

    public int startingLife;
    private int _currentLife;

    public float delayToKill;
    public bool destroyOnKill = false;
    private bool _isDead = false;

    public FlashColor flashColor;

    #endregion

    private void Awake()
    {
        Init();
        if (flashColor == null)
        {
            flashColor = GetComponent<FlashColor>();
        }
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

        if (flashColor != null)
        {
            flashColor.Flash();
        }
    }

    private void Kill()
    {
        _isDead = true;
        if (destroyOnKill)
            Destroy(gameObject, delayToKill);

        if (OnKill != null)
            OnKill.Invoke();
        // OnKill?.Invoke();
    }
}
