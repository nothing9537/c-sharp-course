Console.WriteLine("Hello!");

List<string> todos = new List<string>();
string choice;

do
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODO's");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");

    choice = Console.ReadLine()!.ToUpper();

    switch (choice)
    {
        case "S":
            HandleUserSeeAllTodos();
            break;
        case "A":
            HandleUserAddTodo();
            break;
        case "R":
            HandleUserRemoveTodo();
            break;
        default:
            Console.WriteLine("Incorrect input. Please select a valid option.");
            continue;
    }
} while (choice != "E");

void HandleUserSeeAllTodos()
{
    Console.WriteLine("Your current TODO list: \n");

    if (todos.Count == 0)
    {
        Console.WriteLine("Empty. \n");
    }
    else
    {
        for (int i = 0; i < todos.Count; i++)
        {
            string todo = todos[i];

            Console.WriteLine($"{i + 1}. {todo}");
        }

        Console.WriteLine("\n");
    }
}

void HandleUserAddTodo()
{
    Console.WriteLine("Please provide a description of TODO: \n");

    do
    {
        string todoDescription = Console.ReadLine()!;

        if (todoDescription == "")
        {
            Console.WriteLine("Enter non-empty description.");
            continue;
        }
        else if (todos.Contains(todoDescription))
        {
            Console.WriteLine("Description can be only unique.");
            continue;
        }
        else
        {
            todos.Add(todoDescription);
            break;
        }

    } while (true);

    HandleUserSeeAllTodos();
}

void HandleUserRemoveTodo()
{
    HandleUserSeeAllTodos();

    Console.WriteLine("Please enter the index of the TODO you want to delete:");

    bool isParsedAndIndexValid;

    do
    {
        string userInput = Console.ReadLine()!;
        isParsedAndIndexValid = int.TryParse(userInput, out int index);

        if (isParsedAndIndexValid)
        {
            if (index <= todos.Count)
            {
                todos.RemoveAt(index - 1);
            }
            else
            {
                Console.WriteLine("Index larger than TODO's count.");
                isParsedAndIndexValid = false;
                continue;
            }
        }
        else
        {
            Console.WriteLine("Please provide a valid index.");
        }
    } while (!isParsedAndIndexValid);

    HandleUserSeeAllTodos();
}

Console.ReadKey();