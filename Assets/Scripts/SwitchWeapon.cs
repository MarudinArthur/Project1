using UnityEngine;
using TMPro;

public class SwitchWeapon : MonoBehaviour
{
    [HideInInspector] public int selectedWeapon = 0; 
    public TextMeshProUGUI weaponName;
    public TextMeshProUGUI ammoCounter;
    public Weapons weapons;

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

        if (Input.GetKeyDown(KeyCode.Alpha1) && weapons.isReloading == false)
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && weapons.isReloading == false)
        {
            selectedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && weapons.isReloading == false)
        {
            selectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && weapons.isReloading == false)
        {
            selectedWeapon = 3;
        }
    }
}