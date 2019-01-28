using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeGrid : MonoBehaviour {

    private void Start()
    {
        GridManager gm = new GridManager();
        gm.GenerateGrid();
    }
}
