namespace cs360
{
    class Project2 {         
        private int _headLocation = 0;

        static void Main(string[] args)
        {
            System.Console.WriteLine("Starting Assignment 2");
            
            Project2 project2 = new Project2();
            IList<Instruction> instructions = project2.loadData();

            foreach (Instruction instruction in instructions){
                 System.Console.WriteLine(instruction);
            }           
        }

        private IList<Instruction> loadData(){
            IList<Instruction> data = new List<Instruction>();
            data.Add(new Instruction(0, 50, 9));
            data.Add(new Instruction(23, 135, 6));
            data.Add(new Instruction(25, 20, 2));
            data.Add(new Instruction(29, 25, 1));
            data.Add(new Instruction(35, 200, 9));
            data.Add(new Instruction(45, 175, 5));
            data.Add(new Instruction(57, 180, 3));
            data.Add(new Instruction(83, 99, 4));
            data.Add(new Instruction(88, 73, 5));
            data.Add(new Instruction(95, 199, 6));
            return data;
        }
    }
}