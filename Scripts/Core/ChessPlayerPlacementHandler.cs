using System;
using UnityEngine;

namespace Chess.Scripts.Core {
    public class ChessPlayerPlacementHandler : MonoBehaviour {
        [SerializeField] public int row, column;

        private void Start() {
            ChessBoardPlacementHandler.Instance.UpdatePiecePosition(-1, -1, row, column, gameObject); // Initial position
            transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;
        }

        // ONLY FOR MY TEST PURPOSE
        // private void OnMouseDown() {
        //     ChessBoardPlacementHandler.Instance.ClearHighlights();

        //     Debug.Log($"Pawn at ({row}, {column}) clicked.");

        //     // Check if the tile directly in front is not occupied
        //     if (!ChessBoardPlacementHandler.Instance.IsTileOccupied(row + 1, column)) {
        //         ChessBoardPlacementHandler.Instance.Highlight(row + 1, column);

        //         // Check if the pawn is in its initial position and the tile two steps ahead is not occupied
        //         if (row == 1 && !ChessBoardPlacementHandler.Instance.IsTileOccupied(row + 2, column)) {
        //             ChessBoardPlacementHandler.Instance.Highlight(row + 2, column);
        //         }
        //     }

        //     // Check for diagonal captures
        //     // if (ChessBoardPlacementHandler.Instance.GetTile(row + 1, column - 1) != null &&
        //     //     ChessBoardPlacementHandler.Instance.IsTileOccupied(row + 1, column - 1)) {
        //     //     ChessBoardPlacementHandler.Instance.Highlight(row + 1, column - 1);
        //     // }
        //     // if (ChessBoardPlacementHandler.Instance.GetTile(row + 1, column + 1) != null &&
        //     //     ChessBoardPlacementHandler.Instance.IsTileOccupied(row + 1, column + 1)) {
        //     //     ChessBoardPlacementHandler.Instance.Highlight(row + 1, column + 1);
        //     // }

        //     Debug.Log("Clicked");
        // }
    }
}