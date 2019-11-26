using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGeneration : MonoBehaviour
{
    public Constants.FloorType floorType;
    [Range(1, 100)]
    public int tileX = 1;
    [Range(1,100)]
    public int tileZ = 1;
    public bool autoUpdate;

    public GameObject floorWood, floorMetal, floorGrass, floorStone;

    //public enum floor_typing {Normal,Grass,Sand};

    void Start()
    {
        GenerateTiles();
    }

    public void GenerateTiles()
    {
        ClearChild();
        GameObject flooring;

        if (floorType == Constants.FloorType.Wood)
        {
            flooring = Instantiate(floorWood, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
            flooring.transform.localScale = new Vector3(0.1f * tileX, 0.1f, 0.1f * tileZ);
        }
        else if (floorType == Constants.FloorType.Metal)
        {
            flooring = Instantiate(floorMetal, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
            flooring.transform.localScale = new Vector3(0.1f * tileX, 0.1f, 0.1f * tileZ);
        }
        else if (floorType == Constants.FloorType.Grass)
        {
            flooring = Instantiate(floorGrass, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
            flooring.transform.localScale = new Vector3(0.1f * tileX, 0.1f, 0.1f * tileZ);
        }
        else
        {
            flooring = Instantiate(floorStone, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
            flooring.transform.localScale = new Vector3(0.1f * tileX, 0.1f, 0.1f * tileZ);
        }




        //float start_x = ((1f * tileX) / 2 - (1f / 2)) * -1;
        //for (int x = 0; x < tileX; x++)
        //{
        //    for (int z = 0; z < tileZ; z++)
        //    {
        //        //GameObject Flooring = Instantiate(floor, new Vector3(start_x + (1f * x), 0f, z), Quaternion.identity, transform);
        //        //Flooring.transform.localScale = new Vector3(0.1f * x, 0.1f, 0.1f * z);
        //    }
        //}
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
