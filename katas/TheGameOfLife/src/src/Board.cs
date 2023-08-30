using System;

namespace TheGameOfLife
{
    public enum State
    {
        Alive,
        Dead
    }

    public class Board
    {
        private State[][] cells;

        public Board(string array)
        {
            var rows = array.Split('\n');
            cells = new State[rows.Length][];
            for (int i = 0; i < rows.Length; i++)
            {
                var row = rows[i];
                cells[i] = new State[row.Length];
                for (int j = 0; j < row.Length; j++)
                {
                    cells[i][j] = row[j] == '*' ? State.Alive : State.Dead;
                }
            }
        }

        public State at(int row, int column)
        {
            return cells[row][column];
        }

        private int livingNeighborsAt(int row, int column)
        {
            var rowCount = cells.Length;
            var columnCount = cells[0].Length;
            var count = 0;
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (r >= 0 && r < rowCount && c >= 0 && c < columnCount && cells[r][c] == State.Alive) {
                        count++; 
                    }
                }
            }
            return count;
        }

        public void generate()
        {
            var newCells = new State[cells.Length][];
            for (int r = 0; r < cells.Length; r++)
            {
                var row = cells[r];
                newCells[r] = new State[row.Length];
                for (int c = 0; c < row.Length; c++)
                {
                    var state = row[c];
                    var count = livingNeighborsAt(r, c);
                    if (state == State.Alive) {
                        if (count < 2 || count > 3) {
                            state = State.Dead;
                        }
                    }
                    newCells[r][c] = state;
                }
            }
            cells = newCells;
        }

    }
}