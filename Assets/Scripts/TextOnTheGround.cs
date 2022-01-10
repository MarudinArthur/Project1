using UnityEngine;
using TMPro;
using System.Collections;

public class TextOnTheGround : MonoBehaviour
{
    public TMP_Text textOnTheGround;

    private float speed = 1.5f;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        StartCoroutine("ShowTextOnTheGround");

        if (textOnTheGround.transform.position.z > 15)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ShowTextOnTheGround()
    {
        yield return new WaitForSeconds(3);

        if (!_gameManager.stopGame)
        {
            textOnTheGround.GetComponent<MeshRenderer>().enabled = true;
            textOnTheGround.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
}