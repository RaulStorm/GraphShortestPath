using System;
using System.Collections.Generic;
using System.Linq;

public class Graph
{
    private readonly bool isDirected;
    private readonly Dictionary<int, HashSet<int>> adjacencyList;

    public Graph(bool isDirected = false)
    {
        this.isDirected = isDirected;
        adjacencyList = new Dictionary<int, HashSet<int>>();
    }

    public bool ContainsVertex(int vertex)
    {
        return adjacencyList.ContainsKey(vertex);
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

        if (adjacencyList[from].Contains(to))
        {
            MessageBox.Show($"Ребро между {from} и {to} уже существует.");
            return;
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

        // Удаляем все рёбра, которые ссылаются на удалённую вершину
        foreach (var vertexKey in adjacencyList.Keys.ToList())
        {
            adjacencyList[vertexKey].RemoveWhere(v => v == vertex);
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
