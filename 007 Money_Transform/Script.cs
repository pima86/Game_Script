public class Number_Transform
{
    public static string Trans_str(long number)
    {
        string result = "";
        string str_number = number.ToString();
        string[] tag = new string[10] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

        int str_Length = str_number.Length;

        if (str_Length < 4) return str_number;
        switch (str_Length % 3)
        {
            case 0:
                result += str_number[0];
                result += str_number[1];
                result += str_number[2];

                if(str_number[3] != 0)
                    result += "." + str_number[3];

                break;
            case 2:
                result += str_number[0];
                result += str_number[1];

                if (str_number[2] != 0)
                    result += "." + str_number[2];

                break;
            case 1:
                result += str_number[0];

                if (str_number[1] != 0)
                    result += "." + str_number[1];

                break;
        }
        result += tag[(str_Length / 3) - 1];

        return result;
    }
}
