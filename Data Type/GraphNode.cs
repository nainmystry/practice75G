public class GraphNode {
    public int val; //vertices information
    public IList<GraphNode> neighbors; //list of neighbouring vertices or connected vertices

    public GraphNode() {
        val = 0; 
        neighbors = new List<GraphNode>();
    }

    public GraphNode(int _val) {
        val = _val;
        neighbors = new List<GraphNode>();
    }

    public GraphNode(int _val, List<GraphNode> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}