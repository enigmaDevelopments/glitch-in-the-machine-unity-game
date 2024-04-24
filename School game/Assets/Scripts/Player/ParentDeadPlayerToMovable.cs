using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System.Threading;
namespace Player {
    public class ParentDeadPlayerToMovable : ParentPlayerToMovable
    {
        public Transform groundCheck;
        public Transform groundCheck2;
        public override GameObject[] getBellow()
        {
            return PlayerMovment.checkAreaAll(groundCheck, groundCheck2,movables,gameObject);
        }
        public void end()
        {
            removeChildern("Player dead(Clone)");
            removeChildern("Player(Clone)");
            Destroy(gameObject);
        }
        private void removeChildern(string name) {
            Transform child = transform.Find(name);
            while (child != null)
            {
                child.GetComponent<ParentPlayerToMovable>().unparent();
                child = transform.Find(name);
            }
        }
    }
}
