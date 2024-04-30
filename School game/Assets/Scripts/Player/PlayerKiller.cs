using System.Linq;
using UnityEngine;
using Spawner;

namespace Player
{

    public class PlayerKiller : MonoBehaviour
    {
        public GameObject deadPlayer;
        public int killerKyoteTime = 2;
        private Checker check;
        private PlayerSpawner[] spawners;
        private int timer = -1;
        private void Start()
        {
            spawners = (from spawner in GameObject.FindGameObjectsWithTag("Respawn") select spawner.GetComponent<PlayerSpawner>()).ToArray();
            check = gameObject.GetComponent<Checker>();
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
                    if (timer == 0)
                        killPlayer();
                    else
                        timer--;
                }
            }
        }
        public bool isDeathAbovePlayer()
        {
            return check.checkArea(layerMask.death, checks.head) && !check.checkArea(layerMask.ground,checks.head);
        }
        public bool isDeathUnderPlayer()
        {
            return !(check.checkArea(layerMask.death) && check.checkArea());
        }
        public void killPlayer(bool leaveBody = true)
        {
            foreach (PlayerSpawner spawner in spawners)
                spawner.spawn();
            if (leaveBody)
            {
                GameObject dead = Instantiate(deadPlayer, transform.position, transform.rotation);
                PlayerMovment.Flip(dead.transform);
                dead.gameObject.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
            }
            gameObject.GetComponent<ParentPlayerToMovable>().end();
        }
    }
}
