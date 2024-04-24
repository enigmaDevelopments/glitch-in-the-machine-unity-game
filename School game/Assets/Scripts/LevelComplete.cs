using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Player;

public class LevelComplete : MonoBehaviour
{
    public float playerSpeed = .125f;
    public float timer = 100;
    private int nextLexel;
    private GameObject player;
    private bool firstHalf = true;
    private void Start()
    {
        nextLexel = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void FixedUpdate()
    {
        if (player != null) {
            float distance = Mathf.Round(Vector2.Distance(player.transform.position, transform.position));
            if (distance > 2)
                firstHalf = false;
            player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, playerSpeed * (firstHalf ? -1:1));
            if (distance == 0)
                Destroy(player);
        }else if (!firstHalf) {
            if (timer != 0)
                timer -= 1;
            else
                SceneManager.LoadScene(nextLexel);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            player = collision.gameObject;
            player.transform.SetParent(gameObject.transform);
            collision.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(player.GetComponent<Rigidbody2D>());
            Destroy(player.GetComponent<PlayerMovment>());
            Destroy(player.GetComponent<PlayerKiller>());
            Destroy(player.GetComponent<ParentPlayerToMovable>());
            gameObject.GetComponent<RotateRift>().speed *= 100;
        }
        else if (collision.gameObject.layer == 9)
            collision.gameObject.GetComponent<ParentDeadPlayerToMovable>().end();
    }
}
