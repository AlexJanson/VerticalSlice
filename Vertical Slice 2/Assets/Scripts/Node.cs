using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Node {

    public float gCost;
    public float hCost;
    public Vector2 position;
    public bool walkable = true;
    public List<Node> myNeighbours;
    public Node parent;

    public Node(Vector2 _position, Node _parent, float _gCost, float _hCost)
    {
        position = _position;
        parent = _parent;
        gCost = _gCost;
        hCost = _hCost;
    }

    public float fCost
    {
        get {
            return gCost + hCost;
        }
    }

    public void SetPosition(Vector2 _position)
    {
        position = _position;
    }
}
