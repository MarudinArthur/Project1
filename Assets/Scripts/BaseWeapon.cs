using UnityEngine;

public class BaseWeapon : Weapon
{
	private SwitchWeapon _switchweapon;
	
	public GameObject projectilePistol;
	public GameObject projectileShotGun2;
	public GameObject projectileMachinegun;
	public GameObject projectileMachinegun2;
	public GameObject projectileTaser;
	
	private void Start()
	{
		_switchweapon = GameObject.Find("Player").transform.GetChild(2).GetComponent<SwitchWeapon>();
	}

	public void Fire()
	{
		switch (_switchweapon.selectedWeapon)
			{
				case 0:
					Instantiate(projectilePistol, transform.position, transform.rotation);
					break;
				
				case 1:
					Instantiate(projectileShotGun2, transform.position, transform.rotation);
					break;
				
				case 3:
					Instantiate(projectileMachinegun, transform.position, transform.rotation);
					break;
				
				case 4:
					Instantiate(projectileMachinegun2, transform.position, transform.rotation);
					break;
				
				case 5:
					Instantiate(projectileTaser, transform.position, transform.rotation);
					break;
			}
			currentAmmo--;
	}
}