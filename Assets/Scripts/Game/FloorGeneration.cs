using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGeneration : MonoBehaviour
{
    [Range(1, 100)]
    public int tileX = 1;
    [Range(1,100)]
    public int tileY = 1;

    public GameObject floor;

    public enum floor_typing {Normal,Grass,Sand};

    void Start()
    {
        GenerateTiles();
    }

    private void GenerateTiles()
    {
        float start_x = ((1f * tileX) / 2 - (1f / 2)) * -1;
        for (int x = 0; x < tileX; x++)
        {
            for (int y = 0; y < tileY; y++)
            {
                Instantiate(floor, new Vector3(start_x + (1f * x), 0f, y), Quaternion.identity);
            }
        }
    }
}
