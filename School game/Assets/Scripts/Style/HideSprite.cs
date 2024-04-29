using UnityEngine;

namespace Style
{
    public class HideSprite : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            hide(gameObject);
        }
        public static void hide(GameObject gameObject)
        {
            Destroy(gameObject.GetComponent<SpriteRenderer>());
        }
    }
}
