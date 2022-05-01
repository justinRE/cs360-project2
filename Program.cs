// Hello World! program
namespace cs360
{
    class Project2 {         
        static void Main(string[] args)
        {
            System.Console.WriteLine("Starting Assignment 2");
            
            Project2 project2 = new Project2();
            List<ReadDiskRequest> data = project2.loadData();

            foreach (ReadDiskRequest item in data){
                 System.Console.WriteLine(item);
            }           
        }

        private List<ReadDiskRequest> loadData(){
            List<ReadDiskRequest> data = new List<ReadDiskRequest>();
            data.Add(new ReadDiskRequest(0, 50, 9));
            data.Add(new ReadDiskRequest(23, 135, 6));
            return data;
        }
    }
}