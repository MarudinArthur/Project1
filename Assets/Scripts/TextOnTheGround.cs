using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextOnTheGround : MonoBehaviour
{
    public TMP_Text textOnTheGround;
    //private float time = 0;
    private float speed = 10;

    private void LateUpdate()
    {
        textOnTheGround.transform.position = Vector3.forward * speed * Time.deltaTime;
/*
        time += Time.deltaTime;
        if (time == 5.0f)
        {
            textOnTheGround.transform.position = Vector3.forward * speed * Time.deltaTime;
        }
*/
    }
}
