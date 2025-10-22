using NUnit.Framework;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class MenuButtonManager : MonoBehaviour
{
    public List<GameObject> buttons;

    [Header("Animation")]
    public float duration;
    public float delay;
    public Ease ease = Ease.OutBack;

    private void Awake()
    {
        HideAllButtons();
        ShowButtons();
    }

    private void HideAllButtons()
    {
        foreach(var b in buttons)
        {
            b.transform.localScale = Vector3.zero;
            b.SetActive(false);
        }
    }

    private void ShowButtons()
    {
        for(int i = 0; i < buttons.Count; i++)
        {
            var b = buttons[i];
            b.SetActive(true);
            b.transform.DOScale(1, duration).SetDelay(i*delay).SetEase(ease);
        }
    }
}
