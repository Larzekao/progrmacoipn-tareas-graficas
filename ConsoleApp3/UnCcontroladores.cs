using OpenTK.Input;

namespace ConsoleApp3
{
    public class InputHandler
    {
        public bool IsKeyPressed(Key key, KeyboardState keyboardState)
        {
            return keyboardState.IsKeyDown(key);
        }
    }
}
