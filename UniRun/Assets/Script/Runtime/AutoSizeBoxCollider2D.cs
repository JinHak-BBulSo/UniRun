using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSizeBoxCollider2D : MonoBehaviour
{
    void Awake()
    {
        BoxCollider2D boxCollider = gameObject.GetComponentMust<BoxCollider2D>();
        boxCollider.size = gameObject.GetRectSizeDelta();
    }
}