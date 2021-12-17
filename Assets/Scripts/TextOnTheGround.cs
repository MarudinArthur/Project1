using UnityEngine;
using TMPro;
using System.Collections;

public class TextOnTheGround : MonoBehaviour
{
    public TMP_Text textOnTheGround;
    private float speed = 1.5f;

    private void Update()
    {
        StartCoroutine("ShowTextOnTheGround");

        if(textOnTheGround.transform.position.z > 15)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ShowTextOnTheGround()
    {
        yield return new WaitForSeconds(3);
        textOnTheGround.GetComponent<MeshRenderer>().enabled = true;
        textOnTheGround.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}