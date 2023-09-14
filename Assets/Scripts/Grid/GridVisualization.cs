using UnityEngine;

public class GridVisualization : MonoBehaviour
{
    public int gridSize = 10;
    public float cellSize = 1.0f;
    public Color gridColor = Color.gray;
    [Range(0.1f,1)]public float lineThickness; // Grosor de la línea

    void OnDrawGizmos()
    {
        DrawGrid();
    }

    void OnDrawGizmosSelected()
    {
        DrawGrid();
    }

    void DrawGrid()
    {
        Gizmos.color = gridColor;

        float halfGridSize = gridSize * 0.5f;
        float gridOffset = halfGridSize * cellSize;

        // Draw horizontal lines
        for (int i = 0; i <= gridSize; i++)
        {
            float linePosition = i * cellSize - gridOffset;
            Vector3 start = new Vector3(-gridOffset, 0, linePosition);
            Vector3 end = new Vector3(gridOffset, 0, linePosition);
            Gizmos.DrawLine(start, end);

            for (float offset = -lineThickness; offset <= lineThickness; offset += 0.01f)
            {
                Gizmos.DrawLine(start + Vector3.right * offset, end + Vector3.right * offset);
            }
        }

        // Draw vertical lines
        for (int i = 0; i <= gridSize; i++)
        {
            float linePosition = i * cellSize - gridOffset;
            Vector3 start = new Vector3(linePosition, 0, -gridOffset);
            Vector3 end = new Vector3(linePosition, 0, gridOffset);
            Gizmos.DrawLine(start, end);


            // Dibujar múltiples líneas paralelas para simular el grosor
            for (float offset = -lineThickness; offset <= lineThickness; offset += 0.01f)
            {
                Gizmos.DrawLine(start + Vector3.forward * offset, end + Vector3.forward * offset);
            }
        }
    }
}

