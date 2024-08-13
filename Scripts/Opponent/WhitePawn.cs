using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core {
    public class WhitePawn : ChessPiece {
        // Needed to define this just because it's and abstract function and we needed to inherit the basecase chessPeice
        protected override void HighlightMoves() {
            // No need since it's just an opponent piece 
        }
    }
}
