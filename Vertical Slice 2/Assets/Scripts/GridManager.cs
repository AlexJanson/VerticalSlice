using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour {

    [HideInInspector]
    public NodeData[,] map;
    public Grid grid;
    public Tilemap floor;
    public List<Tilemap> obstacleLayers;

    public GameObject nodePrefab;
    private List<Node> path;

    private void Awake()
    {
        GenerateGrid();
    }

    public void GenerateGrid() {
        map = CreateNodesFromTilemaps.CreateNodes(grid, floor, obstacleLayers, transform);

        SpawnNodes(map, false);
        AStarPath.SaveMap(map);

        path = AStarPath.FindPath(new Vector2(-7.9f, -.2f), new Vector2(-.1f, -.1f));
        StartCoroutine(DelayedPath());
	}

    IEnumerator DelayedPath()
    {
        yield return new WaitForSeconds(3f);
        //path = AStarPath.FindPath(new Vector2(6.1237123f, 6.6123f), new Vector2(17.99f, 3f), map);
        yield return null;
    }

    void SpawnNodes(NodeData[,] _map, bool showSprite)
    {
        foreach (NodeData n in _map) {
            GameObject node = Instantiate(nodePrefab, n.position, Quaternion.identity);
            node.name = n.name;
            SpriteRenderer sr = node.GetComponent<SpriteRenderer>();
            if (!n.walkable) {
                sr.color = Color.red;
            }
            sr.enabled = showSprite;
            node.transform.parent = n.parent;
        }
    }

    private void OnDrawGizmos()
    {
        if (path != null) {
            //Gizmos.DrawSphere(map[7, 10].position, 0.1f);
            Gizmos.color = Color.red;
            foreach (Node n in path) {
                Gizmos.DrawSphere(new Vector2(n.position.x - 11.5f, n.position.y - 5.5f), 0.1f);
            }
        }
    }
}
