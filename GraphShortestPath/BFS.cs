using System.Collections.Generic;

public static class BFS
{
    public static List<int> FindShortestPath(Graph graph, int start, int end)
    {
        if (!graph.GetNeighbors(start).Contains(end) && start == end)
        {
            return new List<int> { start };
        }

        Queue<List<int>> queue = new Queue<List<int>>();
        HashSet<int> visited = new HashSet<int>();

        queue.Enqueue(new List<int> { start });
        visited.Add(start);

        while (queue.Count > 0)
        {
            List<int> path = queue.Dequeue();
            int currentNode = path[^1];

            if (currentNode == end)
            {
                return path;
            }

            foreach (int neighbor in graph.GetNeighbors(currentNode))
            {
                if (!visited.Contains(neighbor))
                {
                    List<int> newPath = new List<int>(path) { neighbor };
                    queue.Enqueue(newPath);
                    visited.Add(neighbor);
                }
            }
        }

        return new List<int>();
    }
}