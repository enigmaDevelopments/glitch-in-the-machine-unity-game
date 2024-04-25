using Style;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawner
{
    public class Respawner : PlayerSpawner
    {
        public Sprite on;
        private bool active = false;
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 3)
            {
                active = true;
                SpriteChanger.changeSprite(on,gameObject);
            }
        }
        override public void spawn()
        {
            if (active)
                base.spawn();
        }
    }
}
