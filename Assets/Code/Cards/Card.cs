using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Card : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    private Enemy _enemy;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _enemy = FindObjectOfType<Enemy>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ApplyEffect);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ApplyEffect);
    }

    public void Disable()
    {
        _button.enabled = false;
    }

    public void Enable()
    {
        _button.enabled = true;
    }

    public void ApplyEffect()
    {
        Debug.Log("Carta tirada");
        _enemy.TakeDamage(_damage);
        _enemy.isAbleToThrowCards = false;
    }
}
