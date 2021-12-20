using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct Link
{
    public enum Direction {UNI,BI} //Uni one way direction , BI two way Direction
    public GameObject node1;
    public GameObject node2;
    public Direction dir;
}

public class WPManager : MonoBehaviour
{
    public GameObject[] waypoints;

    public Link[] links;

    public Graph graph = new Graph(); //in graph C# script
    
    // Start is called before the first frame update
    void Start()
    {
        if (waypoints.Length <= 0) return;
        
        foreach (var wp in waypoints)
        {
            graph.AddNode(wp);
        }

        foreach (var link in links)
        {
            graph.AddEdge(link.node1,link.node2); // uni directional = one way direction
            if (link.dir == Link.Direction.BI)
            {
                graph.AddEdge(link.node2,link.node1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        graph.debugDraw(); // to see the edges with red line, if its BI direction there is blue line
    }
}
