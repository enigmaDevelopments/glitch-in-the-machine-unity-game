using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player
{
    public class ParentPlayerToMovable : MonoBehaviour
    {
        public LayerMask movables;
        protected GameObject parent;
        private PlayerMovment movment;
        private bool wasRight;
        private void Start()
        {
            movment = GetComponent<PlayerMovment>();
        }
        protected void Update()
        {
            if (parent == null)
            {
                parentToBellow();
                if (parent != null && parent.layer == 3)
                    wasRight = parent.GetComponent<PlayerMovment>().FacingRight;
            }
            else if (!getBellow().Contains(parent))
                unparent();
            else if (parent.layer == 3 && wasRight != parent.GetComponent<PlayerMovment>().FacingRight)
            {
                wasRight = !wasRight;
                PlayerMovment.Flip(transform);
            }

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
        public void unparent()
        {
            transform.parent = null;
            parent = null;
        }
        public virtual GameObject[] getBellow()
        {
           return movment.checkGroundAll(movables);
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