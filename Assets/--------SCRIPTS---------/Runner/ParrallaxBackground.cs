using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParrallaxBackground : MonoBehaviour
{
    Material backgroundMaterial;

    [SerializeField] Vector2 moveSpeed;

    Vector2 offset;

    // Start is called before the first frame update
    void Awake()
    {
        backgroundMaterial = GetComponent<Image>().material;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBackground();
    }

    void MoveBackground()
    {
        // gán offset + moveSpeed theo từng frame
        offset = moveSpeed + offset;

        // 
        backgroundMaterial.mainTextureOffset = offset;
    }

}
