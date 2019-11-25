using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGeneration : MonoBehaviour
{
    [Range(1, 2)]
    public int wallNumber = 1;
    [Range(0, 100)]
    public int wallDistanceX = 0;
    [Range(0, 100)]
    public int wallDistanceZ = 0;
    [Range(1, 100)]
    public int tileX = 1;
    [Range(1, 10)]
    public int tileY = 4;
    [Range(1, 100)]
    public int tileZ = 1;

    public bool autoUpdate;

    public GameObject Wall;

    void Start()
    {
        GenerateWall();
    }

    public void GenerateWall()
    {
        ClearChild();
        GameObject walling;

        if (wallNumber == 1)
        {
            walling = Instantiate(Wall, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), Quaternion.identity, transform);
            walling.transform.localScale = new Vector3(0.1f * tileX, 1f * tileY, 0.1f * tileZ);
        }
        else
        {
            walling = Instantiate(Wall, new Vector3(transform.position.x - (0.1f * wallDistanceX), transform.position.y + 2f, transform.position.z - (0.1f * wallDistanceZ)), Quaternion.identity, transform);
            walling.transform.localScale = new Vector3(0.1f * tileX, 1f * tileY, 0.1f * tileZ);

            walling = Instantiate(Wall, new Vector3(transform.position.x + (0.1f * wallDistanceX), transform.position.y + 2f, transform.position.z + (0.1f * wallDistanceZ)), Quaternion.identity, transform);
            walling.transform.localScale = new Vector3(0.1f * tileX, 1f * tileY, 0.1f * tileZ);
        }
    }

    public void ClearChild()
    {
        List<Transform> child = new List<Transform>(transform.GetComponentsInChildren<Transform>());

        for (int i = 1; i < child.Count; i++)
        {
            DestroyImmediate(child[i].gameObject);
        }
    }
}
