using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    private ParticleSystem _particle;

    private void Start()
    {
        _particle = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (_particle)
        {
            if (!_particle.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
