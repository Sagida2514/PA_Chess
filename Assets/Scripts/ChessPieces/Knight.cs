using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    static int[] dx = new int[8]
    {
        -1, -1, 1, 1, -2, -2, 2, 2
    };

    static int[] dy = new int[8]
    {
        -2, 2, -2, 2, -1, 1, -1, 1
    };

    public override List<Vector2Int> GetAvailableMoves(ref ChessPiece[,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> r = new List<Vector2Int>();

        for (int i = 0; i < 8; i++)
        {
            int nx = currentX + dx[i];
            int ny = currentY + dy[i];

            if (nx >= 0 && nx < tileCountX && ny >= 0 && ny < tileCountY)
            {
                if (board[nx, ny] == null || board[nx, ny].team != team)
                {
                    r.Add(new Vector2Int(nx, ny));
                }
            }
        }

        return r;
    }
}