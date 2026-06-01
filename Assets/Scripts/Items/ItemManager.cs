using UnityEngine;
using ebac.Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    public SO_Int coins;

    public static ItemManager Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
    }
}
