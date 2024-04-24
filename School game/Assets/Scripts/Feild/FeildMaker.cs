using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Feild
{
    public class FeildMaker : MonoBehaviour
    {
        public GameObject feild;
        public Transform feildCreator1;
        public Transform feildCreator2;
        public Activator power;
        public bool startOn;
        void Start()
        {
            feild.transform.position = new Vector2(feildCreator1.position.x + feildCreator2.position.x, feildCreator1.position.y + feildCreator2.position.y) / 2f;
            feild.transform.localScale = new Vector2(1, Mathf.Abs(feildCreator1.position.y - feildCreator2.position.y) + 1);
        }
        private void Update()
        {
            if (power != null)
            {
                feild.gameObject.GetComponent<SpriteRenderer>().enabled = power ^ startOn;
                feild.gameObject.GetComponent<BoxCollider2D>().enabled = power ^ startOn;
            }
        }
    }
}

