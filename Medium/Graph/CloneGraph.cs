
using System.Runtime.CompilerServices;

public class CloneGraphSolution {
    // public GraphNode CloneGraph(GraphNode node) {
    //     if(node == null)
    //         return null;

    //     if(node.neighbors.Count == 0){
    //         GraphNode graphNode = new GraphNode(node.val);
    //         return graphNode;
    //     }
    //     Dictionary<GraphNode, GraphNode> nodesDict = new Dictionary<GraphNode, GraphNode>();
        
    //     GraphNode DepthFirstSearch(GraphNode node){            
    //         if(nodesDict.ContainsKey(node))
    //             return nodesDict[node];            
    //         var copyNode = new GraphNode(node.val);
    //         nodesDict[node] = copyNode;
    //         for (int I = 0; I < node.neighbors.Count; I++)
    //         {
    //             copyNode.neighbors.Add(DepthFirstSearch(node.neighbors[I]));
    //         }
    //         return copyNode;
    //     }
    //     var copiedNode = DepthFirstSearch(node);
    //     return copiedNode;
    // }

    Dictionary<GraphNode, GraphNode> dict = new Dictionary<GraphNode, GraphNode>();

    //DFS Approach
    public GraphNode CloneGraph(GraphNode node){
            if (node == null) //If node is null return as is.
                return null;
            
            if (dict.ContainsKey(node)) //If node is already Copied, return it.
                return dict[node];

            dict[node] = new GraphNode(node.val); //create a copy of node

            foreach(var v in node.neighbors) {
                dict[node].neighbors.Add(CloneGraph(v)); //if node has neighbors, repeat the above process to copy & add it as a neighbor 
            }

        return dict[node]; //return the node
    }
}