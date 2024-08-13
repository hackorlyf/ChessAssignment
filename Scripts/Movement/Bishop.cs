using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core {
    public class Bishop : ChessPiece {
        protected override void HighlightMoves() {
            // Highlight diagonal moves
            HighlightLineMoves(1, 1); // up-right
            HighlightLineMoves(1, -1); // up-left
            HighlightLineMoves(-1, 1); // down-right
            HighlightLineMoves(-1, -1); // down-left
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
