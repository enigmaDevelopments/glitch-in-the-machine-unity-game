using Player;
using Style;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EndLevel
{
    public class LevelComplete : MonoBehaviour
    {
        public float playerSpeed = .125f;
        public float timer = 100;
        private int _nextLexel;
        private GameObject player;
        private bool firstHalf = true;
        protected int NextLevel
        {
            get { return _nextLexel; }
            set
            {
                if (value < SceneManager.sceneCountInBuildSettings)
                    _nextLexel = value;
                else
                    _nextLexel = SceneManager.GetActiveScene().buildIndex;
            }
        }
        protected virtual void Start()
        {
            NextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        }
        protected void FixedUpdate()
        {
            if (player != null)
            {
                float distance = Mathf.Round(Vector2.Distance(player.transform.position, transform.position));
                if (distance > 2)
                    firstHalf = false;
                player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, playerSpeed * (firstHalf ? -1 : 1));
                if (distance == 0)
                    Destroy(player);
            }
            else if (!firstHalf)
            {
                if (timer != 0)
                    timer -= 1;
                else
                    SceneManager.LoadScene(NextLevel);
            }
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 3)
            {
                player = collision.gameObject;
                player.transform.SetParent(gameObject.transform);
                foreach (GameObject playerI in GameObject.FindGameObjectsWithTag("Player"))
                    if (player != playerI)
                        Destroy(playerI);
                foreach (var script in player.GetComponents<Component>())
                    if (!(script.GetType() == typeof(Transform) || script.GetType() == typeof(SpriteRenderer)))
                        Destroy(script);
                gameObject.GetComponent<RotateRift>().speed *= 100;
            }
            else if (collision.gameObject.layer == 9)
                collision.gameObject.GetComponent<ParentPlayerToMovable>().end();
        }
    }
}
