using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ConsoleApp3
{
    public class UncRectangulo3D
    {
        public UnCara CaraFrontal { get; set; }
        public UnCara CaraPosterior { get; set; }
        public UnCara CaraIzquierda { get; set; }
        public UnCara CaraDerecha { get; set; }
        public UnCara CaraSuperior { get; set; }
        public UnCara CaraInferior { get; set; }

        // Variables para escala y traslación
        private float scaleX = 1f, scaleY = 1f, scaleZ = 1f;
        private float offsetX = 0f, offsetY = 0f, offsetZ = 0f;
        private float rotationX = 0f, rotationY = 0f, rotationZ = 0f;

        // Constructor
        public UncRectangulo3D(UncPunto verticeCentro, float ancho, float largo, float profundidad, Color4 color)
        {
            float halfAncho = ancho / 2;
            float halfLargo = largo / 2;
            float halfProfundidad = profundidad / 2;

            // Crear las caras del rectángulo 3D
            CaraFrontal = new UnCara(
                new UncPunto(verticeCentro.X - halfAncho, verticeCentro.Y - halfLargo, verticeCentro.Z - halfProfundidad),
                new UncPunto(verticeCentro.X + halfAncho, verticeCentro.Y - halfLargo, verticeCentro.Z - halfProfundidad),
                new UncPunto(verticeCentro.X + halfAncho, verticeCentro.Y + halfLargo, verticeCentro.Z - halfProfundidad),
                new UncPunto(verticeCentro.X - halfAncho, verticeCentro.Y + halfLargo, verticeCentro.Z - halfProfundidad),
                verticeCentro,
                color);

            CaraPosterior = new UnCara(
                new UncPunto(verticeCentro.X - halfAncho, verticeCentro.Y - halfLargo, verticeCentro.Z + halfProfundidad),
                new UncPunto(verticeCentro.X + halfAncho, verticeCentro.Y - halfLargo, verticeCentro.Z + halfProfundidad),
                new UncPunto(verticeCentro.X + halfAncho, verticeCentro.Y + halfLargo, verticeCentro.Z + halfProfundidad),
                new UncPunto(verticeCentro.X - halfAncho, verticeCentro.Y + halfLargo, verticeCentro.Z + halfProfundidad),
                verticeCentro,
                color);

            CaraIzquierda = new UnCara(
                new UncPunto(verticeCentro.X - halfAncho, verticeCentro.Y - halfLargo, verticeCentro.Z - halfProfundidad),
                new UncPunto(verticeCentro.X - halfAncho, verticeCentro.Y - halfLargo, verticeCentro.Z + halfProfundidad),
                new UncPunto(verticeCentro.X - halfAncho, verticeCentro.Y + halfLargo, verticeCentro.Z + halfProfundidad),
                new UncPunto(verticeCentro.X - halfAncho, verticeCentro.Y + halfLargo, verticeCentro.Z - halfProfundidad),
                verticeCentro,
                color);

            CaraDerecha = new UnCara(
                new UncPunto(verticeCentro.X + halfAncho, verticeCentro.Y - halfLargo, verticeCentro.Z - halfProfundidad),
                new UncPunto(verticeCentro.X + halfAncho, verticeCentro.Y - halfLargo, verticeCentro.Z + halfProfundidad),
                new UncPunto(verticeCentro.X + halfAncho, verticeCentro.Y + halfLargo, verticeCentro.Z + halfProfundidad),
                new UncPunto(verticeCentro.X + halfAncho, verticeCentro.Y + halfLargo, verticeCentro.Z - halfProfundidad),
                verticeCentro,
                color);

            CaraSuperior = new UnCara(
                new UncPunto(verticeCentro.X - halfAncho, verticeCentro.Y + halfLargo, verticeCentro.Z - halfProfundidad),
                new UncPunto(verticeCentro.X + halfAncho, verticeCentro.Y + halfLargo, verticeCentro.Z - halfProfundidad),
                new UncPunto(verticeCentro.X + halfAncho, verticeCentro.Y + halfLargo, verticeCentro.Z + halfProfundidad),
                new UncPunto(verticeCentro.X - halfAncho, verticeCentro.Y + halfLargo, verticeCentro.Z + halfProfundidad),
                verticeCentro,
                color);

            CaraInferior = new UnCara(
                new UncPunto(verticeCentro.X - halfAncho, verticeCentro.Y - halfLargo, verticeCentro.Z - halfProfundidad),
                new UncPunto(verticeCentro.X + halfAncho, verticeCentro.Y - halfLargo, verticeCentro.Z - halfProfundidad),
                new UncPunto(verticeCentro.X + halfAncho, verticeCentro.Y - halfLargo, verticeCentro.Z + halfProfundidad),
                new UncPunto(verticeCentro.X - halfAncho, verticeCentro.Y - halfLargo, verticeCentro.Z + halfProfundidad),
                verticeCentro,
                color);
        }


        // Métodos para aplicar transformaciones a todas las caras
        // Método para aplicar transformaciones de traslación
        public void Trasladar(float dx, float dy, float dz)
        {
            offsetX += dx;
            offsetY += dy;
            offsetZ += dz;
        }

        // Método para aplicar transformaciones de escala
        public void Escalar(float factorX, float factorY, float factorZ)
        {
            scaleX *= factorX;
            scaleY *= factorY;
            scaleZ *= factorZ;
        }

        // Método para aplicar rotación en el eje X
        public void RotarX(float angulo)
        {
            rotationX += angulo;
        }

        // Método para aplicar rotación en el eje Y
        public void RotarY(float angulo)
        {
            rotationY += angulo;
        }

        // Método para aplicar rotación en el eje Z
        public void RotarZ(float angulo)
        {
            rotationZ += angulo;
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
        // Método para dibujar el rectángulo 3D con todas las transformaciones aplicadas
        public void Dibujar()
        {
            GL.PushMatrix(); // Guardar el estado actual de la matriz

            // Aplicar traslación, escala y rotaciones a todo el rectángulo
            GL.Translate(offsetX, offsetY, offsetZ);
            GL.Rotate(rotationX, 1.0, 0.0, 0.0); // Rotación en X
            GL.Rotate(rotationY, 0.0, 1.0, 0.0); // Rotación en Y
            GL.Rotate(rotationZ, 0.0, 0.0, 1.0); // Rotación en Z
            GL.Scale(scaleX, scaleY, scaleZ);

            // Dibujar cada cara
            CaraFrontal.Dibujar();
            CaraPosterior.Dibujar();
            CaraIzquierda.Dibujar();
            CaraDerecha.Dibujar();
            CaraSuperior.Dibujar();
            CaraInferior.Dibujar();

            GL.PopMatrix(); // Restaurar el estado original de la matriz
        }

        public override string ToString()
        {
            return $"Rectángulo 3D:\nFrontal: {CaraFrontal}\nPosterior: {CaraPosterior}\nIzquierda: {CaraIzquierda}\nDerecha: {CaraDerecha}\nSuperior: {CaraSuperior}\nInferior: {CaraInferior}";
        }
    }
}
