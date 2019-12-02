using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGeneration : MonoBehaviour
{
    [Range(1, 2)]
    public int wallNumber = 1;
    [Range(-200, 200)]
    public int wallDistanceX = 0;
    [Range(-200, 200)]
    public int wallDistanceZ = 0;
    [Range(1, 200)]
    public int tileX = 1;
    [Range(1, 10)]
    public int tileY = 4;
    [Range(1, 200)]
    public int tileZ = 1;

    public bool autoUpdate;
    public bool wallEnabled;

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
            walling = Instantiate(Wall, new Vector3(transform.position.x - (0.05f * wallDistanceX), transform.position.y + 2f, transform.position.z - (0.05f * wallDistanceZ)), Quaternion.identity, transform);
            walling.transform.localScale = new Vector3(0.05f * tileX, 1f * tileY, 0.05f * tileZ);
        }
        else
        {
            walling = Instantiate(Wall, new Vector3(transform.position.x - (0.05f * wallDistanceX), transform.position.y + 2f, transform.position.z - (0.05f * wallDistanceZ)), Quaternion.identity, transform);
            walling.transform.localScale = new Vector3(0.05f * tileX, 1f * tileY, 0.05f * tileZ);

            walling = Instantiate(Wall, new Vector3(transform.position.x + (0.05f * wallDistanceX), transform.position.y + 2f, transform.position.z + (0.05f * wallDistanceZ)), Quaternion.identity, transform);
            walling.transform.localScale = new Vector3(0.05f * tileX, 1f * tileY, 0.05f * tileZ);
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

    public void SetWallActive(bool active)
    {
        wallEnabled = active;

        if (!wallEnabled)
        {
            ClearChild();
        }
    }


}
