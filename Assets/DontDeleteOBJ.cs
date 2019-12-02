using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDeleteOBJ : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
