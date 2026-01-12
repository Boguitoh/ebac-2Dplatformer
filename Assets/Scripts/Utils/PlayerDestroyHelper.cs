using UnityEngine;

public class PlayerDestroyHelper : MonoBehaviour
{
    public Player player;

    public void KillPlayer()
    {
        player.DestroyMe();
    }
}
