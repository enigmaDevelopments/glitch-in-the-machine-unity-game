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
                parent = bellow[0];
                if (parent.layer == 13)
                    parentToChild("detector");
                else if (parent.layer == 3 || parent.layer == 9)
                    parentToChild("ParentPoint");
                else
                    transform.SetParent(parent.transform);
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
        private void parentToChild(string name)
        {
            transform.SetParent(parent.transform.Find(name).transform);
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