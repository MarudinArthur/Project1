using UnityEngine;

public class DestroyOffscreen : MonoBehaviour
{
    public GameObject projectilePrefab;
    private float _topBound = 15;

    void Update()
    {
        if (projectilePrefab.transform.position.z > _topBound)
        {
            Destroy(projectilePrefab.gameObject);
        }
    }
}
