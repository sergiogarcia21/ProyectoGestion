using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private int _currentHealth = 100;
    public TextMeshProUGUI text;

    public void Reset()
    {
        _currentHealth = 100;
        text.text = _currentHealth.ToString();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if(_currentHealth <= 0)
        {
            _currentHealth = 0;
            Die();
        }

        text.text = _currentHealth.ToString();
    }

    private void Die()
    {
        FindObjectOfType<UIScreenController>().SwitchScreen("LooseGame");
    }
}
