using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class CreateNodesFromTilemaps
{
    public static NodeData[,] CreateNodes(Grid _gridbase, Tilemap _floor,
        List<Tilemap> _obstacleLayers, Transform parent)
    {
        Grid gridBase = _gridbase;
        Tilemap floor = _floor;
        List<Tilemap> obstacleLayers = _obstacleLayers;
        List<NodeData> nodes = new List<NodeData>();

        int startX = -250, startY = -250, finishX = 250, finishY = 250;
        int gridSizeX = 0, gridSizeY = 0;

        int gridX = 0, gridY = 0;

        bool foundTile = false;
        
        for (int x = startX; x < finishX; x++) {
            for (int y = startY; y < finishY; y++) {
                TileBase tb = floor.GetTile(new Vector3Int(x, y, 0));

                if (tb != null) {
                    bool foundObstacle = false;

                    foreach (Tilemap t in obstacleLayers) {
                        TileBase tb2 = t.GetTile(new Vector3Int(x, y, 0));

                        if (tb2 != null) {
                            foundObstacle = true;
                        }
                    }

                    if (!foundObstacle) {
                        NodeData node = new NodeData("Node " + gridX.ToString() + ", " + gridY.ToString(),
                            new Vector3(
                                x + 0.5f + gridBase.transform.position.x,
                                y + 0.5f + gridBase.transform.position.y,
                                0f),
                            parent, true);

                        nodes.Add(node);
                        foundTile = true;

                    } else {
                        NodeData node = new NodeData("(Unwalkable) Node " + gridX.ToString() + ", " + gridY.ToString(),
                            new Vector3(
                                x + 0.5f + gridBase.transform.position.x,
                                y + 0.5f + gridBase.transform.position.y,
                                0f),
                            parent, false);

                        nodes.Add(node);
                        foundTile = true;
                    }
                    gridY++;

                    if (gridX > gridSizeX) {
                        gridSizeX = gridX;
                    }
                    if (gridY > gridSizeY) {
                        gridSizeY = gridY;
                    }
                }
            }
            if (foundTile == true) {
                gridX++;
                gridY = 0;
                foundTile = false;
            }
        }

        /*foreach(GameObject item in nodes) {
            Debug.Log(item);
        }*/

        NodeData[,] map = new NodeData[gridSizeX + 1, gridSizeY];
        foreach(NodeData n in nodes) {
            Vector3 nodePos = new Vector3(Mathf.Floor(n.position.x + 12), Mathf.Floor(n.position.y + 6), 0f);
            map[(int)nodePos.x, (int)nodePos.y] = n;
        }
        
        return map;
    }
}

[System.Serializable]
public struct NodeData
{
    public string name;
    public Vector3 position;
    public Transform parent;
    public bool walkable;

    public NodeData(string _name, Vector3 _position, Transform _parent, bool _walkable)
    {
        name = _name;
        position = _position;
        parent = _parent;
        walkable = _walkable;
    }
}