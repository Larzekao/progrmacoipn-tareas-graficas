using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ConsoleApp3;
public class UnCara
{
    // Vértices de la cara
    public UncPunto VerticeA { get; set; }
    public UncPunto VerticeB { get; set; }
    public UncPunto VerticeC { get; set; }
    public UncPunto VerticeD { get; set; }

    // Color de la cara
    public Color4 Color { get; set; }

    // Constructor
    public UnCara(UncPunto verticeA, UncPunto verticeB, UncPunto verticeC, UncPunto verticeD, Color4 color)
    {
        VerticeA = verticeA;
        VerticeB = verticeB;
        VerticeC = verticeC;
        VerticeD = verticeD;
        Color = color;
    }

    // Método para trasladar la cara
    public void Trasladar(float dx, float dy, float dz)
    {
        VerticeA.X += dx;
        VerticeA.Y += dy;
        VerticeA.Z += dz;

        VerticeB.X += dx;
        VerticeB.Y += dy;
        VerticeB.Z += dz;

        VerticeC.X += dx;
        VerticeC.Y += dy;
        VerticeC.Z += dz;

        VerticeD.X += dx;
        VerticeD.Y += dy;
        VerticeD.Z += dz;
    }

    // Método para rotar la cara alrededor del eje X
    public void RotarX(float angulo)
    {
        float rad = angulo * (float)Math.PI / 180.0f;
        float cosA = (float)Math.Cos(rad);
        float sinA = (float)Math.Sin(rad);

        VerticeA = RotarPuntoX(VerticeA, cosA, sinA);
        VerticeB = RotarPuntoX(VerticeB, cosA, sinA);
        VerticeC = RotarPuntoX(VerticeC, cosA, sinA);
        VerticeD = RotarPuntoX(VerticeD, cosA, sinA);
    }

    private UncPunto RotarPuntoX(UncPunto p, float cosA, float sinA)
    {
        float y = p.Y * cosA - p.Z * sinA;
        float z = p.Y * sinA + p.Z * cosA;
        return new UncPunto(p.X, y, z);
    }

    // Método para escalar la cara
    public void Escalar(float factorX, float factorY, float factorZ)
    {
        VerticeA = EscalarPunto(VerticeA, factorX, factorY, factorZ);
        VerticeB = EscalarPunto(VerticeB, factorX, factorY, factorZ);
        VerticeC = EscalarPunto(VerticeC, factorX, factorY, factorZ);
        VerticeD = EscalarPunto(VerticeD, factorX, factorY, factorZ);
    }

    private UncPunto EscalarPunto(UncPunto p, float factorX, float factorY, float factorZ)
    {
        return new UncPunto(p.X * factorX, p.Y * factorY, p.Z * factorZ);
    }

    // Método para dibujar la cara
    public void Dibujar()
    {
        GL.Begin(PrimitiveType.Quads);
        GL.Color4(Color);
        GL.Vertex3(VerticeA.X, VerticeA.Y, VerticeA.Z);
        GL.Vertex3(VerticeB.X, VerticeB.Y, VerticeB.Z);
        GL.Vertex3(VerticeC.X, VerticeC.Y, VerticeC.Z);
        GL.Vertex3(VerticeD.X, VerticeD.Y, VerticeD.Z);
        GL.End();
    }
}

