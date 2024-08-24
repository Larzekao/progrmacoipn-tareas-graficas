using System;

namespace ConsoleApp3
{
    public class UncPunto
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public UncPunto(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // Método para trasladar el punto
        public void Trasladar(float dx, float dy, float dz)
        {
            X += dx;
            Y += dy;
            Z += dz;
        }

        // Método para rotar el punto alrededor del eje X tomando en cuenta un origen
        public void RotarX(float angulo, UncPunto origen)
        {
            float radianes = MathF.PI * angulo / 180.0f;

            // Trasladar el punto al origen
            float nuevoY = (Y - origen.Y) * MathF.Cos(radianes) - (Z - origen.Z) * MathF.Sin(radianes);
            float nuevoZ = (Y - origen.Y) * MathF.Sin(radianes) + (Z - origen.Z) * MathF.Cos(radianes);

            // Ajustar nuevamente según el origen
            Y = nuevoY + origen.Y;
            Z = nuevoZ + origen.Z;
        }

        // Método para rotar el punto alrededor del eje Y tomando en cuenta un origen
        public void RotarY(float angulo, UncPunto origen)
        {
            float radianes = MathF.PI * angulo / 180.0f;

            float nuevoX = (X - origen.X) * MathF.Cos(radianes) + (Z - origen.Z) * MathF.Sin(radianes);
            float nuevoZ = -(X - origen.X) * MathF.Sin(radianes) + (Z - origen.Z) * MathF.Cos(radianes);

            X = nuevoX + origen.X;
            Z = nuevoZ + origen.Z;
        }

        // Método para rotar el punto alrededor del eje Z tomando en cuenta un origen
        public void RotarZ(float angulo, UncPunto origen)
        {
            float radianes = MathF.PI * angulo / 180.0f;

            float nuevoX = (X - origen.X) * MathF.Cos(radianes) - (Y - origen.Y) * MathF.Sin(radianes);
            float nuevoY = (X - origen.X) * MathF.Sin(radianes) + (Y - origen.Y) * MathF.Cos(radianes);

            X = nuevoX + origen.X;
            Y = nuevoY + origen.Y;
        }

        // Método para escalar el punto tomando en cuenta un origen
        public void Escalar(float factorX, float factorY, float factorZ, UncPunto origen)
        {
            X = origen.X + (X - origen.X) * factorX;
            Y = origen.Y + (Y - origen.Y) * factorY;
            Z = origen.Z + (Z - origen.Z) * factorZ;
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }
}
