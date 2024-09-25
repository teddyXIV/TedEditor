using System;
using System.Text;

namespace TedEditor.Models
{
  public class Rope
  {
    private RopeNode root;

    public Rope(string data)
    {
      root = new RopeNode(data);
    }

    public void Concatenate(Rope other)
    {
      root = new RopeNode(root, other.root);
    }

    // Split the ripe at a given index, returning two subtrees
    private Tuple<RopeNode, RopeNode> Split(RopeNode node, int index)
    {

      if (node.Data != null)
      {
        var leftString = node.Data.Substring(0, index);
        var rightString = node.Data.Substring(index);
        return new Tuple<RopeNode, RopeNode>(new RopeNode(leftString), new RopeNode(rightString));
      }

      if (node.Left != null && node.Right != null)
      {
        if (index < node.Weight)
        {
          var split = Split(node.Left, index);
          return new Tuple<RopeNode, RopeNode>(split.Item1, new RopeNode(split.Item2, node.Right));
        }
        else
        {
          var split = Split(node.Right, index - node.Weight);

          return new Tuple<RopeNode, RopeNode>(new RopeNode(node.Left, split.Item1), split.Item2);
        }
      }
      else
      {
        throw new ArgumentNullException(nameof(node), "The node cannot be null.");
      }
    }
  }
}