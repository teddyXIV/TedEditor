using TedEditor.Models;

namespace TedEditor.Services
{
  public class TextBufferService
  {
    private TextBuffer textBuffer;
    public TextBufferService(TextBuffer buffer)
    {
      textBuffer = buffer;
    }
  }
}