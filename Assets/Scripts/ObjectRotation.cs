using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
	private const float Speed = 2.5f;
	private GameManager _gameManager;

	public void Start()
	{
		_gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
	}

	private void Update()
    {
		if (!_gameManager.gameOver && !_gameManager.stopGame)
		{
			transform.Rotate(transform.rotation.x, 2, transform.rotation.z * Speed * Time.deltaTime);
		}
	}
}