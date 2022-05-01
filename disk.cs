namespace cs360{
    public class Disk{
        private static int MOVEMENT_TIME_CONSTANT = 12;

        public double calculateSeekTime(Instruction previousInstruction,Instruction currentInstruction){
            double tmp = 0;
            if(previousInstruction.TrackRequest > currentInstruction.TrackRequest){
                tmp = (256-previousInstruction.TrackRequest)+currentInstruction.TrackRequest;
            }else{
                tmp = Math.Abs(previousInstruction.TrackRequest-currentInstruction.TrackRequest);
            }

            currentInstruction.SeekTime = MOVEMENT_TIME_CONSTANT + (0.1 * tmp);
            return currentInstruction.SeekTime;

        }
    }
}