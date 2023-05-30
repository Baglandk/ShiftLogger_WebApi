using Operations_list;
internal class DialogWindow
{
    public static async Task AskUserInputAsync()
    {
        Operations.BasicInfo();
        System.Console.WriteLine(@"Welcome to the shift logger app! Choose a option to continue the process
                                '1' -- Get all the information,
                                '2' -- Get info about a speciffic Id,
                                '3' -- Post a shift,
                                '4' -- Update a shift,
                                '5' -- Delete a shift,
                                '0' -- Show the initial page");
        string? option = System.Console.ReadLine();
        switch (option)
        {
            case "0":
                await AskUserInputAsync();
                break;
            case "1":
                var items = await Operations.GetAllAsync();
                foreach (var item in items)
                {
                    System.Console.WriteLine(item.Id + " -- " + item.Name + " is complete -> " + item.IsComplete);
                }
                break;
            case "2":
                var item2 = await Operations.GetOneAsync();
                System.Console.WriteLine(item2.Id + " -- " + item2.Name + " is complete -> " + item2.IsComplete);
                break;
            case "3":
                await Operations.PostAsync();
                break;
            case "4":
                await Operations.UpdateAsync();
                break;
            case "5":
                await Operations.DeleteAsync();
                break;
            default:
                System.Console.WriteLine("Please follow the instruction");
                await AskUserInputAsync();
                break;
        }
    }
}