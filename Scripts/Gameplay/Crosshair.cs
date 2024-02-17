using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Image _crosshair;
    [SerializeField] private Image _currentNumber;

    private void FixedUpdate()
    {
        if (_currentNumber != null)
        {
            _currentNumber.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, _currentNumber.transform.position.y);
            _crosshair.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, _crosshair.transform.position.y);
        }
    }
}
