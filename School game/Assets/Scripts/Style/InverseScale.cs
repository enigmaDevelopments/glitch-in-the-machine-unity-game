using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Style
{
    public class InverseScale : MonoBehaviour
    {
        public Transform wall;
        void Update()
        {
            transform.localScale = new Vector2(Mathf.Pow(wall.transform.localScale.x, -1), Mathf.Pow(wall.transform.localScale.y, -1));
        }
    }
}
