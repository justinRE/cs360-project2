namespace cs360{
    public class LookComparer : IComparer<Instruction>{
        public int Compare(Instruction x, Instruction y)
        {
            int compareTrack = x.TrackRequest.CompareTo(y.TrackRequest);
            if (compareTrack == 0)
            {
                return x.TrackRequest;
            }
            return compareTrack;
        }
    }
}