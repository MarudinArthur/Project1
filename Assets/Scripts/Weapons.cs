using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapons : MonoBehaviour
{
    //public enum type { pistol, shotgun, machinegun, taser };

    protected float WeaponFireRate { get; set; } //скорость стрельбы
    protected float WeaponRange { get; set; } // дальность
    protected float WeaponDamage { get; set; } //урон
    protected float WeaponReloadTime { get; set; } //перезарядка
    protected float WeaponSpread { get; set; } //разброс стрельбы
    protected float WeaponAmmo { get; set; } //обойма

	public virtual void Fire() { }
}