namespace cs360{
    public class ArrivalTimeComparer : IComparer<Instruction>{
        public int Compare(Instruction x, Instruction y)
        {
            int compareArrival = x.ArrivalTime.CompareTo(y.ArrivalTime);
            if (compareArrival == 0)
            {
                return x.ArrivalTime;
            }
            return compareArrival;
        }
    }
}