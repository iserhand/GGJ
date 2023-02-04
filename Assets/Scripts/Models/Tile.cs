using UnityEngine;
namespace GGJ {
    public class Tile : MonoBehaviour
    {

        [SerializeField] private Color _baseColor, _offsetColor;
        [SerializeField] private SpriteRenderer _renderer;
        public int childObstacleType;
        public Obstacle childObstacle;

        void Init(bool isOffSet)
        {
            _renderer.color = isOffSet ? _offsetColor : _baseColor;

        }
        void OnMouseDown()
        {
            if (GameManager.Instance.rootAnimationSc.drawing)
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

    }
}