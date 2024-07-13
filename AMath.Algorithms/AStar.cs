namespace Algorithm.Algorithms
{
    public static class AStar
    {
        public struct Point
        {
            public int XCoordinate { get; set; }
            public int YCoordinate { get; set; }

            public Point(int x, int y)
            {
                XCoordinate = x;
                YCoordinate = y;
            }
        }

        public struct Cell
        {
            public Point ParentCoords;
            public double FValue, GValue, HValue;
        }

        public static List<Point> FindPath(int[,] grid, int sourceX, int sourceY, int destinationX, int destinationY)
        {
            Point source = new Point(sourceX, sourceY);
            Point destination = new Point(destinationX, destinationY);
            int ROW = grid.GetLength(0);
            int COL = grid.GetLength(1);

            if (!IsValid(source.XCoordinate, source.YCoordinate, ROW, COL) || !IsValid(destination.XCoordinate, destination.YCoordinate, ROW, COL))
            {
                throw new Exception("Source or destination is invalid");
            }

            if (!IsUnBlocked(grid, source.XCoordinate, source.YCoordinate) || !IsUnBlocked(grid, destination.XCoordinate, destination.YCoordinate))
            {
                throw new Exception("Source or the destination is blocked");
            }

            if (source.XCoordinate == destination.XCoordinate && source.YCoordinate == destination.YCoordinate)
            {
                throw new Exception("We are already at the destination");
            }

            bool[,] closedList = new bool[ROW, COL];

            Cell[,] cellDetails = new Cell[ROW, COL];

            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    cellDetails[i, j].FValue = double.MaxValue;
                    cellDetails[i, j].GValue = double.MaxValue;
                    cellDetails[i, j].HValue = double.MaxValue;
                    cellDetails[i, j].ParentCoords.XCoordinate = -1;
                    cellDetails[i, j].ParentCoords.YCoordinate = -1;
                }
            }

            int currentX = source.XCoordinate; 
            int currentY = source.YCoordinate;
            cellDetails[currentX, currentY].FValue = 0.0;
            cellDetails[currentX, currentY].GValue = 0.0;
            cellDetails[currentX, currentY].HValue = 0.0;
            cellDetails[currentX, currentY].ParentCoords.XCoordinate = currentX;
            cellDetails[currentX, currentY].ParentCoords.YCoordinate = currentY;

            SortedSet<(double, Point)> openList = new SortedSet<(double, Point)>(
                Comparer<(double, Point)>.Create((a, b) => a.Item1.CompareTo(b.Item1)));

            openList.Add((0.0, new Point(currentX, currentY)));

            bool foundDest = false;

            while (openList.Count > 0)
            {
                (double f, Point pair) p = openList.Min;
                openList.Remove(p);

                currentX = p.pair.XCoordinate;
                currentY = p.pair.YCoordinate;
                closedList[currentX, currentY] = true;

                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i == 0 && j == 0)
                            continue;

                        int newX = currentX + i;
                        int newY = currentY + j;

                        if (IsValid(newX, newY, ROW, COL))
                        {
                            if (IsDestination(newX, newY, destination))
                            {
                                cellDetails[newX, newY].ParentCoords.XCoordinate = currentX;
                                cellDetails[newX, newY].ParentCoords.YCoordinate = currentY;
                                var result = TracePath(cellDetails, destination);
                                foundDest = true;
                                return result;
                            }

                            if (!closedList[newX, newY] && IsUnBlocked(grid, newX, newY))
                            {
                                double gNew = cellDetails[currentX, currentY].GValue + 1.0;
                                double hNew = CalculateHValue(newX, newY, destination);
                                double fNew = gNew + hNew;


                                if (cellDetails[newX, newY].FValue == double.MaxValue || cellDetails[newX, newY].FValue > fNew)
                                {
                                    openList.Add((fNew, new Point(newX, newY)));

                                    cellDetails[newX, newY].FValue = fNew;
                                    cellDetails[newX, newY].GValue = gNew;
                                    cellDetails[newX, newY].HValue = hNew;
                                    cellDetails[newX, newY].ParentCoords.XCoordinate = currentX;
                                    cellDetails[newX, newY].ParentCoords.YCoordinate = currentY;
                                }
                            }
                        }
                    }
                }
            }

            if (!foundDest)
                throw new Exception("Failed to find the Destination Cell");
            return null;
        }

        public static bool IsValid(int row, int col, int ROW, int COL)
        {
            return (row >= 0) && (row < ROW) && (col >= 0) && (col < COL);
        }

        public static bool IsUnBlocked(int[,] grid, int row, int col)
        {
            return grid[row, col] == 1;
        }

        public static bool IsDestination(int row, int col, Point dest)
        {
            return (row == dest.XCoordinate && col == dest.YCoordinate);
        }

        public static double CalculateHValue(int row, int col, Point dest)
        {
            return Math.Sqrt(Math.Pow(row - dest.XCoordinate, 2) + Math.Pow(col - dest.YCoordinate, 2));
        }

        public static List<Point> TracePath(Cell[,] cellDetails, Point dest)
        {
            int row = dest.XCoordinate;
            int col = dest.YCoordinate;
            List<Point> result = new List<Point>();

            Stack<Point> Path = new Stack<Point>();

            while (!(cellDetails[row, col].ParentCoords.XCoordinate == row && cellDetails[row, col].ParentCoords.YCoordinate == col))
            {
                Path.Push(new Point(row, col));
                int temp_row = cellDetails[row, col].ParentCoords.XCoordinate;
                int temp_col = cellDetails[row, col].ParentCoords.YCoordinate;
                row = temp_row;
                col = temp_col;
            }

            Path.Push(new Point(row, col));
            while (Path.Count > 0)
            {
                Point p = Path.Peek();
                Path.Pop();
                result.Add(p);
            }
            return result;
        }
    }
}
