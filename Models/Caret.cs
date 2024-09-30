namespace TedEditor.Models
{
  public class Caret
  {
    public int PositionX { get; private set; }
    public int PositionY { get; private set; }
    public bool Visible { get; set; }

    public Caret(int x, int y)
    {
      PositionX = x;
      PositionY = y;
    }

    public void MoveLeft() => PositionX = Math.Max(0, PositionX - 1);
    // public void MoveRight(int textLength) => PositionX = Math.Min(textLength, PositionX + 1);
    public void MoveRight() => PositionX += 1;
  }
}