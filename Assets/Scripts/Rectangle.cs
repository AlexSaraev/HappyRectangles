using UnityEngine;

public class Rectangle : MonoBehaviour
{
    // === COMPONENTS ===
    Rigidbody2D rgBody = null;
    LineDrawer lineDrawer = null;

    // === LAYER ===
    int rectangleLayer = -1;

    // === DRAGGING PROPERTIES ===
    float deltaX;
    float deltaY;
    bool isBeingHeld = false;

    Vector2 mousePos { get { return Camera.main.ScreenToWorldPoint(Input.mousePosition); } }

    // === LIFE CYCLES ===
    void Awake()
    {
        rgBody = GetComponent<Rigidbody2D>();
        lineDrawer = GetComponent<LineDrawer>();
        rectangleLayer = LayerMask.NameToLayer("Rectangle");
    }

    void Start()
    {
        SetRandomColor();
    }

    void FixedUpdate()
    {
        if (isBeingHeld)
        {
            var position= new Vector2(mousePos.x - deltaX, mousePos.y - deltaY);
            rgBody.MovePosition(position);
        }
    }

    // === PUBLIC METHODS ===
    public Vector2 GetSize()
    {
        var boxCollider = GetComponent<BoxCollider2D>();
        var width = boxCollider.size.x * transform.lossyScale.x;
        var height = boxCollider.size.y * transform.lossyScale.y;
        return new Vector2(width, height);
    }

    // === PRIVATE METHODS ===
    void SetRandomColor()
    {
        var randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        GetComponent<SpriteRenderer>().color = randomColor;
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            deltaX = mousePos.x - transform.localPosition.x;
            deltaY = mousePos.y - transform.localPosition.y;
            isBeingHeld = true;
        }
    }

    void OnMouseUp()
    {
        isBeingHeld = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var other = collision.gameObject;

        if (other.layer == rectangleLayer)
        {
            InteractWithLineDrawing(other);
        }
    }

    void InteractWithLineDrawing(GameObject other)
    {
        if (isBeingHeld == false) return;

        if (lineDrawer.HasConnection(other))
            lineDrawer.RemoveLine();
        else
            lineDrawer.DrawLine(other);
    }

}
