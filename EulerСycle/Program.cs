List<List<int>> matrix;

Stack<int> visitedVertex;
List<int> cycleList;

bool shouldExit = false;
int startVert;

while(!shouldExit)
{
    
    Console.Write("Введите количество вершин в графе: ");
    if (!int.TryParse(Console.ReadLine(), out int vertexCount) || vertexCount < 2)
    {
        Console.Clear();
        Console.WriteLine("Количество вершин должно быть целым числом > 0");
        continue;
    }

    matrix = CreateMatrix(vertexCount);
    FillMatrix(ref matrix);
    PrintMatrix(ref matrix);

    if (!CheckEulerGraph(ref matrix))
    {
        Console.WriteLine("В данном графе нет цикла Эйлера");
        Console.Write("Нажмите любую кнопку чтобы продолжить...");
        Console.ReadKey();
        Console.Clear();
        continue;
    }

    Console.Write($"Введите номер стартовой вершины(1 - { matrix.Count}): ");
    while (!int.TryParse(Console.ReadLine(), out startVert) || startVert < 1 
        || startVert > matrix.Count) Console.WriteLine($"Введите номер стартовой вершины (1 - {matrix.Count}): ");

    startVert--;

    visitedVertex = new Stack<int>(matrix.Count * matrix.Count);
    cycleList = new List<int>(matrix.Count * matrix.Count);
    FindEulerCycle(startVert, ref matrix, ref visitedVertex, ref cycleList);

    Console.Write("Цикл Эйлера: ");
    foreach(var elem in cycleList)
    {
        Console.Write(elem + 1 + " ");
    }

    Console.Write("\n\nНажмите любую клавишу чтобы продолжить...");
    Console.ReadKey();
    Console.Clear();
}



static List<List<int>> CreateMatrix(int vertexCount)
{
    List<List<int>> matrix = new List<List<int>>(vertexCount);
    for(int i = 0; i < vertexCount; i++)
    {
        matrix.Add(new List<int>(vertexCount));
    }
    return matrix;
}

static void PrintMatrix(ref List<List<int>> matrix)
{
    Console.Clear();
    Console.WriteLine("Текущая матрица смежности:");
    foreach(var line in matrix)
    {
        foreach(var col in line)
        {
            Console.Write(col + " ");
        }
        Console.WriteLine();
    }
}

static void FillMatrix(ref List<List<int>> matrix)
{
    Console.WriteLine($"Введите матрицу смежности ({matrix.Count}*{matrix.Count}):");

    Console.Write("#");
    for (int i = 1; i <= matrix.Count; i++) Console.Write(" " + i);
    Console.WriteLine();
    for (int i = 0; i < matrix.Count * 2; i++) Console.Write("-");
    Console.WriteLine();

    for(int i = 0; i < matrix.Count; i++)
    {
        Console.Write(i + 1 + "|");
        string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        for (int j = 0; j < matrix.Count; j++)
        {
            matrix[i].Add(Math.Abs(Convert.ToInt32(line[j])));
        }
    }
}

static bool CheckEulerGraph(ref List<List<int>> matrix)
{
    int edgeCount = 0;

    for (int i = 0; i < matrix.Count; i++)
    {
        for (int j = 0; j < matrix.Count; j++)
        {
            if (matrix[i][j] > 0) edgeCount++;
        }
        if (edgeCount % 2 != 0) return false;
    }
    return true;
}

static void FindEulerCycle(int startVert, ref List<List<int>> matrix, ref Stack<int> visitedVertex, ref List<int> cycleList)
{
    visitedVertex.Push(startVert);

    int curVert = startVert;
    int nextVert = GetNearestVertIndex(curVert, ref matrix);

    while(visitedVertex.Count != 0)
    {
        if (nextVert == -1)
        {
            cycleList.Add(visitedVertex.Pop());
            if (visitedVertex.Count > 0) curVert = visitedVertex.Peek();
        }
        else
        {
            matrix[curVert][nextVert] = 0;
            matrix[nextVert][curVert] = 0;
            curVert = nextVert;
            visitedVertex.Push(curVert);
        }
        nextVert = GetNearestVertIndex(curVert, ref matrix);
    }
    cycleList.Reverse();
}

static int GetNearestVertIndex(int vert, ref List<List<int>> matrix)
{
    for (int i = 0; i < matrix.Count; i++)
    {
        if (matrix[vert][i] != 0) return i;
    }
    return -1;
}
