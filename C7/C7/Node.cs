public class Node
{
    public long info;
    public Node left = null;
    public Node right = null;
    public long level = 0;
    public long index = 0 ;

    public Node(long info)
    {
        this.info = info;
    }
}