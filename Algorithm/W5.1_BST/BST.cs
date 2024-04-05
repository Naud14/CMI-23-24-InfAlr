
namespace Solution;

public class BST<T> : IBST<T> where T : IComparable<T>
{
    public TreeNode<T>? Root { get; set; }

    public void Insert(T value) => Insert(value, Root);
    public void InsertIterative(T value)
    {
        // case Root is null
        if(Root == null)
        {
            Root = new TreeNode<T>(value);
            return;
        }
   
        
        var curr = Root; 
        while(curr != null)
        {
            if(value.CompareTo(curr.Value) == 0) return;
            // right child
            if(value.CompareTo(curr.Value) == -1)
            {
                if(curr.Left == null)
                {
                    curr.Left = new TreeNode<T>(value, curr);
                    return;
                }
                curr = curr.Left;
            }
            // left child
            else
            {
                if(curr.Right == null)
                {
                    curr.Right = new TreeNode<T>(value, curr);
                    return;
                }
                curr = curr.Right;
            }
        }

       
    }

    private void Insert(T value, TreeNode<T>? node)
    {
        // case Root is null
        if(Root == null)
        {
            Root = new TreeNode<T>(value);
        }

        if(node == null) return;
        if(value.CompareTo(node.Value) == 0) return;

        if(value.CompareTo(node.Value) == -1)
        {
            if(node.Left != null) Insert(value, node.Left);
            else
            {
                node.Left = new TreeNode<T>(value, node);
                return;
            }
        }
        else
        {
            if(node.Right != null) Insert(value, node.Right);
            else
            {
                node.Right = new TreeNode<T>(value, node); 
                return;
            }
        }
    }

    #region Traversal

    public string PreOrderTraversal() => PreOrderTraversal(Root);
    private string PreOrderTraversal(TreeNode<T>? currNode)
    {
        if(currNode == null) return string.Empty; 
        return $"{currNode.Value} {PreOrderTraversal(currNode.Left)}{PreOrderTraversal(currNode.Right)}";
    }

    public string InOrderTraversal() => InOrderTraversal(Root);
    private string InOrderTraversal(TreeNode<T>? currNode)
    {
        if(currNode == null) return string.Empty;
        return $"{InOrderTraversal(currNode.Left)}{currNode.Value} {InOrderTraversal(currNode.Right)}";      
    }

    public string PostOrderTraversal() => PostOrderTraversal(Root);
    private string PostOrderTraversal(TreeNode<T>? currNode)
    {
        if(currNode == null) return string.Empty;
        return $"{PostOrderTraversal(currNode.Left)}{PostOrderTraversal(currNode.Right)}{currNode.Value} ";

    }
    #endregion

    public bool Contains(T value) => Search(Root, value) != null;

    private TreeNode<T> Search(TreeNode<T>? node, T value)
    {
        // node does not exist
        if(node == null) return default;
        
        // value in the node is the same we are looking for
        if(node.Value.CompareTo(value) == 0) return node; 

        // value in the node is smaller than the one we are looking for
        if(node.Value.CompareTo(value) == 1) return Search(node.Left, value);
        else
        {
            return Search(node.Right, value);
        }
    }

    #region  Remove Delete

    public bool Remove(T value) => DeleteValue(this, value);

    private bool DeleteValue(BST<T>? tree, T value)
    { 
        if(tree == null || tree.Root == null) return false;
        TreeNode<T> nodeToDelete = Search(tree.Root, value);
        if(nodeToDelete == null) return false;
        // special case if the value to delete is in the root (and the root has 0 children or 1 child)
        if(nodeToDelete == tree.Root)
        {
            // there are no children:
            if(nodeToDelete.Left == null && nodeToDelete.Right == null)
            {
                tree.Root = null; 
                return true;
            }
            // there is only left child, the right does not exist
            if(nodeToDelete.Left != null && nodeToDelete.Right == null)
            {
                tree.Root = nodeToDelete.Left;
                return true;
            }
            // there is only right child, the left does not exist
            if(nodeToDelete.Right != null && nodeToDelete.Left == null)
            {
                tree.Root = nodeToDelete.Right;
                return true;
            }
        }
        // all other cases. Find first the node corresponding to the value we want to delete
        // actually perform the deletion
        return delete(tree.Root, nodeToDelete);

    }

    private bool delete(TreeNode<T> root, TreeNode<T> nodeToDelete)
    {
        // CASE 1 : LEAF
        if(nodeToDelete.Left == null && nodeToDelete.Right == null)
        {
            if(root.Left == nodeToDelete) root.Left = null;
            else if(root.Right == nodeToDelete) root.Right = null;
            else
            {
                return false;
            }
            return true;
        }
        // CASE 2 : ONE CHILD
        if(nodeToDelete.Left == null || nodeToDelete.Right == null)
        {
            TreeNode<T> child = (nodeToDelete.Right == null) ? nodeToDelete.Left : nodeToDelete.Right;
            
            if(nodeToDelete == root)
            {
                child.Parent = default;
                Root = child;
                return true;
            }
            else if(nodeToDelete.Parent.Left == nodeToDelete) nodeToDelete.Parent.Left = child;
            else
            {
                nodeToDelete.Parent.Right = child;
            }
            return true;
        }
        // CASE 3 : TWO CHILDREN
        // find inordersucc == smallest element of right subtree
        TreeNode<T> inOrderSucc = findInOrderSucc(nodeToDelete);
        // copy value to nodeToDelete
        nodeToDelete.Value = inOrderSucc.Value;
        // call recursively delete on inordersucc 
        return delete(root, inOrderSucc);

    }

    // This methods finds the in order successor of the node given as parameter
    private TreeNode<T>? findInOrderSucc(TreeNode<T> node)
    {
        var currNode = node.Right;
        while (currNode != null && currNode.Left != null)
            currNode = currNode.Left;

        return currNode;
    }
 
    // This methods checks if the node given as first parameter is the left child of the node given as second parameter ("root"). 
    // The comparison is based on the values of the nodes.
    private bool isLeft(TreeNode<T> node, TreeNode<T> root)
    {
        return root.Left != null && root.Left.Value.CompareTo(node.Value) == 0;
    }

    public List<T> Traversal(TraversalOrder traversalOrder) //Optional
    {
        throw new NotImplementedException();
    }
    #endregion
}

