using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace player
{
    public class Checker : MonoBehaviour
    {
        public LayerMask groundLayer;
        public LayerMask deathLayer;
        public LayerMask buttonLayer;
        public LayerMask movablesLayer;
        public Transform groundCheck;
        public Transform groundCheck2;
        public Transform buttonCheck;
        public Transform buttonCheck2;
        public Transform headCheck;
        public Transform headCheck2;
        private LayerMask[] layerMasks;
        private Transform[,] checkers;
        private void Start()
        {
            layerMasks = new LayerMask[] {groundLayer, deathLayer, buttonLayer, movablesLayer};
            checkers = new Transform[,] {{groundCheck, groundCheck2}, {buttonCheck, buttonCheck2}, {headCheck, headCheck2}};
        }
        public bool checkArea(int layers = 0, int checker = 0)
        {
            return checkAreaAll(layers, checker).Count() != 0;
        }
        public GameObject[] checkAreaAll(int layers = 0, int checker = 0)
        {
            if (checkers == null || layerMasks == null)
                return new GameObject[0];
            return (from col in Physics2D.OverlapAreaAll(checkers[checker, 0].position, checkers[checker, 1].position, layerMasks[layers]) where col.gameObject != gameObject select col.gameObject).ToArray();
        }
    }
}
