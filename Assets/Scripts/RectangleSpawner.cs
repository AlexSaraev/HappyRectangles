using UnityEngine;

public class RectangleSpawner : MonoBehaviour
{
    // === PROPERTIES ===
    [SerializeField] GameObject rectanglePrefab = null;

    // === LIFE CYCLES ===
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var hit = Physics2D.BoxCast(spawnPosition, GetRectangleSize(), 0, Vector2.zero);
            if (hit.collider != null) return;

            SpawnRectangle(spawnPosition);
        }
    }

    // === PRIVATE METHODS ===
    void SpawnRectangle(Vector2 position)
    {
        Instantiate(rectanglePrefab, position, Quaternion.identity);
    }

    Vector2 GetRectangleSize()
    {
        return rectanglePrefab.GetComponent<Rectangle>().GetSize();
    }

}
