using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core {
    public class King : ChessPiece {
        protected override void HighlightMoves() {
            int[,] kingMoves = {
                {1, 0}, {-1, 0}, {0, 1}, {0, -1},
                {1, 1}, {1, -1}, {-1, 1}, {-1, -1}
            };

            for (int i = 0; i < kingMoves.GetLength(0); i++) {
                int newRow = row + kingMoves[i, 0];
                int newCol = column + kingMoves[i, 1];

                if (ChessBoardPlacementHandler.Instance.GetTile(newRow, newCol) != null) {
                    if (IsTileOccupied(newRow, newCol)) {
                        if (IsOpponentPiece(newRow, newCol)) {
                            RedHighlight(newRow, newCol);
                        }
                    } else {
                        Highlight(newRow, newCol);
                    }
                }
            }
        }
    }
}
