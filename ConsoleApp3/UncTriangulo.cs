using ConsoleApp3;
using OpenTK.Graphics.OpenGL;

public class UncTriangulo
{
    public UncPunto VerticeA { get; set; }
    public UncPunto VerticeB { get; set; }
    public UncPunto VerticeC { get; set; }

    public UncTriangulo(UncPunto verticeA, UncPunto verticeB, UncPunto verticeC)
    {
        VerticeA = verticeA;
        VerticeB = verticeB;
        VerticeC = verticeC;
    }

    public void Dibujar()
    {
        GL.Begin(PrimitiveType.Triangles);

        // Dibuja los tres vértices del triángulo
        GL.Vertex3(VerticeA.X, VerticeA.Y, VerticeA.Z);
        GL.Vertex3(VerticeB.X, VerticeB.Y, VerticeB.Z);
        GL.Vertex3(VerticeC.X, VerticeC.Y, VerticeC.Z);

        GL.End();
    }

    public override string ToString()
    {
        return $"Triángulo Rectángulo:\nVertice A: {VerticeA}\nVertice B: {VerticeB}\nVertice C: {VerticeC}";
    }
}
