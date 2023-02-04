using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace GGJ
{
    public class Bottle : Obstacle
    {
        public int decreaseTurnWhenCollected;
        [HideInInspector]public Tile parentTile;
        public ParticleSystem bottleCollectParticle;
        public SpriteRenderer spriteRenderer;
        public TextMeshPro decreaseCountText;
        public GameObject turnParent;
        // Start is called before the first frame update
        void Start()
        {
            parentTile = GetComponentInParent<Tile>();
            decreaseCountText.text = decreaseTurnWhenCollected.ToString();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public override void DoEffect()
        {
            spriteRenderer.enabled = false;
            bottleCollectParticle.Play();
            GetComponentInChildren<Animator>().enabled = false;
            turnParent.SetActive(false);
            GameManager.Instance.ChangeTurnCount(decreaseTurnWhenCollected);
            parentTile.childObstacle = null;
            parentTile.childObstacleType=0;
        }
    }
}