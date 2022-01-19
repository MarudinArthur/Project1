using UnityEngine;
using TMPro;

public class SwitchWeapon : MonoBehaviour
{
    [HideInInspector] public int selectedWeapon = 0; 
    public TextMeshProUGUI weaponName;
    public TextMeshProUGUI ammoCounter;
    public Weapons weapons;

    private Pistol _pistol;
    private ShotGun _shotGun;
    private Machinegun _machinegun;
    private Taser _taser;

    private void Start()
    {
        _pistol = GameObject.Find("Player").transform.GetChild(2).gameObject.transform.
    GetChild(0).GetComponent<Pistol>();
        _shotGun = GameObject.Find("Player").transform.GetChild(2).gameObject.transform.
            GetChild(1).GetComponent<ShotGun>();
        _machinegun = GameObject.Find("Player").transform.GetChild(2).gameObject.transform.
            GetChild(2).GetComponent<Machinegun>();
        _taser = GameObject.Find("Player").transform.GetChild(2).gameObject.transform.
            GetChild(3).GetComponent<Taser>();
    }

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
        if (!_pistol.isReloading && !_shotGun.isReloading && !_machinegun.isReloading && !_taser.isReloading)
        {
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
}