using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using UnityEngine;
public class ButtonActivator : Activator
{
    public Sprite off;
    public Sprite offDepressed;
    public Sprite on;
    public Sprite onDepressed;
    private SpriteRenderer render;
    public bool singlePress = false;
    private bool depressed = false;
    public float timer = 5f;
    private float time = 0;
    private void Start()
    {
        render = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (time > 0)
            time -= Time.deltaTime;        
        else if (depressed)
        {
            depressed = !depressed;
            if (!singlePress && _on)
                render.sprite = on;
            else
                render.sprite = off;
            if (singlePress)
                _on = false;
        }
    }
    public void press()
    {
        if (depressed)
            time = timer;
        else
        {
            depressed = true;
            if (singlePress)
            {
                _on = true;
                time = timer;
                render.sprite = offDepressed;
            }
            else
            {
                time = timer;
                _on = !_on;
                if (_on)
                {
                    render.sprite = offDepressed;
                }
                else
                {
                    render.sprite = onDepressed;
                }
            }
        }
    }
}
