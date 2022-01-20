using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    private float _speed = 2.5f;
    private GameManager _gameManager;

	public void Start()
	{
		_gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
	}

	void Update()
    {
		if (!_gameManager.gameOver && !_gameManager.stopGame)
		{
			transform.Rotate(gameObject.transform.rotation.x, 2, gameObject.transform.rotation.z * _speed * Time.deltaTime);
		}
	}
}