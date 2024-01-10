namespace LangtonsAnt
{
    public class Ant
    {
        public int I { get; set; }
        public int J { get; set; }
        public AntDirection Direction { get; set; }
        public Ant(int i, int j, AntDirection direction)
        {
            I = i;
            J = j;
            Direction = direction;
        }
        public virtual byte Act(byte oldValue)
        {
            byte ret;
            if (oldValue == 0)
            {
                ret = 1;
                RotateCW();
            }
            else
            {
                ret = 0;
                RotateCCW();
            }
            Move();
            return ret;
        }
        protected void Move()
        {
            if (AntDirection.Up == Direction) I--;
            if (AntDirection.Right == Direction) J++;
            if (AntDirection.Down == Direction) I++;
            if (AntDirection.Left == Direction) J--;
        }
        public void RotateCW()
        {
            Direction = (AntDirection)(((int)Direction + 1) % 4);
        }
        public void RotateCCW()
        {
            Direction = (AntDirection)((int)Direction == 0 ? 3 : (int)Direction - 1);
        }
    }

}