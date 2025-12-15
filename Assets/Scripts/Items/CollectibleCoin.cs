using UnityEngine;

public class CollectibleCoin : CollectibleBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins();
    }
}
