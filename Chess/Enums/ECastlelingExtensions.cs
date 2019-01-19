﻿/*
ChessLib, a chess data structure library

MIT License

Copyright (c) 2017-2019 Rudy Alex Kohn

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

namespace Rudz.Chess.Enums
{
    using System;
    using System.Runtime.CompilerServices;
    using Types;

    public static class ECastlelingExtensions
    {
        private static readonly ECastlelingRights[] OoAllowedMask = { ECastlelingRights.WhiteKing, ECastlelingRights.BlackKing };

        private static readonly ECastlelingRights[] OooAllowedMask = { ECastlelingRights.WhiteQueen, ECastlelingRights.BlackQueen };

        private static readonly Square[] OoKingTo = { ESquare.g1, ESquare.g8 };

        private static readonly Square[] OooKingTo = { ESquare.c1, ESquare.c8 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Square GetKingCastleTo(this ECastleling castleType, Player side)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (castleType)
            {
                case ECastleling.Short:
                    return OoKingTo[side.Side];

                case ECastleling.Long:
                    return OooKingTo[side.Side];

                default:
                    throw new ArgumentOutOfRangeException(nameof(castleType), castleType, null);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ECastlelingRights GetCastleAllowedMask(this ECastleling castleType, Player side)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (castleType)
            {
                case ECastleling.Short:
                    return OoAllowedMask[side.Side];

                case ECastleling.Long:
                    return OooAllowedMask[side.Side];

                default:
                    throw new ArgumentOutOfRangeException(nameof(castleType), castleType, null);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ECastlelingRights GetCastleAllowedMask(this Player side)
        {
            return OoAllowedMask[side.Side] | OooAllowedMask[side.Side];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ECastlelingRights GetCastleAllowedMask(this ECastleling castleType)
        {
            switch (castleType)
            {
                case ECastleling.None:
                    return ECastlelingRights.None;
                case ECastleling.Short:
                    return OoAllowedMask[0] | OoAllowedMask[1];
                case ECastleling.Long:
                    return OooAllowedMask[0] | OooAllowedMask[1];
                default:
                    throw new ArgumentOutOfRangeException(nameof(castleType), castleType, null);
            }
        }


        public static string GetCastlelingString(this ECastleling @this)
        {
            switch (@this)
            {
                case ECastleling.None:
                    return string.Empty;

                case ECastleling.Short:
                    return "O-O";

                case ECastleling.Long:
                    return "O-O-O";

                case ECastleling.CastleNb:
                    return string.Empty;

                default:
                    throw new ArgumentOutOfRangeException(nameof(@this), @this, null);
            }
        }

        public static string GetCastlelingString(Square toSquare, Square fromSquare)
        {
            return toSquare < fromSquare ? "O-O-O" : "O-O";
        }
    }
}