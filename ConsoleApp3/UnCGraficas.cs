﻿using System;
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
        private UncRectangulo3D Rectan3;
        private UncRectangulo3D Rectan4;
        private UncRectangulo3D RectPRueba;
        private PlanoCartesiano plano;
        private InputHandler inputHandler;

    
        public UnCGraficas()
         : base(DisplayDevice.Default.Width, DisplayDevice.Default.Height, GraphicsMode.Default, "Mi Ventana a Pantalla Completa", GameWindowFlags.Fullscreen)
        {
            inputHandler = new InputHandler(); 
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color4.Black);
            GL.Enable(EnableCap.DepthTest);
            plano = new PlanoCartesiano(0.1f, 10);
            this.CordenT();
       //     this.CordenT2();
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

            // Aplicar las mismas rotaciones al plano y al rectángulo
            GL.PushMatrix(); 

            // Crear matriz de rotación acumulada para X y Y
            Matrix4 rotationMatrix = Matrix4.CreateRotationX(this.angulox) * Matrix4.CreateRotationY(this.anguloy);
            GL.MultMatrix(ref rotationMatrix);

            
            plano.Dibujar();
            Rectan1.Dibujar();
            Rectan2.Dibujar();
       //     Rectan3.Dibujar();
         //   Rectan4.Dibujar();

            GL.PopMatrix(); 

            Context.SwapBuffers();
        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
        }

       

        public void CordenT()
        {
           
            UncPunto verticeInicial1 = new UncPunto(0f, 0f, 0f);
            Rectan1 = new UncRectangulo3D(verticeInicial1, 0.2f, 0.48f, 0.2f, Color4.Red);
            Rectan1.Trasladar(0.0f, 0.0f, 0.0f);  

           
            UncPunto verticeInicial2 = new UncPunto(0f, 0f, 0f);
            Rectan2 = new UncRectangulo3D(verticeInicial2, 0.48f, 0.2f, 0.2f, Color4.Yellow);
            Rectan2.Trasladar(0.0f, 0.4f, 0.0f);  
           

            Rectan1.Escalar(2f, 2f, 2f);  
            Rectan2.Escalar(2f, 2f, 2f);
           // Rectan2.RotarZ(30);


            ////Traslaciones por caras y por objeto  
          
           Rectan1.CaraFrontal.Cambiaror(Color4.White);
            Rectan1.CaraFrontal.Escalar(0.2f,0.4f,0.2f);
           //Rectan1.CaraFrontal.RotarY(15);
           //Rectan1.CaraFrontal.RotarZ(15);

        }
        public void CordenT2()
        {
            
            UncPunto verticeInicial3 = new UncPunto(1.0f, 0f, 0f); 
            Rectan3 = new UncRectangulo3D(verticeInicial3, 0.2f, 0.6f, 0.2f, Color4.Blue);
            Rectan3.Trasladar(1.0f, 0.0f, 0.0f);  

          
            UncPunto verticeInicial4 = new UncPunto(1.0f, 0f, 0f);
            Rectan4 = new UncRectangulo3D(verticeInicial4, 0.6f, 0.2f, 0.2f, Color4.Green);
            Rectan4.Trasladar(1.0f, 0.3f, 0.0f);  

            
            Rectan3.Escalar(2f, 2f, 2f);
            Rectan4.Escalar(2f, 2f, 2f);

        }

        public void Prueba()
        {
            UncPunto verticeInicial = new UncPunto(0f, 0f, 0f);
            this.RectPRueba = new UncRectangulo3D(verticeInicial, 0.8f, 0.8f, 0.8f, Color4.Red);

            // Escalar solo la cara frontal del rectángulo
            this.RectPRueba.CaraFrontal.Escalar(0.4f, 0.4f, 0.4f);
            this.RectPRueba.CaraFrontal.Cambiaror(Color4.White);
            this.RectPRueba.CaraFrontal.RotarZ(30);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState input = Keyboard.GetState();

            if (inputHandler.IsKeyPressed(Key.Escape, input))
            {
                Exit();
            }
            if (inputHandler.IsKeyPressed(Key.Up, input))
            {
                this.angulox += this.Rotar * (float)e.Time;
            }
            if (inputHandler.IsKeyPressed(Key.Down, input))
            {
                this.angulox -= this.Rotar * (float)e.Time;
            }
            if (inputHandler.IsKeyPressed(Key.Left, input))
            {
                this.anguloy -= this.Rotar * (float)e.Time;
            }
            if (inputHandler.IsKeyPressed(Key.Right, input))
            {
                this.anguloy += this.Rotar * (float)e.Time;
            }
            if (inputHandler.IsKeyPressed(Key.W, input) || inputHandler.IsKeyPressed(Key.KeypadPlus, input))
            {
                plano.Escala += 0.1f;
            }
            if (inputHandler.IsKeyPressed(Key.S, input) || inputHandler.IsKeyPressed(Key.KeypadMinus, input))
            {
                plano.Escala -= 0.1f;
            }
        }
    }
}
