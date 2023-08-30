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

    }
}