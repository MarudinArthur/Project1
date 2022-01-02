using UnityEngine;

public class ParticleHolder : MonoBehaviour
{
    public ParticleSystem[] effects;

    public void PlayParticle(int particleNumber, Vector3 particlePosition)
    {
        if (effects != null && effects[particleNumber] != null)
        {
            var tempPart = Instantiate(effects[particleNumber], particlePosition, Quaternion.identity);
            tempPart.Play();
        }
    }
}