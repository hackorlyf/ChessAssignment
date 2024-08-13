using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core {
    public class Rook : ChessPiece {
        protected override void HighlightMoves() {
            // Highlight vertical and horizontal moves
            HighlightLineMoves(1, 0); // up
            HighlightLineMoves(-1, 0); // down
            HighlightLineMoves(0, 1); // right
            HighlightLineMoves(0, -1); // left
        }

        private void HighlightLineMoves(int rowIncrement, int colIncrement) {
            int currentRow = row + rowIncrement;
            int currentCol = column + colIncrement;

            while (ChessBoardPlacementHandler.Instance.GetTile(currentRow, currentCol) != null) {
                if (IsTileOccupied(currentRow, currentCol)) {
                    if (IsOpponentPiece(currentRow, currentCol)) {
                        RedHighlight(currentRow, currentCol);
                    }
                    break;
                }

                Highlight(currentRow, currentCol);
                currentRow += rowIncrement;
                currentCol += colIncrement;
            }
        }
    }
}
