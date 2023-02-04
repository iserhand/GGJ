using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GGJ
{
    public class Water : Obstacle
    {
        public Tile parentTile;
        public ParticleSystem waterCollectParticle;
        public SpriteRenderer spriteRenderer;
        // Start is called before the first frame update
        void Start()
        {
            parentTile = GetComponentInParent<Tile>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public override void DoEffect()
        {
            spriteRenderer.enabled = false;
            waterCollectParticle.Play();
            GetComponent<Animator>().enabled = false;
            GameManager.Instance.ChangeTurnCount(1);
            parentTile.childObstacle = null;
            parentTile.childObstacleType=0;
        }
    }
}