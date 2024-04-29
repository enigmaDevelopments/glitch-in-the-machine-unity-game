using UnityEngine;

namespace Style
{
    public class InverseScale : MonoBehaviour
    {
        public Transform parent;
        void Update()
        {
            transform.localScale = new Vector2(Mathf.Pow(parent.transform.localScale.x, -1), Mathf.Pow(parent.transform.localScale.y, -1));
        }
    }
}
