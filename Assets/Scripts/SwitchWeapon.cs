using UnityEngine;
using TMPro;

public class SwitchWeapon : MonoBehaviour
{
    private int selectedWeapon = 0;
    public TextMeshProUGUI weaponName;

    void Update()
    {
        for (int index = 0; index < transform.childCount; index++)
        {
            if (index == selectedWeapon)
            {
                gameObject.transform.GetChild(index).gameObject.SetActive(true);
                weaponName.text = "Your weapon: " + transform.GetChild(index).name;
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