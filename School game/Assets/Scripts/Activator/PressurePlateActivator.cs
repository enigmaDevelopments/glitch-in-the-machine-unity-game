using UnityEngine;
namespace Activate
{
    public class PressurePlateActivator : Activator
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            _on = true;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            _on = false;
        }
    }
}