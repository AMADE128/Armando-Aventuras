using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public List<GameObject> list = new List<GameObject>();
    public GameObject basicRoom;
    public int roomQuantity;
    [Range(5, 100)]
    public int creationRadius;
    public int tileSize;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < roomQuantity; i++)
        {
            Vector2 pos = getRandomPointInCircle();
            list.Add(Instantiate(basicRoom, new Vector3(pos.x, 0, pos.y), Quaternion.identity));
        }

        for (int i = 0; i < roomQuantity; i++)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector2 getRandomPointInCircle()
    {
        Vector2 point = new Vector2();
        float t = 2 * Mathf.PI * Random.value;
        float u = Random.value + Random.value;
        float r;

        if (u > 1)
            r = 2 - u;
        else
            r = u;

        point.x = roundm(creationRadius * r * Mathf.Cos(t), tileSize);
        point.y = roundm(creationRadius * r * Mathf.Sin(t), tileSize);

        return point;
    }

    int roundm(float n, int m)
    {
        return (int)Mathf.Floor(((n + m - 1) / m) * m);
    }
}
