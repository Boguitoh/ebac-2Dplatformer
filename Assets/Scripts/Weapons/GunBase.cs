using System.Collections;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase pfbProjectile;

    public Transform shootPosition;
    public float shootInterval;
    private Coroutine _currentCoroutine;

    public Transform playerReference;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            if (_currentCoroutine != null) 
                StopCoroutine(_currentCoroutine);
        }
    }

    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(shootInterval);
        }
    }


    public void Shoot()
    {
        var projectile = Instantiate(pfbProjectile);
        projectile.transform.position = shootPosition.position;
        projectile.side = playerReference.transform.localScale.x;
    }
}
