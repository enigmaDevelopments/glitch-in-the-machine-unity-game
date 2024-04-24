using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

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
