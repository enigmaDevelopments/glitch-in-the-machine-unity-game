using Player;
using UnityEngine;

namespace Feild
{
    public class FeildCollition : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 9)
                collision.gameObject.GetComponent<ParentPlayerToMovable>().end();
        }
    }
}
