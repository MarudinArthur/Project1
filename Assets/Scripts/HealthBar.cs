using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private const float LockPos = 0;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

	public void Update()
	{
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, LockPos, LockPos);
    }
}