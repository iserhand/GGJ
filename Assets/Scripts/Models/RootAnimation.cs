using System.Collections;
using UnityEngine;
namespace GGJ
{
    public class RootAnimation : MonoBehaviour
    {
        private int[,] grids = new int[5, 7];
        [SerializeField] AudioSource audioSource;
        public int vertexCount = 60;
        public LineRenderer rootRenderer;
        private float fromx = 0.099f;
        private float fromy = 4.1f;
        private bool firstTime = true;
        private float prevx = 0;
        private float prevy = 0;
        public bool drawing = false;
        void Start()
        {
            StartCoroutine(DrawRoot(0.1f, 2.92f));
        }

        void Update()
        {

        }
        public void StartDrawRoot(float targetX, float targetY, Tile targetTile)
        {
            rootRenderer = GameManager.Instance.rootAnimationSc.GetComponent<LineRenderer>();
            if (CheckValid(targetX, targetY))
            {
                GameManager.Instance.currentTile = targetTile;
                StartCoroutine(DrawRoot(targetX, targetY));
            }
        }
        IEnumerator DrawRoot(float targetX, float targetY)
        {
            if (!firstTime)
                GameManager.Instance.turnCount--;
            drawing = true;
            UIManager.Instance.UpdateTourCountText();
            audioSource.PlayOneShot(audioSource.clip, 1.0f);
            float growthFactorx = (targetX - fromx) / vertexCount;
            float growthFactory = (targetY - fromy) / vertexCount;
            Vector3 position = new Vector3(fromx, fromy);
            Vector3 newPosition;
            for (int i = 0; i < vertexCount / 2; i++)
            {
                yield return new WaitForSecondsRealtime(0.01f);
                position.x += growthFactorx;
                position.y += growthFactory;
                rootRenderer.positionCount++;
                newPosition = new Vector3(position.x + Random.Range(-0.05f, 0.05f), position.y + Random.Range(-0.05f, 0.05f));
                position = Vector3.Lerp(position, newPosition, i);
                rootRenderer.SetPosition(rootRenderer.positionCount - 1, position);
            }
            if (!firstTime  && CheckIsThereObstacle())
            {
                DoObstacleEffect();
            }
            for (int i = vertexCount / 2; i < vertexCount; i++)
            {
                yield return new WaitForSecondsRealtime(0.01f);
                position.x += growthFactorx;
                position.y += growthFactory;
                rootRenderer.positionCount++;
                newPosition = new Vector3(position.x + Random.Range(-0.05f, 0.05f), position.y + Random.Range(-0.05f, 0.05f));
                position = Vector3.Lerp(position, newPosition, i);
                rootRenderer.SetPosition(rootRenderer.positionCount - 1, position);
            }
            prevx = fromx;
            prevy = fromy;
            fromx = targetX;
            fromy = targetY;
            drawing = false;

            firstTime = false;
            yield return null;
        }

        bool CheckValid(float x, float y)
        {

            //TODO: Check validity
            if (Mathf.Abs(fromx - x) + Mathf.Abs(fromy - y) < 0.2)
            {

                Debug.Log("Trying to go to the same grid as the current one");
                return false;
            }

            if ((prevx != 0 && prevy != 0) && (Mathf.Abs(prevx - x) + Mathf.Abs(prevy - y) < 1))
            {
                //Trying to go to the same direction they came from
                Debug.Log("Trying to go to the same grid as before");
                return false;
            }
            if (Mathf.Abs(fromx - x) + Mathf.Abs(fromy - y) > 2.1)
            {
                Debug.Log("Trying to make multiple moves");
                return false;
            }

            return true;
        }
        private bool CheckIsThereObstacle()
        {
            if (GameManager.Instance.currentTile.childObstacleType > 0)
                return true;
            return false;
        }
        private void DoObstacleEffect()
        {
            Tile tileCs = GameManager.Instance.currentTile;
            switch (tileCs.childObstacleType)
            {
                case 1:
                    tileCs.DestroyEffect();
                    break;

            }
        }
    }
}