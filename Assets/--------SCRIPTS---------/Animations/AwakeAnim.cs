using UnityEngine;

public class AwakeAnim : MonoBehaviour
{
    Animator transitionsAnim;
    private void Awake()
    {
        transitionsAnim = FindAnyObjectByType<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transitionsAnim.SetTrigger("start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
