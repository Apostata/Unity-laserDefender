using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{

    [SerializeField] Vector2 moveSpeed = new Vector2(0, 0.5f);

    Vector2 offset;
    Material material;

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        offset += moveSpeed * Time.deltaTime;
        material.mainTextureOffset = offset;
    }
}
