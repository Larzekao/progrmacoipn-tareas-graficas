using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;



namespace ConsoleApp3
{
    public class UncCubo
    {
        // Vértices del cubo
        public UncPunto VerticeA { get; set; }
        public UncPunto VerticeB { get; set; }
        public UncPunto VerticeC { get; set; }
        public UncPunto VerticeD { get; set; }
        public UncPunto VerticeE { get; set; }
        public UncPunto VerticeF { get; set; }
        public UncPunto VerticeG { get; set; }
        public UncPunto VerticeH { get; set; }

        public UncCubo(UncPunto verticeA, UncPunto verticeB, UncPunto verticeC, UncPunto verticeD,
                    UncPunto verticeE, UncPunto verticeF, UncPunto verticeG, UncPunto verticeH)
        {
            VerticeA = verticeA;
            VerticeB = verticeB;
            VerticeC = verticeC;
            VerticeD = verticeD;
            VerticeE = verticeE;
            VerticeF = verticeF;
            VerticeG = verticeG;
            VerticeH = verticeH;
        }

        public void Dibujar()
        {
            // Frontal
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(VerticeA.X, VerticeA.Y, VerticeA.Z);
            GL.Vertex3(VerticeB.X, VerticeB.Y, VerticeB.Z);
            GL.Vertex3(VerticeC.X, VerticeC.Y, VerticeC.Z);
            GL.Vertex3(VerticeD.X, VerticeD.Y, VerticeD.Z);
            GL.End();

            // Posterior
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(VerticeE.X, VerticeE.Y, VerticeE.Z);
            GL.Vertex3(VerticeF.X, VerticeF.Y, VerticeF.Z);
            GL.Vertex3(VerticeG.X, VerticeG.Y, VerticeG.Z);
            GL.Vertex3(VerticeH.X, VerticeH.Y, VerticeH.Z);
            GL.End();

            // Izquierda
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(VerticeA.X, VerticeA.Y, VerticeA.Z);
            GL.Vertex3(VerticeD.X, VerticeD.Y, VerticeD.Z);
            GL.Vertex3(VerticeH.X, VerticeH.Y, VerticeH.Z);
            GL.Vertex3(VerticeE.X, VerticeE.Y, VerticeE.Z);
            GL.End();

            // Derecha
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(VerticeB.X, VerticeB.Y, VerticeB.Z);
            GL.Vertex3(VerticeC.X, VerticeC.Y, VerticeC.Z);
            GL.Vertex3(VerticeG.X, VerticeG.Y, VerticeG.Z);
            GL.Vertex3(VerticeF.X, VerticeF.Y, VerticeF.Z);
            GL.End();

            // Superior
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(VerticeD.X, VerticeD.Y, VerticeD.Z);
            GL.Vertex3(VerticeC.X, VerticeC.Y, VerticeC.Z);
            GL.Vertex3(VerticeG.X, VerticeG.Y, VerticeG.Z);
            GL.Vertex3(VerticeH.X, VerticeH.Y, VerticeH.Z);
            GL.End();

            // Inferior
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(VerticeA.X, VerticeA.Y, VerticeA.Z);
            GL.Vertex3(VerticeB.X, VerticeB.Y, VerticeB.Z);
            GL.Vertex3(VerticeF.X, VerticeF.Y, VerticeF.Z);
            GL.Vertex3(VerticeE.X, VerticeE.Y, VerticeE.Z);
            GL.End();
        }

        public override string ToString()
        {
            return $"Cubo:\nVertice A: {VerticeA}\nVertice B: {VerticeB}\nVertice C: {VerticeC}\nVertice D: {VerticeD}\n" +
                   $"Vertice E: {VerticeE}\nVertice F: {VerticeF}\nVertice G: {VerticeG}\nVertice H: {VerticeH}";
        }
    }
}
