using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

public static class FileManager
{
    /// <summary>
    /// Сохраняет результат (путь) в текстовый файл.
    /// </summary>
    /// <param name="filePath">Путь к файлу</param>
    /// <param name="path">Список вершин, составляющих путь</param>
    public static void SavePathToFile(string filePath, List<int> path)
    {
        try
        {
            File.WriteAllText(filePath, $"Кратчайший путь: {string.Join(" -> ", path)}");
        }
        catch (Exception ex)
        {
            throw new IOException($"Ошибка записи в файл: {ex.Message}");
        }
    }

    /// <summary>
    /// Считывает граф из текстового файла.
    /// Формат файла:
    /// Вершины: 1,2,3,4
    /// Ребра: 1-2,2-3,3-4
    /// </summary>
    /// <param name="filePath">Путь к файлу</param>
    /// <param name="isDirected">Указывает, является ли граф направленным</param>
    /// <returns>Граф, построенный на основе файла</returns>
    public static Graph LoadGraphFromFile(string filePath, bool isDirected)
    {
        var graph = new Graph(isDirected);

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (line.StartsWith("Вершины:", StringComparison.OrdinalIgnoreCase))
                {
                    var vertices = line.Substring(9).Split(',');
                    foreach (var vertex in vertices)
                    {
                        if (int.TryParse(vertex.Trim(), out int v))
                        {
                            graph.AddVertex(v);
                        }
                    }
                }
                else if (line.StartsWith("Ребра:", StringComparison.OrdinalIgnoreCase))
                {
                    var edges = line.Substring(6).Split(',');
                    foreach (var edge in edges)
                    {
                        var vertices = edge.Split('-');
                        if (vertices.Length == 2 &&
                            int.TryParse(vertices[0].Trim(), out int from) &&
                            int.TryParse(vertices[1].Trim(), out int to))
                        {
                            graph.AddEdge(from, to, isDirected);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new IOException($"Ошибка чтения файла: {ex.Message}");
        }

        return graph;
    }

    /// <summary>
    /// Считывает граф из XML-файла.
    /// Формат файла:
    /// <Graph>
    ///   <Vertices>
    ///     <Vertex>1</Vertex>
    ///     <Vertex>2</Vertex>
    ///   </Vertices>
    ///   <Edges>
    ///     <Edge>
    ///       <From>1</From>
    ///       <To>2</To>
    ///     </Edge>
    ///   </Edges>
    /// </Graph>
    /// </summary>
    /// <param name="filePath">Путь к файлу</param>
    /// <param name="isDirected">Указывает, является ли граф направленным</param>
    /// <returns>Граф, построенный на основе XML-файла</returns>
    public static Graph LoadGraphFromXmlFile(string filePath, bool isDirected)
    {
        var graph = new Graph(isDirected);

        try
        {
            var xDocument = XDocument.Load(filePath);

            // Читаем вершины
            var vertexElements = xDocument.Descendants("Vertex");
            foreach (var vertexElement in vertexElements)
            {
                if (int.TryParse(vertexElement.Value, out int vertex))
                {
                    graph.AddVertex(vertex);
                }
            }

            // Читаем рёбра
            var edgeElements = xDocument.Descendants("Edge");
            foreach (var edgeElement in edgeElements)
            {
                var fromElement = edgeElement.Element("From");
                var toElement = edgeElement.Element("To");

                if (fromElement != null && toElement != null &&
                    int.TryParse(fromElement.Value, out int from) &&
                    int.TryParse(toElement.Value, out int to))
                {
                    graph.AddEdge(from, to, isDirected);
                }
            }
        }
        catch (Exception ex)
        {
            throw new IOException($"Ошибка чтения XML-файла: {ex.Message}");
        }

        return graph;
    }
}
