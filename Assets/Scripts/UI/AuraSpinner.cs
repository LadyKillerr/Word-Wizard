using System;
using UnityEngine;

public class AuraSpinner : MonoBehaviour
{
    [SerializeField] float spinningSpeed;
    Transform auraTransform;

    void Start()
    {
        auraTransform.GetComponent<Transform>();

        SpinningAura();
    }

    private void SpinningAura()
    {
        auraTransform.Rotate(0, 0, spinningSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
