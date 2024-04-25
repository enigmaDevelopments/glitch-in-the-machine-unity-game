using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
namespace Player {
    public class ParentDeadPlayerToMovable : ParentPlayerToMovable
    {
        public Transform groundCheck;
        public Transform groundCheck2;
        public override GameObject[] getBellow()
        {
            return PlayerMovment.checkAreaAll(groundCheck, groundCheck2,movables,gameObject);
        }
    }
}
