using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AStarPath
{
    static NodeData[,] map;

    private static int NodeSorter(Node n0, Node n1)
    {
        if (n1.fCost < n0.fCost) return 1;
        if (n1.fCost > n0.fCost) return -1;
        return 0;
    }

    public static void SaveMap(NodeData[,] _map)
    {
        map = _map;
    }

    public static List<Node> FindPath(Vector2 start, Vector2 goal)
    {
        if (map != null) {
            goal = new Vector2(Mathf.Round(goal.x), Mathf.Round(goal.y));
            List<Node> openList = new List<Node>();
            List<Node> closedList = new List<Node>();
            Node current = new Node(start, null, 0, GetDistance(start, goal));
            openList.Add(current);
            while (openList.Count > 0) {
                openList.Sort(NodeSorter);
                current = openList[0];
                if (current.position.Equals(goal)) {
                    List<Node> path = new List<Node>();
                    while (current.parent != null) {
                        path.Add(current);
                        current = current.parent;
                    }
                    openList.Clear();
                    closedList.Clear();
                    return path;
                }
                openList.Remove(current);
                closedList.Add(current);
                for (int i = 0; i < 9; i++) {
                    if (i == 0 || i == 2 || i == 4 || i == 6 || i == 8) continue;
                    int x = (int)current.position.x;
                    int y = (int)current.position.y;
                    int xi = (i % 3 - 1);
                    int yi = (i / 3 - 1);
                    if ((x + xi) >= 0 && (x + xi) < map.GetLength(0) && (y + yi) >= 0 && (y + yi) < map.GetLength(1)) {
                        NodeData at = map[x + xi, y + yi];
                        if (!at.walkable) continue;
                        Vector2 a = new Vector2(x + xi, y + yi);
                        float gCost = current.gCost + GetDistance(current.position, a);
                        float hCost = GetDistance(a, goal);
                        Node node = new Node(a, current, gCost, hCost);
                        if (VecInList(closedList, a) && gCost >= node.gCost) continue;
                        if (!VecInList(openList, a) || gCost < node.gCost) openList.Add(node);
                    }
                }
            }

            closedList.Clear();
            return null;
        }
        return null;
    }

    private static bool VecInList(List<Node> list, Vector2 v)
    {
        foreach(Node n in list) {
            if (n.position.Equals(v)) return true;
        }
        return false;
    }

    private static float GetDistance(Vector2 tile, Vector2 goal)
    {
        float dx = tile.x - goal.x;
        float dy = tile.y - goal.y;
        return Mathf.Sqrt(dx * dx + dy * dy);
    }

    public static Vector2 GetTilePosition(Vector2 entityPosition)
    {
        if (map != null) {
            float smallestDistance = Mathf.Infinity;
            NodeData node = new NodeData();
            foreach (NodeData n in map) {
                float distance = Vector2.Distance(n.position, entityPosition);
                if (distance < smallestDistance) {
                    smallestDistance = distance;
                    node = n;
                }
            }

            return new Vector2(node.position.x + 11.5f, node.position.y + 5.5f);
        }
        return Vector2.zero;
    }

    public static Vector2 GetTileWorldPosition(Vector2 tilePosition)
    {
        return map[(int)tilePosition.x, (int)tilePosition.y].position;
    }
}
