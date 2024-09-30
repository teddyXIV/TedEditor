using System.Windows.Input;
using TedEditor.Models;

namespace TedEditor.Services;

public class CaretService
{
  private Caret caret;

  public CaretService(Caret cursor)
  {
    caret = cursor;
  }

  public void HandleKeyDown(KeyEventArgs e)
  {
    if (e.Key == Key.Right)
    {
      caret.MoveRight();
    }
  }
}