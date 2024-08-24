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

        public void Trasladar(float dx, float dy, float dz)
        {
            X += dx;
            Y += dy;
            Z += dz;
        }

       
        public void RotarX(float angulo, UncPunto origen)
        {
            float radianes = MathF.PI * angulo / 180.0f;

           
            float nuevoY = (Y - origen.Y) * MathF.Cos(radianes) - (Z - origen.Z) * MathF.Sin(radianes);
            float nuevoZ = (Y - origen.Y) * MathF.Sin(radianes) + (Z - origen.Z) * MathF.Cos(radianes);

            
            Y = nuevoY + origen.Y;
            Z = nuevoZ + origen.Z;
        }

       
        public void RotarY(float angulo, UncPunto origen)
        {
            float radianes = MathF.PI * angulo / 180.0f;

            float nuevoX = (X - origen.X) * MathF.Cos(radianes) + (Z - origen.Z) * MathF.Sin(radianes);
            float nuevoZ = -(X - origen.X) * MathF.Sin(radianes) + (Z - origen.Z) * MathF.Cos(radianes);

            X = nuevoX + origen.X;
            Z = nuevoZ + origen.Z;
        }

        public void RotarZ(float angulo, UncPunto origen)
        {
            float radianes = MathF.PI * angulo / 180.0f;

            float nuevoX = (X - origen.X) * MathF.Cos(radianes) - (Y - origen.Y) * MathF.Sin(radianes);
            float nuevoY = (X - origen.X) * MathF.Sin(radianes) + (Y - origen.Y) * MathF.Cos(radianes);

            X = nuevoX + origen.X;
            Y = nuevoY + origen.Y;
        }


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
