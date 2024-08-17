using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace ConsoleApp3
{
    public class UnCGraficas : GameWindow
    {
        private float angulox;
        private float anguloy;
        private float Rotar = 1.0f;
        private UncRectangulo3D Rectan1;
        private UncRectangulo3D Rectan2;
        private PlanoCartesiano plano;

        // Constructor para modo pantalla completa
        public UnCGraficas()
         : base(DisplayDevice.Default.Width, DisplayDevice.Default.Height, GraphicsMode.Default, "Mi Ventana a Pantalla Completa", GameWindowFlags.Fullscreen)
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color4.Black);
            GL.Enable(EnableCap.DepthTest);

            UncPunto verticeInicial = new UncPunto(0f, -0f, 0f);
            Rectan1 = new UncRectangulo3D(verticeInicial, 0.48f, 0.2f, 0.2f,Color4.White);
            Rectan1.Trasladar(0.0f, 0.2f, 0.0f);
        Rectan1.Escalar(2f,2f,2f);
            Rectan1.Trasladar(0f,0.0f,0f);
            Rectan2 = new UncRectangulo3D(verticeInicial, 0.2f, 0.48f, 0.2f,Color4.White);
            Rectan2.Escalar(2f, 2f, 2f);
            plano = new PlanoCartesiano(0.1f, 10);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Configuración de la matriz de proyección
            Matrix4 projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), (float)Size.Width / Size.Height, 0.1f, 100.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projectionMatrix);

            // Configuración de la matriz de vista
            Matrix4 viewMatrix = Matrix4.CreateTranslation(0.0f, 0.0f, -5.0f);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref viewMatrix);

            // Rotaciones
            Matrix4 modelMatrix = Matrix4.CreateRotationX(this.angulox) * Matrix4.CreateRotationY(this.anguloy);
            GL.MultMatrix(ref modelMatrix);

            plano.Dibujar();
            Rectan1.Dibujar();
            Rectan2.Dibujar();

            Context.SwapBuffers();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }
            if (input.IsKeyDown(Key.Up))
            {
                this.angulox += this.Rotar * (float)e.Time;
            }
            if (input.IsKeyDown(Key.Down))
            {
                this.angulox -= this.Rotar * (float)e.Time;
            }
            if (input.IsKeyDown(Key.Left))
            {
                this.anguloy -= this.Rotar * (float)e.Time;
            }
            if (input.IsKeyDown(Key.Right))
            {
                this.anguloy += this.Rotar * (float)e.Time;
            }
            if (input.IsKeyDown(Key.W) || input.IsKeyDown(Key.KeypadPlus))
            {
                plano.Escala += 0.1f; // Aumentar la escala
            }
            if (input.IsKeyDown(Key.S) || input.IsKeyDown(Key.KeypadMinus))
            {
                plano.Escala -= 0.1f; // Disminuir la escala
            }
        }
    }
}
