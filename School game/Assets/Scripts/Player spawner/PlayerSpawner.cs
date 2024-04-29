using UnityEngine;

namespace Spawner
{
    public class PlayerSpawner : MonoBehaviour
    {
        public GameObject player;
        // Start is called before the first frame update
        void Start()
        {
            spawn();
        }
        public virtual void spawn()
        {
            Instantiate(player, transform.position, transform.rotation);
        }
    }
}
