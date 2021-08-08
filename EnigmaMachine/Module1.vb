Imports System.String
Module Module1

    Sub Main()
        Dim index As Integer
        Dim Operation As String
        'Operation = Console.ReadLine()
        Operation = "DECODE"

        Dim pseudoRandomNumber As Integer
        'pseudoRandomNumber = Console.ReadLine()
        pseudoRandomNumber = 5
        Dim rotors() As String = {
        "BDFHJLCPRTXVZNYEIWGAKMUSQO",
        "AJDKSIRUXBLHWTMCQGZNPYFVOE",
        "EKMFLGDQVZNTOWYHXUSPAIBRCJ",
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        }
        'For i As Integer = 0 To 2
        '    Dim rotor As String
        '    rotor = Console.ReadLine()
        '    rotors(i) = rotor
        'Next

        Dim message As String
        'message = Console.ReadLine()
        message = "XPCXAUPHYQALKJMGKRWPGYHFTKRFFFNOUTZCABUAEHQLGXREZ"
        '"ALWAURKQEQQWLRAWZHUYKVN"
        '"WEATHERREPORTWINDYTODAY"
        Console.WriteLine("Original message is = " & message)
        ' Write an answer using Console.WriteLine()
        ' To debug: Console.Error.WriteLine("Debug messages...")
        'Console.WriteLine("KQF")

        If Operation = "ENCODE" Then
            For i As Integer = 0 To message.Length - 1
                message = message.Remove(i, 1).Insert(i, rotors(3).Substring(((i + rotors(3).IndexOf(message(i)) + pseudoRandomNumber) Mod rotors(3).Length), 1))
                index = rotors(3).IndexOf(message(i))
                message = message.Remove(i, 1).Insert(i, rotors(0).Substring(index, 1))

                index = rotors(3).IndexOf(message(i))
                message = message.Remove(i, 1).Insert(i, rotors(1).Substring(index, 1))

                index = rotors(3).IndexOf(message(i))
                message = message.Remove(i, 1).Insert(i, rotors(2).Substring(index, 1))
            Next
        End If

        If Operation = "DECODE" Then
            For i As Integer = 0 To message.Length - 1
                index = rotors(2).IndexOf(message(i))
                message = message.Remove(i, 1).Insert(i, rotors(3).Substring(index, 1))
                index = rotors(1).IndexOf(message(i))
                message = message.Remove(i, 1).Insert(i, rotors(3).Substring(index, 1))
                index = rotors(0).IndexOf(message(i))
                message = message.Remove(i, 1).Insert(i, rotors(3).Substring(index, 1))
                message = message.Remove(i, 1).Insert(i, rotors(3).Substring(((((rotors(3).IndexOf(message(i)) - pseudoRandomNumber - i) Mod rotors(3).Length) + rotors(3).Length) Mod rotors(3).Length), 1))
            Next
        End If
        Console.WriteLine(Operation & " is = " & message)

        ''Mapping 2nd rotor
        'For i As Integer = 0 To message.Length - 1
        '    index = rotors(3).IndexOf(message(i))
        '    message = message.Remove(i, 1).Insert(i, rotors(1).Substring(index, 1))
        '    'Console.WriteLine(" - " & message)
        'Next
        'Console.WriteLine("Mapping rotor 2 is = " & message)

        ''Mapping 3nd rotor
        'For i As Integer = 0 To message.Length - 1
        '    index = rotors(3).IndexOf(message(i))
        '    message = message.Remove(i, 1).Insert(i, rotors(2).Substring(index, 1))
        '    'Console.WriteLine(" - " & message)
        'Next
        'Console.WriteLine("Mapping rotor 3 is = " & message)

        Console.ReadLine()

    End Sub

End Module
