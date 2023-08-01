using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece
{
    private int[] dx = new[] { 1, -1, 0, 0 };
    private int[] dy = new[] { 0, 0, 1, -1 };
    List<Vector2Int> r = new List<Vector2Int>();

    public override List<Vector2Int> GetAvailableMoves(ref ChessPiece[,] board, int tileCountX, int tileCountY)
    {
        r.Clear();
        for (int i = 0; i < 4; i++)
        {
            CheckCandidates(i, ref board, tileCountX, tileCountY);
        }

        return r;
    }

    public void CheckCandidates(int index, ref ChessPiece[,] board, int tileCountX, int tileCountY)
    {
        int dX = dx[index];
        int dY = dy[index];

        for (int i = 1;
             i <= 7 && currentY + i * dY >= 0 && currentY + i * dY < tileCountY && currentX + i * dX >= 0 &&
             currentX + i * dX < tileCountX;
             i++)
        {
            if (board[currentX + i * dX, currentY + i * dY] == null)
            {
                r.Add(new Vector2Int(currentX + i * dX, currentY + i * dY));
            }

            if (board[currentX + i * dX, currentY + i * dY] != null)
            {
                if (board[currentX + i * dX, currentY + i * dY].team != team)
                {
                    r.Add(new Vector2Int(currentX + i * dX, currentY + i * dY));
                }

                break;
            }
        }
    }
}