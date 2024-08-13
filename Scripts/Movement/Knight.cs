using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core {
    public class Knight : ChessPiece {
        protected override void HighlightMoves() {
            int[,] knightMoves = {
                {2, 1}, {2, -1}, {-2, 1}, {-2, -1},
                {1, 2}, {1, -2}, {-1, 2}, {-1, -2}
            };

            for (int i = 0; i < knightMoves.GetLength(0); i++) {
                int newRow = row + knightMoves[i, 0];
                int newCol = column + knightMoves[i, 1];

                if (ChessBoardPlacementHandler.Instance.GetTile(newRow, newCol) != null) {
                    if (IsOpponentPiece(newRow, newCol)) {
                        RedHighlight(newRow, newCol);
                    } else if (!IsTileOccupied(newRow, newCol)) {
                        Highlight(newRow, newCol);
                    }
                }
            }
        }
    }
}
