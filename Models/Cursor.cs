namespace TedEditor.Models
{
  public class Cursor
  {
    public int Position { get; private set; }

    public Cursor()
    {
      Position = 0;
    }

    public void MoveLeft() => Position = Math.Max(0, Position - 1);
    public void MoveRight(int textLength) => Position = Math.Min(textLength, Position + 1);
  }
}