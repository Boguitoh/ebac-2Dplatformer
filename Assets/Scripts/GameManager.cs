using DG.Tweening;
using ebac.Core.Singleton;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject playerPrefab;

    [Header("Enemies")]
    public List<GameObject> enemies;

    [Header("References")]
    public Transform startPoint;
    private GameObject _currentPlayer;

    [Header("Animation")]
    public float duration;
    public float delay;
    public Ease ease = Ease.OutBack;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        _currentPlayer = Instantiate(playerPrefab);
        _currentPlayer.transform.position = startPoint.transform.position;
        _currentPlayer.transform.DOScale(0, duration).SetEase(ease).From().SetDelay(delay);
    }
}
