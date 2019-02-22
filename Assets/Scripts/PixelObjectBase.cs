using UnityEngine;

public class PixelObjectBase : MonoBehaviour
{
    private Vector3 _cashPosition;

    private void Start()
    {
        _cashPosition = transform.localPosition;
    }

    private void Update()
    {
    }

    public void LastUpdate()
    {
        _cashPosition = transform.localPosition;
        transform.localPosition = new Vector3(
            Mathf.RoundToInt(_cashPosition.x),
            Mathf.RoundToInt(_cashPosition.y),
            Mathf.RoundToInt(_cashPosition.z)
        );
    }

    public void OnRenderObject()
    {
        transform.localPosition = _cashPosition;
    }
}