using System.Collections.Generic;
using UnityEngine;
namespace GGJ {
    public class Tile : MonoBehaviour
    {
        // su 1, kaya 2, mineral 3, pet 4, jumper 5
        [SerializeField] private Color _baseColor, _offsetColor;
        [SerializeField] private SpriteRenderer _renderer;
        public int childObstacleType;
        public Obstacle childObstacle;
        public List<Tile> neighbourTiles=new List<Tile>();
        public SpriteRenderer linesRenderer;
        public Color lineMoveableColor,lineCannotMoveColor;
        void Init(bool isOffSet)
        {
            _renderer.color = isOffSet ? _offsetColor : _baseColor;

        }
        void OnMouseDown()
        {
            if (GameManager.Instance.rootAnimationSc.drawing || childObstacleType==2 || !GameManager.Instance.isGamePlayable)
            {
                return;
            }
            /*Do your stuff here*/
            Vector3 bar = transform.position;
            GameManager.Instance.rootAnimationSc.StartDrawRoot(bar.x, bar.y, this);

        }
        public void DestroyEffect()
        {
            childObstacle.DoEffect();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Tile"))
            neighbourTiles.Add(collision.GetComponent<Tile>());
        }

        public void ResetPrint()
        {
            linesRenderer.color = lineCannotMoveColor;
        }
        public void PrintToMoveable()
        {
            linesRenderer.color = lineMoveableColor;

        }

    }
}