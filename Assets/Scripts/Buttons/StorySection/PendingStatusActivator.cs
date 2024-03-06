using UnityEngine;

public class PendingStatusActivator : MonoBehaviour
{
    [SerializeField] string levelPrefName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivatePendingStatus()
    {
        PlayerPrefs.SetInt(levelPrefName, 2);
    }
}
