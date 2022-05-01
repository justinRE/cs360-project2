namespace cs360{
    public class Disk{
        private static int MOVEMENT_TIME_CONSTANT = 12;
        private static int ROTATION_DELAY = 5;
        private int rotationCounter = 0;
        private int totalInstructionsProcessed = 0;

        public int SearchTime
        {
            get { return rotationCounter * ROTATION_DELAY; }
        }

        public double calculateSeekTime(Instruction previousInstruction,Instruction currentInstruction){
            totalInstructionsProcessed++;
            double seekTimeTmp = 0;
            
            if(previousInstruction.TrackRequest > currentInstruction.TrackRequest){
                rotationCounter++;
                seekTimeTmp = (256-previousInstruction.TrackRequest)+currentInstruction.TrackRequest;
            }else{
                seekTimeTmp = Math.Abs(previousInstruction.TrackRequest-currentInstruction.TrackRequest);
            }
            double seekTime = MOVEMENT_TIME_CONSTANT + (0.1 * seekTimeTmp);

            return seekTime;

        }

        public String getStats(){
            return "\n:::Disk Stats::: " + 
                   "\nDisk Search Time: " + this.SearchTime + 
                   "\nTotal Instructions: " + this.totalInstructionsProcessed;
        }
    }
}