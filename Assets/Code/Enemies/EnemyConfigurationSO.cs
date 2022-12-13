using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Enemy", fileName = "Enemy")]
public class EnemyConfigurationSO : ScriptableObject
{
    public int health = 100;
    public int minDamage = 5;
    public int maxDamage = 30;
    public Sprite image;
}
