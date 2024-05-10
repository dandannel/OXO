namespace TicTacToe;
class Program
{
    public static void Main(string[] args)
    {
        char[,] arr = new char[3,3];

        int numbers = 1;

        for(int i = 0; i < 3; i ++)
        {
            for(int j = 0; j < 3; j++)
            {
                arr[i,j] = Convert.ToChar(numbers.ToString());
                numbers++;
            }
        }
        //Początek
        Show(arr);
        //Gra
        for(int i = 2; i < 11; i++)
        {
            if(i % 2 == 0)
            {
                arr = Show(NextArray(arr));
            }
            else
            {
                arr = Show(ComputerTime(arr));
            } 
            
            if(WinChecker(arr) != "Noone won :(")
            {
                Console.WriteLine(WinChecker(arr));
                return;
            }
        }
    }

    public static char[,] Show(char[,] arr)
    {
        for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        return arr;
    }

    public static char ValidChar()
    {
        bool not_valid = true;
        char input = ' ';

        while(not_valid)
        {
            string b = Console.ReadLine();
            bool check_numbers = b == "1" || b == "2" || b == "3"
                || b == "4" || b == "5" || b == "6"
                || b == "7" || b == "8" || b == "9";
            if(!check_numbers)
                {   
                    Console.WriteLine("Choose a number between 1 and 9");
                }
            else
                {
                    input = Convert.ToChar(b);
                    not_valid = false;
                }
        }
        return input;
    }

    public static char[,] NextArray(char[,] arr)
    {
        char number = ValidChar();
        int num = Convert.ToInt32(number - 48);
        bool check = true;

        while(check)
        {
            if(!Find_Os(arr).Contains(num))
            {
                check = false;
            }
            else
            {
                Console.WriteLine("Give a number that was not already used");
                number = ValidChar();
                num = Convert.ToInt32(number - 48);
            }
        }

        switch(number)
        {
            case '1': arr[0,0] = 'O'; break;
            case '2': arr[0,1] = 'O'; break;
            case '3': arr[0,2] = 'O'; break;
            case '4': arr[1,0] = 'O'; break;
            case '5': arr[1,1] = 'O'; break;
            case '6': arr[1,2] = 'O'; break;
            case '7': arr[2,0] = 'O'; break;
            case '8': arr[2,1] = 'O'; break;
            case '9': arr[2,2] = 'O'; break;

            default: 
            {Console.WriteLine("Dont please"); break;}
        }
        return arr;
    }

    public static char[,] ComputerTime(char[,] arr)
    {
        Random random = new Random();
        int c;

        do
        {
            c = random.Next(1,10);
        }
        while(Find_Os(arr).Contains(c));
        Console.WriteLine(c);
        
        char d = Convert.ToChar(0x30 + c);

        switch(d)
        {
            case '1': arr[0,0] = 'X'; break;
            case '2': arr[0,1] = 'X'; break;
            case '3': arr[0,2] = 'X'; break;
            case '4': arr[1,0] = 'X'; break;
            case '5': arr[1,1] = 'X'; break;
            case '6': arr[1,2] = 'X'; break;
            case '7': arr[2,0] = 'X'; break;
            case '8': arr[2,1] = 'X'; break;
            case '9': arr[2,2] = 'X'; break;

            default: 
            {Console.WriteLine("Dont please2"); break;}
        }
        return arr;
    }

    public static List<int> Find_Os(char[,] arr)
    {
        int number = 1;
        List<int> os_positions = new List<int>{};
        for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(arr[i,j] == 'O' || arr[i,j] == 'X')
                    {
                        os_positions.Add(number);
                    }
                    number++;
                }
            }
        return os_positions;
    }

    public static string WinChecker(char[,] arr)
    {
        string player_win = "You won uwu";
        string computer_win = "Computer won owo";
        string no_win = "Noone won :(";
        List<int> checker_O = new List<int> {};
        List<int> checker_X = new List<int> {};
        int number = 1;

        for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(arr[i,j] == 'O')
                    {
                        checker_O.Add(number);
                    }
                    if(arr[i,j] == 'X')
                    {
                        checker_X.Add(number);
                    }
                    number++;
                }
            }

        if(checker_O.Contains(1) && checker_O.Contains(2) && checker_O.Contains(3) ||
            checker_O.Contains(4) && checker_O.Contains(5) && checker_O.Contains(6) ||
            checker_O.Contains(7) && checker_O.Contains(8) && checker_O.Contains(9) ||
            checker_O.Contains(1) && checker_O.Contains(4) && checker_O.Contains(7) ||
            checker_O.Contains(2) && checker_O.Contains(5) && checker_O.Contains(8) ||
            checker_O.Contains(3) && checker_O.Contains(6) && checker_O.Contains(9) ||
            checker_O.Contains(1) && checker_O.Contains(5) && checker_O.Contains(9) ||
            checker_O.Contains(3) && checker_O.Contains(5) && checker_O.Contains(7))
        {
            return player_win;
        }
        if(checker_X.Contains(1) && checker_X.Contains(2) && checker_X.Contains(3) ||
            checker_X.Contains(4) && checker_X.Contains(5) && checker_X.Contains(6) ||
            checker_X.Contains(7) && checker_X.Contains(8) && checker_X.Contains(9) ||
            checker_X.Contains(1) && checker_X.Contains(4) && checker_X.Contains(7) ||
            checker_X.Contains(2) && checker_X.Contains(5) && checker_X.Contains(8) ||
            checker_X.Contains(3) && checker_X.Contains(6) && checker_X.Contains(9) ||
            checker_X.Contains(1) && checker_X.Contains(5) && checker_X.Contains(9) ||
            checker_X.Contains(3) && checker_X.Contains(5) && checker_X.Contains(7))
        {
            return computer_win;
        }
        else
        {
            return no_win;
        }
    }
}
