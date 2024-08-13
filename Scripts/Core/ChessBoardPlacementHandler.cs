using System;
using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public sealed class ChessBoardPlacementHandler : MonoBehaviour {
    [SerializeField] private GameObject[] _rowsArray;
    [SerializeField] private GameObject _highlightPrefab;
    [SerializeField] private GameObject _redHighlightPrefab;
    private GameObject[,] _chessBoard;

    internal static ChessBoardPlacementHandler Instance;

    // Dictionary to track piece positions
    private Dictionary<(int, int), GameObject> piecePositions;

    private void Awake() {
        Instance = this;
        GenerateArray();
        piecePositions = new Dictionary<(int, int), GameObject>();
    }

    private void GenerateArray() {
        _chessBoard = new GameObject[8, 8];
        for (var i = 0; i < 8; i++) {
            for (var j = 0; j < 8; j++) {
                _chessBoard[i, j] = _rowsArray[i].transform.GetChild(j).gameObject;
            }
        }
    }

    internal GameObject GetTile(int i, int j) {
        try {
            return _chessBoard[i, j];
        } catch (Exception) {
            Debug.LogError("Invalid row or column.");
            return null;
        }
    }

    internal void Highlight(int row, int col) {
        var tile = GetTile(row, col).transform;
        if (tile == null) {
            Debug.LogError("Invalid row or column.");
            return;
        }

        Instantiate(_highlightPrefab, tile.transform.position, Quaternion.identity, tile.transform);
    }

    internal void RedHighlight(int row, int col) {
        var tile = GetTile(row, col).transform;
        if (tile == null) {
            Debug.LogError("Invalid row or column.");
            return;
        }

        Instantiate(_redHighlightPrefab, tile.transform.position, Quaternion.identity, tile.transform);
    }

    internal void ClearHighlights() {
        for (var i = 0; i < 8; i++) {
            for (var j = 0; j < 8; j++) {
                var tile = GetTile(i, j);
                if (tile.transform.childCount <= 0) continue;
                foreach (Transform childTransform in tile.transform) {
                    Destroy(childTransform.gameObject);
                }
            }
        }
    }

    internal bool IsTileOccupied(int row, int col) {
        bool isOccupied = piecePositions.ContainsKey((row, col));
        Debug.Log($"Tile at ({row}, {col}) is {(isOccupied ? "occupied" : "not occupied")}.");
        return isOccupied;
    }

    // Method to update piece positions
    internal void UpdatePiecePosition(int oldRow, int oldCol, int newRow, int newCol, GameObject piece) {
        piecePositions.Remove((oldRow, oldCol));
        piecePositions[(newRow, newCol)] = piece;
    }

    // Method to get the piece GameObject at a specific row and column
    internal GameObject GetPieceAtPosition(int row, int col) {
        if (piecePositions.TryGetValue((row, col), out var piece)) {
            return piece;
        }
        return null;
    }

    #region Highlight Testing

    // private void Start() {
    //     StartCoroutine(Testing());
    // }

    // private IEnumerator Testing() {
    //     Highlight(2, 7);
    //     yield return new WaitForSeconds(1f);
    //
    //     ClearHighlights();
    //     Highlight(2, 7);
    //     Highlight(2, 6);
    //     Highlight(2, 5);
    //     Highlight(2, 4);
    //     yield return new WaitForSeconds(1f);
    //
    //     ClearHighlights();
    //     Highlight(7, 7);
    //     Highlight(2, 7);
    //     yield return new WaitForSeconds(1f);
    // }

    #endregion
}