namespace TedEditor.Models
{
  public class RopeNode
  {
    public string Data { get; private set; }
    public RopeNode Left { get; private set; }
    public RopeNode Right { get; private set; }
    public int Weight { get; private set; }

    public RopeNode(string data)
    {
      Data = data;
      Weight = data.Length;
      Left = null;
      Right = null;
    }

    public RopeNode(RopeNode left, RopeNode right)
    {
      Left = left;
      Right = right;
      Weight = left.Weight + (right?.Weight ?? 0);
    }
  }
}