using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core {
    public class Pawn : ChessPiece {
        protected override void HighlightMoves() {
            if (!IsTileOccupied(row + 1, column)) {
                Highlight(row + 1, column);

                if (row == 1 && !IsTileOccupied(row + 2, column)) {
                    Highlight(row + 2, column);
                }
            }

            // Check for diagonal captures
            if (IsOpponentPiece(row + 1, column - 1)) {
                RedHighlight(row + 1, column - 1);
            }
            if (IsOpponentPiece(row + 1, column + 1)) {
                RedHighlight(row + 1, column + 1);
            }
        }
    }
}
