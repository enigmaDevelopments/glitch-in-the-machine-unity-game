using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseScale : MonoBehaviour
{
    public Transform wall;
    void Update()
    {
        transform.localScale = new Vector2(1, Mathf.Pow(wall.transform.localScale.y * .8f,-1));
    }
}
