using UnityEngine;
using TMPro;

public class SwitchWeapon : MonoBehaviour
{
    [HideInInspector] public int selectedWeapon; 
    public TextMeshProUGUI weaponName;
    public TextMeshProUGUI ammoCounter;

    private Pistol _pistol;
    private ShotGun _shotGun;
    private ShotGun2 _shotGun2;
    private Machinegun _machinegun;
    private Machinegun2 _machinegun2;
    private Taser _taser;

    private void Start()
    {
        _pistol = GameObject.Find("Player").transform.GetChild(2).gameObject.transform.
            GetChild(0).GetComponent<Pistol>();
        _shotGun = GameObject.Find("Player").transform.GetChild(2).gameObject.transform.
            GetChild(1).GetComponent<ShotGun>();
        _shotGun2 = GameObject.Find("Player").transform.GetChild(2).gameObject.transform.
            GetChild(2).GetComponent<ShotGun2>();
        _machinegun = GameObject.Find("Player").transform.GetChild(2).gameObject.transform.
            GetChild(3).GetComponent<Machinegun>();
        _machinegun2 = GameObject.Find("Player").transform.GetChild(2).gameObject.transform.
            GetChild(4).GetComponent<Machinegun2>();
        _taser = GameObject.Find("Player").transform.GetChild(2).gameObject.transform.
            GetChild(5).GetComponent<Taser>();
    }

    private void Update()
    {
        for (var index = 0; index < transform.childCount; index++)
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
        if (!_pistol.isReloading && !_shotGun.isReloading && !_machinegun.isReloading && !_taser.isReloading && !_shotGun2.isReloading && !_machinegun2.isReloading)
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
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                selectedWeapon = 4;
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                selectedWeapon = 5;
            }
        }
    }
}