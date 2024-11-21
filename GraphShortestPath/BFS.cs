using System.Collections.Generic;

public static class BFS
{
    /// <summary>
    /// Метод для поиска кратчайшего пути между двумя вершинами.
    /// </summary>
    /// <param name="graph">Граф.</param>
    /// <param name="start">Начальная вершина.</param>
    /// <param name="end">Конечная вершина.</param>
    /// <returns>Список вершин, представляющих кратчайший путь.</returns>
    public static List<int> FindShortestPath(Graph graph, int start, int end)
    {
        if (!graph.GetNeighbors(start).Contains(end) && start == end)
        {
            return new List<int> { start }; // Если начальная и конечная вершина совпадают
        }

        // Очередь для обхода графа (хранит вершину и путь до неё)
        Queue<List<int>> queue = new Queue<List<int>>();
        HashSet<int> visited = new HashSet<int>();

        // Добавляем начальную вершину
        queue.Enqueue(new List<int> { start });
        visited.Add(start);

        while (queue.Count > 0)
        {
            // Достаём текущий путь из очереди
            List<int> path = queue.Dequeue();
            int currentNode = path[^1]; // Последний элемент пути (текущая вершина)

            // Если мы достигли конечной вершины, возвращаем путь
            if (currentNode == end)
            {
                return path;
            }

            // Обходим всех соседей текущей вершины
            foreach (int neighbor in graph.GetNeighbors(currentNode))
            {
                if (!visited.Contains(neighbor))
                {
                    // Добавляем вершину в путь и в очередь
                    List<int> newPath = new List<int>(path) { neighbor };
                    queue.Enqueue(newPath);
                    visited.Add(neighbor);
                }
            }
        }

        // Если путь не найден, возвращаем пустой список
        return new List<int>();
    }
}
