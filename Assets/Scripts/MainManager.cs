using UnityEngine;
using TMPro;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    [SerializeField] private TMP_InputField playerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}