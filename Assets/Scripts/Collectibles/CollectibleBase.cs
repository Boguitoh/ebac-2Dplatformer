using UnityEngine;

public class CollectibleBase : MonoBehaviour
{
    public string compareTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect();

}
