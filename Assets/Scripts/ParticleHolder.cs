using UnityEngine;

public class ParticleHolder : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] effects;

    public void PlayParticle(int particleNumber, Vector3 particlePosition)
    {
        if (effects != null && effects[particleNumber] != null)
        {
            var spawnParticle = Instantiate(effects[particleNumber], particlePosition, Quaternion.identity);
            spawnParticle.Play();
        }
    }
}