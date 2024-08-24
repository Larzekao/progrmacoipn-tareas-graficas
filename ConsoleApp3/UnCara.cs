using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ConsoleApp3
{
    public class UnCara
    {
        public UncPunto Vertice1 { get; set; }
        public UncPunto Vertice2 { get; set; }
        public UncPunto Vertice3 { get; set; }
        public UncPunto Vertice4 { get; set; }
        public UncPunto Origen { get; set; } // Punto de origen
        public Color4 Color { get; set; }

        public UnCara(UncPunto vertice1, UncPunto vertice2, UncPunto vertice3, UncPunto vertice4, UncPunto origen, Color4 color)
        {
            Vertice1 = vertice1;
            Vertice2 = vertice2;
            Vertice3 = vertice3;
            Vertice4 = vertice4;
            Origen = origen;
            Color = color;
        }
        public void Cambiaror(Color4 col){
            this.Color = col;


          }
       
        public void Trasladar(float dx, float dy, float dz)
        {
            Origen.Trasladar(dx, dy, dz);
            Vertice1.Trasladar(dx, dy, dz);
            Vertice2.Trasladar(dx, dy, dz);

            Vertice3.Trasladar(dx, dy, dz);
            Vertice4.Trasladar(dx, dy, dz);
        }

       
        public void RotarX(float angulo)
        {
            Vertice1.RotarX(angulo, Origen);
            Vertice2.RotarX(angulo, Origen);
            Vertice3.RotarX(angulo, Origen);
            Vertice4.RotarX(angulo, Origen);
        }

      
        public void RotarY(float angulo)
        {
            Vertice1.RotarY(angulo, Origen);
            Vertice2.RotarY(angulo, Origen);
            Vertice3.RotarY(angulo, Origen);
            Vertice4.RotarY(angulo, Origen);
        }

   
        public void RotarZ(float angulo)
        {
            Vertice1.RotarZ(angulo, Origen);
            Vertice2.RotarZ(angulo, Origen);
            Vertice3.RotarZ(angulo, Origen);
            Vertice4.RotarZ(angulo, Origen);
        }

   
        public void Escalar(float factorX, float factorY, float factorZ)
        {
            // Calcular el centro de la cara
            float centroX = (Vertice1.X + Vertice2.X + Vertice3.X + Vertice4.X) / 4;
            float centroY = (Vertice1.Y + Vertice2.Y + Vertice3.Y + Vertice4.Y) / 4;
            float centroZ = (Vertice1.Z + Vertice2.Z + Vertice3.Z + Vertice4.Z) / 4;

            // Ajustar cada vértice
            Vertice1.Escalar(factorX, factorY, factorZ, new UncPunto(centroX, centroY, centroZ));
            Vertice2.Escalar(factorX, factorY, factorZ, new UncPunto(centroX, centroY, centroZ));
            Vertice3.Escalar(factorX, factorY, factorZ, new UncPunto(centroX, centroY, centroZ));
            Vertice4.Escalar(factorX, factorY, factorZ, new UncPunto(centroX, centroY, centroZ));
        }


        public void Dibujar()
        {
            GL.Color4(Color);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(Vertice1.X, Vertice1.Y, Vertice1.Z);
            GL.Vertex3(Vertice2.X, Vertice2.Y, Vertice2.Z);
            GL.Vertex3(Vertice3.X, Vertice3.Y, Vertice3.Z);
            GL.Vertex3(Vertice4.X, Vertice4.Y, Vertice4.Z);
            GL.End();
        }

        public override string ToString()
        {
            return $"Vertices: {Vertice1}, {Vertice2}, {Vertice3}, {Vertice4}, Origen: {Origen}";
        }
    }
}
