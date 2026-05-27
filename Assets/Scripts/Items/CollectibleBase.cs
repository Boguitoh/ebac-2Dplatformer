using System.Collections.Generic;
using UnityEngine;

public class CollectibleBase : MonoBehaviour
{
    public string compareTag;
    public ParticleSystem particle;
    public float timeToHide;
    public GameObject graphicItem;

    /* 
    private void Awake()
    {
        if (particle != null) particle.transform.SetParent(null);
        // Move o objeto para a raíz do projeto, evitando exclusão
    }
    Método não funcionou, "transform resides in a prefab asset and cannot be set to prevent data corruption"
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        this.GetComponent<CircleCollider2D>().enabled = false;
        Invoke("HideObject", timeToHide);
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (particle != null) particle.Play();
    }

}
