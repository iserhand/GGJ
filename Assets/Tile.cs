using UnityEngine;

public class Tile : MonoBehaviour
{

    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;

    void Init(bool isOffSet)
    {
        _renderer.color = isOffSet ? _offsetColor : _baseColor;

    }
    void OnMouseDown()
    {
        if (GameObject.Find("Root").GetComponent<RootAnimation>().drawing)
        {
            return;
        }
        /*Do your stuff here*/
        Vector3 bar = transform.position;
        GameObject.Find("Root").GetComponent<RootAnimation>().drawRoot(bar.x, bar.y);

    }



}
