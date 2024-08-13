using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core {
    public abstract class ChessPiece : MonoBehaviour {
        private ChessPlayerPlacementHandler playerPlacementHandler;
        [HideInInspector] public int row, column;
        [SerializeField] public string pieceSide; // "White" or "Black"
        private void Start() {
            playerPlacementHandler = GetComponent<ChessPlayerPlacementHandler>();
            if (playerPlacementHandler == null) {
                Debug.LogError("ChessPlayerPlacementHandler component is missing on this GameObject.");
                return;
            }

            row = playerPlacementHandler.row;
            column = playerPlacementHandler.column;
            
            // ChessBoardPlacementHandler.Instance.UpdatePiecePosition(-1, -1, row, column, gameObject); // Initial position
        }

        private void OnMouseDown() {
            ChessBoardPlacementHandler.Instance.ClearHighlights();
            HighlightMoves();
            Debug.Log($"{GetType().Name} at ({row}, {column}) clicked.");
        }

        protected abstract void HighlightMoves();

        protected bool IsTileOccupied(int row, int col) {
            return ChessBoardPlacementHandler.Instance.IsTileOccupied(row, col);
        }

        protected void Highlight(int row, int col) {
            ChessBoardPlacementHandler.Instance.Highlight(row, col);
        }

        protected void RedHighlight(int row, int col) {
            ChessBoardPlacementHandler.Instance.RedHighlight(row, col);
        }

        protected bool IsOpponentPiece(int row, int col) {
            var piece = ChessBoardPlacementHandler.Instance.GetPieceAtPosition(row, col);
            if (piece != null) {
                var chessPiece = piece.GetComponent<ChessPiece>();
                if (chessPiece != null && chessPiece.pieceSide != this.pieceSide) {
                    return true;
                }
            }
            return false;
        }
    }
}
