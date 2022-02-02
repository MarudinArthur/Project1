using UnityEngine;
using TMPro;

public class SwitchWeapon : MonoBehaviour
{
    #region Fields

    [SerializeField] private TextMeshProUGUI weaponName;
    [SerializeField] private TextMeshProUGUI ammoCounter;
    
    public int selectedWeapon; 

    private Pistol _pistol;
    private ShotGun _shotGun;
    private ShotGun2 _shotGun2;
    private Machinegun _machinegun;
    private Machinegun2 _machinegun2;
    private Taser _taser;

    #endregion

    private void Start()
    {
        var weaponHolder = GameObject.Find("Player").transform.GetChild(2);
        
        _pistol = weaponHolder.gameObject.transform.GetChild(0).GetComponent<Pistol>();
        _shotGun = weaponHolder.gameObject.transform.GetChild(1).GetComponent<ShotGun>();
        _shotGun2 = weaponHolder.gameObject.transform.GetChild(2).GetComponent<ShotGun2>();
        _machinegun = weaponHolder.gameObject.transform.GetChild(3).GetComponent<Machinegun>();
        _machinegun2 = weaponHolder.gameObject.transform.GetChild(4).GetComponent<Machinegun2>();
        _taser = weaponHolder.gameObject.transform.GetChild(5).GetComponent<Taser>();
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
                selectedWeapon = 0;
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
                selectedWeapon = 1;

            if (Input.GetKeyDown(KeyCode.Alpha3))
                selectedWeapon = 2;
            
            if (Input.GetKeyDown(KeyCode.Alpha4))
                selectedWeapon = 3;
            
            if (Input.GetKeyDown(KeyCode.Alpha5))
                selectedWeapon = 4;
            
            if (Input.GetKeyDown(KeyCode.Alpha6))
                selectedWeapon = 5;
        }
    }
}