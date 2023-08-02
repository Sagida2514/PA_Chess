using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    private int[] dx = new[] { 1, 1, -1, -1, 1, -1, 0, 0 };
    private int[] dy = new[] { 1, -1, 1, -1, 0, 0, 1, -1 };

    public override List<Vector2Int> GetAvailableMoves(ref ChessPiece[,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> r = new List<Vector2Int>();

        for (int i = 0; i < 8; i++)
        {
            CheckCandidates(i, r, ref board, tileCountX, tileCountY);
        }

        return r;
    }


    public void CheckCandidates(int index, List<Vector2Int> r, ref ChessPiece[,] board, int tileCountX, int tileCountY)
    {
        int dX = dx[index];
        int dY = dy[index];

        for (int i = 1;
             i <= 1 && currentY + i * dY >= 0 && currentY + i * dY < tileCountY && currentX + i * dX >= 0 &&
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

    public override SpecialMove GetSpecialMoves(ref ChessPiece[,] board, ref List<Vector2Int[]> moveList,
        ref List<Vector2Int> availableMoves)
    {
        SpecialMove r = SpecialMove.None;

        var kingMove = moveList.Find(m => m[0].x == 4 && m[0].y == ((team == 0) ? 0 : 7));
        var leftRookMove = moveList.Find(m => m[0].x == 0 && m[0].y == ((team == 0) ? 0 : 7));
        var rightRookMove = moveList.Find(m => m[0].x == 7 && m[0].y == ((team == 0) ? 0 : 7));

        if (kingMove == null && currentX == 4)
        {
            int Ypos = team == 0 ? 0 : 7;

            if (leftRookMove == null)
            {
                if (board[0, Ypos] != null && board[0, Ypos].type == ChessPieceType.Rook && board[0, Ypos].team == team)
                {
                    if (board[1, Ypos] == null && board[2, Ypos] == null && board[3, Ypos] == null)
                    {
                        availableMoves.Add(new Vector2Int(2, Ypos));
                        r = SpecialMove.Castling;
                    }
                }
            }

            if (rightRookMove == null)
            {
                if (board[7, Ypos] != null && board[7, Ypos].type == ChessPieceType.Rook && board[7, Ypos].team == team)
                {
                    if (board[5, Ypos] == null && board[6, Ypos] == null)
                    {
                        availableMoves.Add(new Vector2Int(6, Ypos));
                        r = SpecialMove.Castling;
                    }
                }
            }
        }

        return r;
    }
}