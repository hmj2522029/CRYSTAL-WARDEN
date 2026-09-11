using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when something get into the alta, make the runes glow
namespace Cainos.PixelArtTopDown_Basic
{

    public class PropsAltar : MonoBehaviour
    {
        public List<SpriteRenderer> runes;
        public float lerpSpeed;

        private Color curColor;
		private float timer;

        private void Update()
        {

			timer += Time.deltaTime * lerpSpeed;
			float color = Mathf.Abs(Mathf.Sin(timer));

			curColor = new Color(color, color, color, 1f);

            foreach (var r in runes)
            {
                r.color = curColor;
            }
        }
    }
}
