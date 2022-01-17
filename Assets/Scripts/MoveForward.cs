using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private SwitchWeapon switchWeapon;

    private Pistol _pistol;
    private ShotGun _shotGun;
    private Machinegun _machinegun;
    private Taser _taser;
    //private Rigidbody projectileRb;

	public void Start()
	{
        _pistol = GameObject.Find("Player").transform.GetChild(3).gameObject.transform.
            GetChild(0).GetComponent<Pistol>();
        _shotGun = GameObject.Find("Player").transform.GetChild(3).gameObject.transform.
            GetChild(1).GetComponent<ShotGun>();
        _machinegun = GameObject.Find("Player").transform.GetChild(3).gameObject.transform.
            GetChild(2).GetComponent<Machinegun>();
        _taser = GameObject.Find("Player").transform.GetChild(3).gameObject.transform.
            GetChild(3).GetComponent<Taser>();

        switchWeapon = GameObject.Find("Player").transform.GetChild(3).GetComponent<SwitchWeapon>();
        //projectileRb = GetComponent<Rigidbody>();
    }

	void Update()
    {
        switch (switchWeapon.selectedWeapon)
		{
            //case 0:
                //transform.Translate(Vector3.forward * _pistol.WeaponFireRate * Time.deltaTime);
                //if (transform.position.z > _pistol.WeaponRange)
                //    Destroy(gameObject);
                //break;

            case 1:
                //transform.Translate(Vector3.forward * _shotGun.WeaponFireRate * Time.deltaTime);
                if (transform.position.z > _shotGun.WeaponRange)
                    Destroy(gameObject);
                break;

            case 2:
                transform.Translate(Vector3.forward * 10f * Time.deltaTime); //временно
                if (transform.position.z > _machinegun.WeaponRange)
                    Destroy(gameObject);
                break;

            case 3:
                transform.Translate(Vector3.forward * _taser.WeaponFireRate * Time.deltaTime);
                if (transform.position.z > _taser.WeaponRange)
                    Destroy(gameObject);
                break;
        }
    }
}