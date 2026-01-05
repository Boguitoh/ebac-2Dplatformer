using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class FlashColor : MonoBehaviour
{
    public Color color = Color.red;
    public float duration;
    public int flashTimes;

    private Tween _currentTween;

    public List<SpriteRenderer> spriteRenderers;

    private void OnValidate()
    {
        spriteRenderers = new List<SpriteRenderer>();
        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderers.Add(child);
        }
    }

    public void Flash()
    {
        if(_currentTween != null)
        {
            _currentTween.Kill();
            spriteRenderers.ForEach(i => i.color = Color.white);
        }

        foreach(var s in spriteRenderers)
        {
            s.DOColor(color, duration).SetLoops(flashTimes, LoopType.Yoyo);
        }
    }
}
