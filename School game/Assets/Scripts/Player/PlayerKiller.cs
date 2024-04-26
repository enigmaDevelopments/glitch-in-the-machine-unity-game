using Newtonsoft.Json.Converters;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;


namespace Player
{
    using Spawner;
    using UnityEditor.Tilemaps;

    public class PlayerKiller : MonoBehaviour
    {
        public GameObject deadPlayer;
        private PlayerMovment movmentScrpit;
        public Transform headCheck;
        public Transform headCheck2;
        public LayerMask deathLayer;
        public int killerKyoteTime = 2;
        private int timer = -1;
        private void Start()
        {
            movmentScrpit = gameObject.GetComponent<PlayerMovment>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == 7)
            {
                if (isDeathAbovePlayer())
                    killPlayer();
                else
                    timer = killerKyoteTime;
            }
            else if (collision.gameObject.layer == 31)
                killPlayer(false);
        }
        private void OnCollisionExit2D(Collision2D collision)
        {

            if (collision.gameObject.layer == 7)
                timer = -1;
        }
        private void FixedUpdate()
        {
            if (timer != -1)
            {
                if (isDeathUnderPlayer())
                {
                    if (!movmentScrpit.trueGrounded())
                        deathTimer();
                }
                else
                    deathTimer();
            }
        }
        private void deathTimer()
        {
            if (timer == 0)
                killPlayer();
            else
                timer--;
        }
        public bool isDeathAbovePlayer()
        {
            return PlayerMovment.checkArea(headCheck, headCheck2, deathLayer,gameObject)  && !PlayerMovment.checkArea(headCheck,headCheck2,movmentScrpit.groundLayer,gameObject);
        }
        public bool isDeathUnderPlayer()
        {
            return movmentScrpit.checkGround(deathLayer);
        }
        public void killPlayer(bool leaveBody = true)
        {
            PlayerSpawner[] spawners = (from spawner in GameObject.FindGameObjectsWithTag("Respawn") select spawner.GetComponent<PlayerSpawner>()).ToArray();
            foreach (PlayerSpawner spawner in spawners)
                spawner.spawn();
            if (leaveBody)
            {
                GameObject dead = Instantiate(deadPlayer, transform.position, transform.rotation);
                PlayerMovment.Flip(dead);
                dead.gameObject.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
            }
            gameObject.GetComponent<ParentPlayerToMovable>().end();
        }
    }
}
