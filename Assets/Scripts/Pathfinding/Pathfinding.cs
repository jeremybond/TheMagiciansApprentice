using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class Pathfinding : MonoBehaviour
{

	public Transform seeker;
	public Transform target;

	private Grid grid;

	protected void Awake ()
	{
		grid = GetComponent<Grid> ();
	}

	protected void Update ()
	{
		//if (Input.GetKeyDown (KeyCode.Space))
		//{
		FindPath (seeker.position, target.position);
		//}
	}

	private void FindPath (Vector3 startPos, Vector3 targetPos)
	{
		Stopwatch sw = new Stopwatch ();
		sw.Start ();
		Node startNode = grid.NodeFromWorldPoint (startPos);
		Node targetNode = grid.NodeFromWorldPoint (targetPos);

		Heap<Node> openSet = new Heap<Node> (grid.Maxsize);
		HashSet<Node> closedSet = new HashSet<Node> ();
		openSet.Add (startNode);

		while (openSet.Count > 0)
		{
			Node currentNode = openSet.RemoveFirst ();
			closedSet.Add (currentNode);

			if (currentNode == targetNode)
			{
				sw.Stop ();
				print ("Path found: " + sw.ElapsedMilliseconds + " ms");
				RetracePath (startNode, targetNode);
				return;
			}


			foreach (Node neighbour in grid.GetNeighbours (currentNode))
			{
				if (!neighbour.walkable || closedSet.Contains (neighbour))
				{
					continue;
				}

				int newMovementostToNeighbour = currentNode.gCost + GetDistance (currentNode, neighbour);
				if (newMovementostToNeighbour < neighbour.gCost || !openSet.Contains (neighbour))
				{
					neighbour.gCost = newMovementostToNeighbour;
					neighbour.hCost = GetDistance (neighbour, targetNode);
					neighbour.parent = currentNode;

					if (!openSet.Contains (neighbour))
					{
						openSet.Add (neighbour);
					}
					else
					{
						openSet.UpdateItem (neighbour);
					}
				}
			}
		}
	}

	private void RetracePath (Node startNode, Node endNode)
	{
		List<Node> path = new List<Node> ();
		Node currentNode = endNode;

		while (currentNode != startNode)
		{
			path.Add (currentNode);
			currentNode = currentNode.parent;
		}
		path.Reverse ();

		grid.path = path;
	}

	private int GetDistance (Node nodeA, Node nodeB)
	{
		int dstX = Mathf.Abs (nodeA.gridX - nodeB.gridX);
		int dstY = Mathf.Abs (nodeA.gridY - nodeB.gridY);

		if (dstX > dstY)
		{
			return 14 * dstY + 10 * (dstX - dstY);
		}
		return 14 * dstX + 10 * (dstY - dstX);
	}
}
