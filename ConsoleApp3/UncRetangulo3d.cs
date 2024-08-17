using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ConsoleApp3
{
    public class UncRectangulo3D
    {
        // Caras del rectángulo
        public UnCara CaraFrontal { get; private set; }
        public UnCara CaraPosterior { get; private set; }
        public UnCara CaraIzquierda { get; private set; }
        public UnCara CaraDerecha { get; private set; }
        public UnCara CaraSuperior { get; private set; }
        public UnCara CaraInferior { get; private set; }

        // Constructor
        public UncRectangulo3D(UncPunto verticeInicial, float ancho, float largo, float profundidad, Color4 color)
        {
            // Inicializar cada cara del rectángulo
            CaraFrontal = new UnCara(
                new UncPunto(verticeInicial.X - ancho / 2, verticeInicial.Y - largo / 2, verticeInicial.Z - profundidad / 2),
                new UncPunto(verticeInicial.X + ancho / 2, verticeInicial.Y - largo / 2, verticeInicial.Z - profundidad / 2),
                new UncPunto(verticeInicial.X + ancho / 2, verticeInicial.Y + largo / 2, verticeInicial.Z - profundidad / 2),
                new UncPunto(verticeInicial.X - ancho / 2, verticeInicial.Y + largo / 2, verticeInicial.Z - profundidad / 2),
                color);

            CaraPosterior = new UnCara(
                new UncPunto(verticeInicial.X - ancho / 2, verticeInicial.Y - largo / 2, verticeInicial.Z + profundidad / 2),
                new UncPunto(verticeInicial.X + ancho / 2, verticeInicial.Y - largo / 2, verticeInicial.Z + profundidad / 2),
                new UncPunto(verticeInicial.X + ancho / 2, verticeInicial.Y + largo / 2, verticeInicial.Z + profundidad / 2),
                new UncPunto(verticeInicial.X - ancho / 2, verticeInicial.Y + largo / 2, verticeInicial.Z + profundidad / 2),
                color);

            CaraIzquierda = new UnCara(
                new UncPunto(verticeInicial.X - ancho / 2, verticeInicial.Y - largo / 2, verticeInicial.Z - profundidad / 2),
                new UncPunto(verticeInicial.X - ancho / 2, verticeInicial.Y - largo / 2, verticeInicial.Z + profundidad / 2),
                new UncPunto(verticeInicial.X - ancho / 2, verticeInicial.Y + largo / 2, verticeInicial.Z + profundidad / 2),
                new UncPunto(verticeInicial.X - ancho / 2, verticeInicial.Y + largo / 2, verticeInicial.Z - profundidad / 2),
                color);

            CaraDerecha = new UnCara(
                new UncPunto(verticeInicial.X + ancho / 2, verticeInicial.Y - largo / 2, verticeInicial.Z - profundidad / 2),
                new UncPunto(verticeInicial.X + ancho / 2, verticeInicial.Y - largo / 2, verticeInicial.Z + profundidad / 2),
                new UncPunto(verticeInicial.X + ancho / 2, verticeInicial.Y + largo / 2, verticeInicial.Z + profundidad / 2),
                new UncPunto(verticeInicial.X + ancho / 2, verticeInicial.Y + largo / 2, verticeInicial.Z - profundidad / 2),
                color);

            CaraSuperior = new UnCara(
                new UncPunto(verticeInicial.X - ancho / 2, verticeInicial.Y + largo / 2, verticeInicial.Z - profundidad / 2),
                new UncPunto(verticeInicial.X + ancho / 2, verticeInicial.Y + largo / 2, verticeInicial.Z - profundidad / 2),
                new UncPunto(verticeInicial.X + ancho / 2, verticeInicial.Y + largo / 2, verticeInicial.Z + profundidad / 2),
                new UncPunto(verticeInicial.X - ancho / 2, verticeInicial.Y + largo / 2, verticeInicial.Z + profundidad / 2),
                color);

            CaraInferior = new UnCara(
                new UncPunto(verticeInicial.X - ancho / 2, verticeInicial.Y - largo / 2, verticeInicial.Z - profundidad / 2),
                new UncPunto(verticeInicial.X + ancho / 2, verticeInicial.Y - largo / 2, verticeInicial.Z - profundidad / 2),
                new UncPunto(verticeInicial.X + ancho / 2, verticeInicial.Y - largo / 2, verticeInicial.Z + profundidad / 2),
                new UncPunto(verticeInicial.X - ancho / 2, verticeInicial.Y - largo / 2, verticeInicial.Z + profundidad / 2),
                color);
        }

        // Métodos para aplicar transformaciones a todas las caras
        public void Trasladar(float dx, float dy, float dz)
        {
            CaraFrontal.Trasladar(dx, dy, dz);
            CaraPosterior.Trasladar(dx, dy, dz);
            CaraIzquierda.Trasladar(dx, dy, dz);
            CaraDerecha.Trasladar(dx, dy, dz);
            CaraSuperior.Trasladar(dx, dy, dz);
            CaraInferior.Trasladar(dx, dy, dz);
        }

        public void RotarX(float angulo)
        {
            CaraFrontal.RotarX(angulo);
            CaraPosterior.RotarX(angulo);
            CaraIzquierda.RotarX(angulo);
            CaraDerecha.RotarX(angulo);
            CaraSuperior.RotarX(angulo);
            CaraInferior.RotarX(angulo);
        }

        public void Escalar(float factorX, float factorY, float factorZ)
        {
            CaraFrontal.Escalar(factorX, factorY, factorZ);
            CaraPosterior.Escalar(factorX, factorY, factorZ);
            CaraIzquierda.Escalar(factorX, factorY, factorZ);
            CaraDerecha.Escalar(factorX, factorY, factorZ);
            CaraSuperior.Escalar(factorX, factorY, factorZ);
            CaraInferior.Escalar(factorX, factorY, factorZ);
        }

        public void CambiarColor(Color4 color)
        {
            CaraFrontal.Color = color;
            CaraPosterior.Color = color;
            CaraIzquierda.Color = color;
            CaraDerecha.Color = color;
            CaraSuperior.Color = color;
            CaraInferior.Color = color;
        }

        // Método para dibujar el rectángulo 3D
        public void Dibujar()
        {
            CaraFrontal.Dibujar();
            CaraPosterior.Dibujar();
            CaraIzquierda.Dibujar();
            CaraDerecha.Dibujar();
            CaraSuperior.Dibujar();
            CaraInferior.Dibujar();
        }

        public override string ToString()
        {
            return $"Rectángulo 3D:\nFrontal: {CaraFrontal}\nPosterior: {CaraPosterior}\nIzquierda: {CaraIzquierda}\nDerecha: {CaraDerecha}\nSuperior: {CaraSuperior}\nInferior: {CaraInferior}";
        }
    }
}
