using System;
using UnityEngine;

public class AuraSpinner : MonoBehaviour
{
    [SerializeField] float spinningSpeed;


    void Start()
    {


    }

    private void SpinningAura()
    {
        transform.Rotate(0, 0, spinningSpeed * Time.deltaTime) ;
    }

    // Update is called once per frame
    void Update()
    {
        SpinningAura();

    }
}
