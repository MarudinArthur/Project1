using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taser : Weapons
{
	public GameObject porjectilePrefab;

	Taser()
	{
		// значения свойств временные
		WeaponFireRate = 10;
		WeaponRange = 10;
		WeaponDamage = 20;
		WeaponMaxAmmo = 3;
		WeaponSpread = 2;
		WeaponReloadTime = 4;
	}

	public override void Fire()
	{
        /*
		Debug.Log("Taser Fire! ");

        //сюда запишется инфо о пересечении луча, если оно будет
        RaycastHit hit;
        //сам луч, начинается от позиции этого объекта и направлен в сторону цели
        Ray ray = new Ray(transform.position, target.position - transform.position);
        //пускаем луч
        Physics.Raycast(ray, out hit);

        //если луч с чем-то пересёкся, то..
        if (hit.collider != null)
        {
            //если луч не попал в цель
            if (hit.collider.gameObject != target.gameObject)
            {
                Debug.Log("Путь к врагу преграждает объект: " + hit.collider.name);
            }
            //если луч попал в цель
            else
            {
                Debug.Log("Попадаю во врага!!!");
            }
            //просто для наглядности рисуем луч в окне Scene
            Debug.DrawLine(ray.origin, hit.point, Color.red);

        еще вариант

        RaycastHit hit;

		if (Physics.Raycast(firePos.transform.position, firePos.transform.forward, out hit, WeaponRange))
        {
			Debug.Log("Machinegun Fire! " + hit.collider.name);
		}
        }
        */
    }
}
