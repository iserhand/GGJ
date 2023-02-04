using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GGJ
{
    public class Worm : Obstacle
    {
        public Tile parentTile;
        public ParticleSystem wormDeathParticle;
        public SpriteRenderer spriteRenderer;
        public Sprite hitSprite;
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
            wormDeathParticle.Play();
            spriteRenderer.sprite = hitSprite;
            GameManager.Instance.LoseGame();
            parentTile.childObstacle = null;
            parentTile.childObstacleType=0;
        }
    }
}