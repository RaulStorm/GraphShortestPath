public class Graph
{
    private readonly bool isDirected;
    private readonly Dictionary<int, HashSet<int>> adjacencyList;

    public Graph(bool isDirected = false)
    {
        this.isDirected = isDirected;
        adjacencyList = new Dictionary<int, HashSet<int>>();
    }

    public void AddVertex(int vertex)
    {
        if (!adjacencyList.ContainsKey(vertex))
        {
            adjacencyList[vertex] = new HashSet<int>();
        }
    }

    public void AddEdge(int from, int to, bool isDirected)
    {
        if (!adjacencyList.ContainsKey(from) || !adjacencyList.ContainsKey(to))
        {
            throw new ArgumentException("Одна или обе вершины не существуют.");
        }

        adjacencyList[from].Add(to);

        if (!isDirected)
        {
            adjacencyList[to].Add(from);
        }
    }



    public void ClearEdges()
    {
        foreach (var key in adjacencyList.Keys)
        {
            adjacencyList[key].Clear();
        }
    }

    public void RemoveEdge(int from, int to)
    {
        if (adjacencyList.ContainsKey(from))
        {
            adjacencyList[from].Remove(to);
        }
        if (!isDirected && adjacencyList.ContainsKey(to))
        {
            adjacencyList[to].Remove(from);
        }
    }

    public void RemoveVertex(int vertex)
    {
        adjacencyList.Remove(vertex);
        foreach (var neighbors in adjacencyList.Values)
        {
            neighbors.Remove(vertex);
        }
    }

    public List<int> GetNeighbors(int vertex)
    {
        if (adjacencyList.ContainsKey(vertex))
        {
            return adjacencyList[vertex].ToList();
        }
        return new List<int>();
    }
}
