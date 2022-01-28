using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private GameObject _player;
    private SwitchWeapon _switchWeapon;
    private Pistol _pistol;
    private ShotGun _shotGun;
    private ShotGun2 _shotGun2;
    private Machinegun2 _machinegun2;
    private Machinegun _machinegun;
    private Taser _taser;

	public void Start()
	{
        _player = GameObject.Find("Player");
        var weaponHolder = _player.transform.GetChild(2);
        _switchWeapon = weaponHolder.GetComponent<SwitchWeapon>();
        
        _pistol = weaponHolder.GetChild(0).GetComponent<Pistol>();
        _shotGun = weaponHolder.GetChild(1).GetComponent<ShotGun>();
        _shotGun2 = weaponHolder.GetChild(2).GetComponent<ShotGun2>();
        _machinegun = weaponHolder.GetChild(3).GetComponent<Machinegun>();
        _machinegun2 = weaponHolder.GetChild(4).GetComponent<Machinegun2>();
        _taser = weaponHolder.GetChild(5).GetComponent<Taser>();
    }

    private void Update()
    {
        switch (_switchWeapon.selectedWeapon)
		{
            case 0:
                transform.Translate(Vector3.forward * (_pistol.WeaponFireRate * Time.deltaTime));
                if (transform.position.z > _player.transform.position.z + _pistol.WeaponRange)
                    Destroy(gameObject);
                break;

            case 1:
                transform.Translate(Vector3.forward * (_shotGun.WeaponFireRate * Time.deltaTime));
                if (transform.position.z > _player.transform.position.z + _shotGun.WeaponRange)
                    Destroy(gameObject);
                break;

            case 2:
                transform.Translate(Vector3.forward * (_shotGun2.WeaponFireRate * Time.deltaTime));
                if (transform.position.z > _player.transform.position.z + _shotGun2.WeaponRange)
                    Destroy(gameObject);
                break;

            case 3:
                transform.Translate(Vector3.forward * (_machinegun.WeaponFireRate * Time.deltaTime));
                if (transform.position.z > _player.transform.position.z + _machinegun.WeaponRange)
                    Destroy(gameObject);
                break;
            case 4:
                transform.Translate(Vector3.forward * (_machinegun2.WeaponFireRate * Time.deltaTime));
                if (transform.position.z > _player.transform.position.z + _machinegun2.WeaponRange)
                    Destroy(gameObject);
                break;
            case 5:
                transform.Translate(Vector3.forward * (_taser.WeaponFireRate * Time.deltaTime));
                if (transform.position.z > _player.transform.position.z + _taser.WeaponRange)
                    Destroy(gameObject);
                break;
        }
    }
}