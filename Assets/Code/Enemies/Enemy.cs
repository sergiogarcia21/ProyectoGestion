using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private EnemyConfigurationSO _configuration;
    private int _currentHealth;
    public TextMeshProUGUI text;
    public TextMeshProUGUI turnText;
    public Image image;
    private EnemySwitcher _enemySwitcher;
    public bool isAbleToThrowCards = true;
    private bool _isPerformingCard = false;
    private PlayerHealth _playerHealth;
    public Card[] cards;

    private void Awake()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _enemySwitcher = FindObjectOfType<EnemySwitcher>();
        turnText.text = "Your turn";
    }

    private void Update()
    {
        if(!isAbleToThrowCards)
        {
            if(!_isPerformingCard)
            {
                turnText.text = "Enemy's turn";
                _isPerformingCard = true;
                StartCoroutine(EnemyCycle());
            }
        }
    }

    private IEnumerator EnemyCycle()
    {
        foreach(Card card in cards)
        {
            card.Disable();
        }
        yield return new WaitForSeconds(Random.Range(1, 3f));
        _playerHealth.TakeDamage(Random.Range(_configuration.minDamage, _configuration.maxDamage));
        foreach (Card card in cards)
        {
            card.Enable();
        }

        turnText.text = "Your turn";
        _isPerformingCard = false;
        isAbleToThrowCards = true;
    }

    public void SetConfiguration(EnemyConfigurationSO config)
    {
        _configuration = config;
        ApplyConfiguration();
    }

    private void ApplyConfiguration()
    {
        _currentHealth = _configuration.health;
        text.text = _configuration.health.ToString();
        image.sprite = _configuration.image;
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
        _enemySwitcher.SetNextEnemy();
    }
}
