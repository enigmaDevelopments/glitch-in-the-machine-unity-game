using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player
{
    public enum layerMask : byte
    {
        ground = 0,
        death = 1,
        button = 2,
        movables = 3
    }
    public enum checks : byte
    {
        ground = 0,
        button = 1,
        head = 2
    }
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
            layerMasks = new LayerMask[] {groundLayer, deathLayer, buttonLayer, movablesLayer };
            checkers = new Transform[,] {{groundCheck, groundCheck2}, {buttonCheck, buttonCheck2}, {headCheck, headCheck2}};
        }
        public bool checkArea(layerMask layers = layerMask.ground, checks checker = checks.ground)
        {
            return checkAreaAll(layers, checker).Count() != 0;
        }
        public GameObject[] checkAreaAll(layerMask layers = layerMask.ground, checks checker = checks.ground)
        {
            if (checkers == null || layerMasks == null)
                return new GameObject[0];
            return (from col in Physics2D.OverlapAreaAll(checkers[(int)checker, 0].position, checkers[(int)checker, 1].position, layerMasks[(int)layers]) where col.gameObject != gameObject select col.gameObject).ToArray();
        }
    }
}
