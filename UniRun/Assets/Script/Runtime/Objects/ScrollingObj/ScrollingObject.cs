using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private float speed = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.isGameOver)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        else
        {
            return;
        }
    }
}
