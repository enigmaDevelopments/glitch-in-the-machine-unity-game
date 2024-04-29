using UnityEngine;
namespace Activate
{
    public class Activator : MonoBehaviour
    {
        protected bool _on;
        public static implicit operator bool(Activator a)
        {
            return a._on;
        }
    }
}