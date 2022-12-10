using System.Linq;

public static class Day08
{
    public static string PartOne()
    {
        var input = File.ReadAllLines("day08_input");

        Tree[,] map = new Tree[input[0].Length, input.Count()];
        List<Tree> treeList = new List<Tree>();

        int row = 0;
        foreach(string line in input)
        {
            int column = 0;
            foreach(char c in line)
            {
                var tree = new Tree(map, int.Parse(c.ToString()), new System.Drawing.Point(column, row));
                map[column,row] = tree;
                treeList.Add(tree);
                column++;
            }

            row++;
        }

        return treeList.Where(t => t.IsVisible).Count().ToString();;
    }

    public static string PartTwo()
    {
        return "";
    }

    private class Tree
    {
        private Tree[,] _treeMap;
        private int _height;
        private System.Drawing.Point _position;

        public Tree(Tree[,] treeMap, int height, System.Drawing.Point position)
        {
            _treeMap = treeMap;
            _height = height;
            _position = position;
        }

        public bool IsVisible
        {
            get
            {
                if(NegativeX?.TopTrees.All(t => t._height < _height) ?? true)
                    return true;
                if(PositiveX?.BottomTrees.All(t => t._height < _height) ?? true)
                    return true;
                if(NegativeY?.LeftTrees.All(t => t._height < _height) ?? true)
                    return true;
                if(PositiveY?.RightTrees.All(t => t._height < _height) ?? true)
                    return true; 
                return false;
            }
        }


        private IEnumerable<Tree> TopTrees
        {
            get
            {
                if(NegativeX != null)
                    foreach(var t in NegativeX.TopTrees)
                        yield return t;
                yield return this;
            }
        }
        private IEnumerable<Tree> BottomTrees
        {
            get
            {
                if(PositiveX != null)
                    foreach(var t in PositiveX.BottomTrees)
                        yield return t;
                yield return this;
            }
        }
        private IEnumerable<Tree> LeftTrees
        {
            get
            {
                if(NegativeY != null)
                    foreach(var t in NegativeY.LeftTrees)
                        yield return t;
                yield return this;
            }
        }
        private IEnumerable<Tree> RightTrees
        {
            get
            {
                if(PositiveY != null)
                    foreach(var t in PositiveY.RightTrees)
                        yield return t;
                yield return this;
            }
        }

        private Tree? NegativeX => _position.X == 0 ? null : _treeMap[_position.X-1,_position.Y];
        private Tree? PositiveX => _position.X == _treeMap.GetLength(0)-1 ? null : _treeMap[_position.X+1,_position.Y];

        private Tree? NegativeY => _position.Y == 0 ? null : _treeMap[_position.X, _position.Y - 1];
        private Tree? PositiveY => _position.Y == _treeMap.GetLength(1)-1 ? null : _treeMap[_position.X, _position.Y+1];
    }

}