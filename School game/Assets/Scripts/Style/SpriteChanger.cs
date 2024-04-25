using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Style
{
    public class SpriteChanger
    {
        private Sprite[] sprites;
        private GameObject render;
        public SpriteChanger(Sprite[] sprites, GameObject render)
        {
            this.sprites = sprites;
            this.render = render;
        }
        public void changeSprite(int sprite)
        {
            changeSprite(sprites[sprite], render);
        }
        public static void changeSprite(Sprite sprite, GameObject render)
        {
            render.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}
