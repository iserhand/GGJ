using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace GGJ
{
    public class Water : Obstacle
    {
        public int increaseTurnWhenCollected;
        public Tile parentTile;
        public ParticleSystem waterCollectParticle;
        public SpriteRenderer spriteRenderer;
        public GameObject turnParent;
        public TextMeshPro increaseCountText;
        // Start is called before the first frame update
        void Start()
        {
            parentTile = GetComponentInParent<Tile>();
            increaseCountText.text = increaseTurnWhenCollected.ToString("+0;-#");
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
            turnParent.SetActive(false);
            GameManager.Instance.ChangeTurnCount(increaseTurnWhenCollected);
            parentTile.childObstacle = null;
            parentTile.childObstacleType=0;
        }
    }
}