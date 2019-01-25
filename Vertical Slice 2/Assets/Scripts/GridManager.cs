using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
    
	void Start () {
        FindObjectOfType<CreateNodesFromTilemaps>().generateNodes();
	}
}
