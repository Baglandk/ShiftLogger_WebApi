namespace ShiftModel
{
    internal class ShiftDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        internal static ShiftDTO GenerateShift()
        {
            System.Console.WriteLine("What is the name of the task");
            string inputName = System.Console.ReadLine();
            if (string.IsNullOrEmpty(inputName))
            {
                System.Console.WriteLine("Please enter a valid name");
                inputName = System.Console.ReadLine();
            }
            System.Console.WriteLine("Is it finished? please type yes or no");
            bool completed = false;
            string inputComplete = System.Console.ReadLine();
            if (inputComplete.Trim().ToLower() == "yes")
            {
                completed = true;
            }
            else
            {
                completed = false;
            }
            ShiftDTO shift = new ShiftDTO();
            shift.Name = inputName;
            shift.IsComplete = completed;
            return shift;
        }
    }
}