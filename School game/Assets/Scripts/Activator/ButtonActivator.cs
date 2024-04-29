using UnityEngine;
using Style;
namespace Activate
{
    public class ButtonActivator : Activator
    {
        public Sprite off;
        public Sprite offDepressed;
        public Sprite on;
        public Sprite onDepressed;
        private SpriteChanger render;
        public bool singlePress = false;
        private bool depressed = false;
        public float timer = 5f;
        private float time = 0;
        private void Start()
        {
            Sprite[] sprites = new Sprite[] { off, offDepressed, on, onDepressed };
            render = new SpriteChanger(sprites, gameObject);
        }
        private void Update()
        {
            if (time > 0)
                time -= Time.deltaTime;
            else if (depressed)
            {
                depressed = !depressed;
                if (!singlePress && _on)
                    render.changeSprite(2);
                else
                    render.changeSprite(0);
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
                    render.changeSprite(1);
                }
                else
                {
                    time = timer;
                    _on = !_on;
                    if (_on)
                        render.changeSprite(1);
                    else
                        render.changeSprite(3);
                }
            }
        }
    }
}
