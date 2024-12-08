using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

public static class FileManager
{
    public static void SavePathToFile(string filePath, List<int> path)
    {
        try
        {
            File.WriteAllText(filePath, $"Кратчайший путь: {string.Join(" -> ", path)}");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка записи в файл: {ex.Message}");
        }
    }

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
            MessageBox.Show($"Ошибка чтения файла: {ex.Message}");
        }

        return graph;
    }

    public static Graph LoadGraphFromXmlFile(string filePath, bool isDirected)
    {
        var graph = new Graph(isDirected);

        try
        {
            var xDocument = XDocument.Load(filePath);

            var vertexElements = xDocument.Descendants("Vertex");
            foreach (var vertexElement in vertexElements)
            {
                if (int.TryParse(vertexElement.Value, out int vertex))
                {
                    graph.AddVertex(vertex);
                }
            }

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
            MessageBox.Show($"Ошибка чтения XML-файла: {ex.Message}");
        }

        return graph;
    }
}
