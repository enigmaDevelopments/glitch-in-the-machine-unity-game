using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSprite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        hide(gameObject);
    }
    public static void hide(GameObject gameObject) {
        Destroy(gameObject.GetComponent<SpriteRenderer>());
    }
}
