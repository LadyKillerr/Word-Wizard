using System;
using UnityEngine;

public class AuraSpinner : MonoBehaviour
{
    [SerializeField] float spinningSpeed;
    RectTransform auraTransform;

    void Start()
    {
        auraTransform.GetComponent<RectTransform>();

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
