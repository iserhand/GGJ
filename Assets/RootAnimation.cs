using System.Collections;
using UnityEngine;

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
    public int turnCount = 12;
    void Start()
    {
        StartCoroutine(DrawRoot(0.1f, 2.92f));
    }

    void Update()
    {

    }
    public void drawRoot(float x, float y)
    {
        rootRenderer = GameObject.Find("Root").GetComponent<LineRenderer>();
        Debug.Log(fromx + "" + x);
        if (fromx == x)
        {
            Debug.Log("yESX");
        }
        Debug.Log(fromy + "" + y);
        if (fromy == y)
        {
            Debug.Log("yESy");
        }

        StartCoroutine(DrawRoot(x, y));
    }
    IEnumerator DrawRoot(float x, float y)
    {
        drawing = true;
        if (!firstTime && !CheckValid(x, y))
        {
            Debug.Log("Not a valid move");
            drawing = false;
            yield break;
        }
        if (!firstTime)
            turnCount--;
        GameObject.Find("TourCount").GetComponent<TMPro.TextMeshProUGUI>().text = "Turn Count:" + turnCount.ToString();
        audioSource.PlayOneShot(audioSource.clip, 1.0f);
        float growthFactorx = (x - fromx) / vertexCount;
        float growthFactory = (y - fromy) / vertexCount;
        Vector3 position = new Vector3(fromx, fromy);
        Vector3 newPosition;
        for (int i = 0; i < vertexCount; i++)
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
        fromx = x;
        fromy = y;
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
    void gameOver()
    {
        //Finish the game
    }
}
