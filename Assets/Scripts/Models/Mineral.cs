using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GGJ
{
    public class Mineral : Obstacle
    {
        public Tile parentTile;
        public ParticleSystem mineralCollectParticle;
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
            mineralCollectParticle.Play();
            GetComponent<Animator>().enabled = false;
            GameManager.Instance.DecreaseRequiredMineralCount();
            parentTile.childObstacle = null;
            parentTile.childObstacleType=0;
        }
    }
}