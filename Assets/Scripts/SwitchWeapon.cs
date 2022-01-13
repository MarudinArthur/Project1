using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public int selectedWeapon = 0;

    void Update()
    {
        for (int index = 0; index < transform.childCount; index++)
        {
            if (index == selectedWeapon)
            {
                gameObject.transform.GetChild(index).gameObject.SetActive(true);
            }
            else
            {
                gameObject.transform.GetChild(index).gameObject.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedWeapon = 3;
        }
    }
}