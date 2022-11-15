using UnityEngine;

[DisallowMultipleComponent]
public class UIScreen : MonoBehaviour
{
    [SerializeField] private string _name;

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }

    public string GetName()
    {
        return _name;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
