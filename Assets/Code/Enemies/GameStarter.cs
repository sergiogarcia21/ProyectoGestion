using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public void StartGame()
    {
        FindObjectOfType<EnemySwitcher>().StartGame();
        FindObjectOfType<PlayerHealth>().Reset();
    }
}
