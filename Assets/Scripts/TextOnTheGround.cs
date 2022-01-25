using UnityEngine;
using TMPro;
using System.Collections;

public class TextOnTheGround : MonoBehaviour
{
    public TMP_Text textOnTheGround;

    private const float Speed = 1.5f;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        StartCoroutine(nameof(ShowTextOnTheGround));

        if (textOnTheGround.transform.position.z > 15)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator ShowTextOnTheGround()
    {
        yield return new WaitForSeconds(3);

        if (!_gameManager.stopGame)
        {
            textOnTheGround.GetComponent<MeshRenderer>().enabled = true;
            textOnTheGround.transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }
    }
}