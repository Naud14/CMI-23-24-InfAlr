namespace Solution;

public class Graph
{
    public double[,] AdjacencyMatrix { get; set; }
    public int Count { get { return AdjacencyMatrix.GetLength(0); } }  //Number of nodes in the graph

    public Graph(double[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
            throw new System.ArgumentException("The adjacency matrix must be a square matrix");
        AdjacencyMatrix = matrix;
    }

    //Breadth First Traversal
    public string BFT(int root)
    {
        string result = "";
        // create empty queue and enqueue the root
        Queue<int> BFTqueue = new Queue<int>();
        BFTqueue.Enqueue(root);
        // create array of booleans to keep track of visited nodes and set the root flag to true
        bool[] vistitedNodes = new bool[Count];
        vistitedNodes[root] = true;
        // Loop until queue is empty
        while(BFTqueue.Count > 0)
        {
            // dequeue a node
            int nodeToExam = BFTqueue.Dequeue();
            // add the current node (followed by a space) to the string
            result += $"{nodeToExam} ";

            // find neighbors of current
            List<int> neighbors = Neighbors(nodeToExam);
            foreach(int i in neighbors)
            {
                if(!vistitedNodes[i])
                {
                    // enqueue all neighbors which are not visited yet and set them to visited  
                    BFTqueue.Enqueue(i);
                    vistitedNodes[i] = true;
                }
            }
        }
        return result;
    }

    //Nodes adjacent to a given node
    public List<int> Neighbors(int node)
    {
        List<int> neighbors = new List<int>();
        for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
        {
            if (AdjacencyMatrix[node, i] < Double.PositiveInfinity)
                neighbors.Add(i);
        }
        return neighbors;
    }

    //Nodes (adjacent to a given node) to be visited in reversed order
    public List<int> NeighborsReversed(int node) 
    {
        List<int> neighbors = new List<int>();
        for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
        {
            if (AdjacencyMatrix[node, i] < Double.PositiveInfinity)
                neighbors.Add(i);
        }
        neighbors.Reverse();
        return neighbors;
    }
    
    //Depth First Traveral
    public string DFT(int root)
    {
        string result = "";
        // create empty stack and push the root into it
        Stack<int> currStack = new Stack<int>();
        currStack.Push(root);
        // create array of booleans to keep track of visited nodes
        bool[] visitedNodes = new bool[Count];
        // Loop until stack is empty
        while(currStack.Count > 0)
        {
            // pop a node from the stack 
            int popped_node = currStack.Pop();
            // check if current node is not visited yet
            if(!visitedNodes[popped_node])
            {
                // add current node to the string (followed by a space) and set it to visited
                result += $"{popped_node} ";
                visitedNodes[popped_node] = true;
            }
            // find neighbors (in reversed order) of current  
            List<int> neighbors_reversed = NeighborsReversed(popped_node);
            // push all neighbors 
            foreach(int neighbor in neighbors_reversed)
            {
                if(!visitedNodes[neighbor]) currStack.Push(neighbor);
            }
        }
        return result; 
    }

    //Dijkstra's algorithm SingleSourceShortestPath 
    public Tuple<double[], int[]> SingleSourceShortestPath(int source) //distance and prev arrays
    {
        // initialization of distance, prev and unvisitedNodes
        double[] distance = new double[Count];
        int[] prev = new int[Count];
        List<int> unvisitedNodes = new List<int>();
        
        unvisitedNodes.Add(source);
        for(int i = 0; i < Count; i ++)
        {
            // default distance: double.PositiveInfinity
            distance[i] = double.PositiveInfinity;
            // default previous node: -1
            prev[i] = -1;
            if(source != i) unvisitedNodes.Add(i);
        }

        // set distance of source
        distance[source] = 0;
        // Loop until unvisitedNodes is empty
        while(unvisitedNodes.Count > 0)
        {
            // find closest node in unvisitedNodes
            int closest = unvisitedNodes.First();
            double tempdis = double.PositiveInfinity;
            foreach(int i in unvisitedNodes)
            {
                if(distance[i] < tempdis)
                {
                    closest = i;
                    tempdis = distance[i];
                }
            }
            // remove the closest node from unvisitedNodes
            unvisitedNodes.Remove(closest);

            List<int> NeighBorsList = Neighbors(closest);
            //considering all neighbors of the closest node
            foreach(int i in NeighBorsList)
            {
                // calculate distance and update distance (and previous node) if smaller
                double alt = distance[closest] + AdjacencyMatrix[closest, i];
                if(alt < distance[i])
                {
                    distance[i] = alt;
                    prev[i] = closest;
                }
            }
        }
        return new Tuple<double[], int[]>(distance, prev);
    }

}


