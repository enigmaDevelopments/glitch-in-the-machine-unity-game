using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using player;

namespace Player
{
    public class ParentPlayerToMovable : MonoBehaviour
    {
        private GameObject parent;
        private Checker check;
        public int ParentScaleDir
        {
            get
            {
                if (parent == null || parent.transform.lossyScale.x == 0)
                    return 1;
                return Math.Sign(parent.transform.lossyScale.x);
            }
        }
        private void Start()
        {
            check = GetComponent<Checker>();
        }
        private void Update()
        {
            if (parent == null)
            {
                parentToBellow();
            }
            else if (!getBellow().Contains(parent))
                unparent();
        }
        private void parentToBellow()
        {
            GameObject[] bellow = getBellow();
            if (bellow.Length != 0 && parent == null)
            {
                if (bellow[0].layer == 13)
                    transform.SetParent(bellow[0].transform.Find("detector").transform);
                else
                    transform.SetParent(bellow[0].transform);
                parent = bellow[0];
            }
        }
        private void unparent()
        {
            transform.parent = null;
            parent = null;
        }
        private GameObject[] getBellow()
        {
           return check.checkAreaAll(3);
        }
        public void end()
        {
            removeChildern("Player dead(Clone)");
            removeChildern("Player(Clone)");
            Destroy(gameObject);
        }
        private void removeChildern(string name)
        {
            Transform child = transform.Find(name);
            while (child != null)
            {
                child.GetComponent<ParentPlayerToMovable>().unparent();
                child = transform.Find(name);
            }
        }
    }
}