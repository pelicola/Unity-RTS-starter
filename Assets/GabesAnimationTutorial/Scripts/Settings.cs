using UnityEngine;


[DefaultExecutionOrder(-100)]
public class Settings : MonoBehaviour
{
    [field: SerializeField, Range(0,100)] public float MouseMoveSense { get; private set; }
    [field: SerializeField, Range(0,1)] public float MouseZoomSens { get; private set; }
    [field: SerializeField, Range(0,100)] public float MouseRotateSens { get; private set; }
    
    public static Settings Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
}
