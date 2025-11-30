using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject target;
    private Vector3 targetVector;
    public float cameraMoveSpeed;

    public BoxCollider2D bound;
    private Vector2 minBound;
    private Vector2 maxBound;

    private float halfHeight;
    private float halfWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
        SetBound(bound);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            targetVector = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, targetVector, cameraMoveSpeed * Time.deltaTime);


            if (bound != null)
            {
                float clampedX = Mathf.Clamp(this.transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth);
                float clampedY = Mathf.Clamp(this.transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);
                this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);
            }
        }
    }

    public void SetBound(BoxCollider2D _bound)
    {
        bound = _bound;
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;
    }
}
