Module Module1

    Sub Main()
        'GLC
        'S -> z M N z
        'M -> a M a
        'M -> z
        'N -> b N b
        'N -> z
        'EJEMPLO DE PILA
        Pila("bazzbzbzab")
        'EJEMPLO DE COLA

    End Sub

    Sub Pila(ByRef texto As String)
        Dim pila As New Stack
        Dim destino As Char = "i"
        Dim origen As Char
        Dim pop As Char
        Dim push As String

        Dim i As Integer = 0
        Dim entrada As Char
        Dim prod As Char = "S"
        Dim tope As Integer = texto.Count
        Dim fin As Boolean = True

        While (fin)

            Select Case destino
                Case "i"
                    'i  --  --  P   #
                    push = "#"
                    pila.Push(push)
                    origen = destino
                    destino = "P"
                    imprimir(origen, "", pop, destino, push)
                Case "P"
                    'P  --  --  q   S
                    push = "S"
                    pila.Push(push)
                    origen = destino
                    destino = "q"
                    imprimir(origen, "", pop, destino, push)
                Case "q"
                    If (i <= tope) Then
                        entrada = texto.Chars(i)
                        Select Case pila.Peek
                            Case "z"
                                'q  z   z   q   --
                                pop = pila.Pop
                                imprimir(origen, "z", pop, destino, push)
                            Case "a"
                                'q  a   a   q   --
                                pop = pila.Pop
                                imprimir(origen, "a", pop, destino, push)
                            Case "b"
                                'q  b   b   q   --
                                pop = pila.Pop
                                imprimir(origen, "b", pop, destino, push)
                            Case "S"
                                'q  --  S   q   zMNz
                                If (entrada = "z") Then
                                    pop = pila.Pop
                                    push = "zMNz"
                                    pila.Push("z")
                                    pila.Push("N")
                                    pila.Push("M")
                                    pila.Push("z")
                                    origen = destino
                                    i += 1
                                    imprimir(origen, "", pop, destino, push)
                                Else
                                    Console.WriteLine("Error, Se esperaba una z")
                                    i += 1
                                    'Exit While
                                End If
                            Case "M"
                                If (entrada = "a") Then
                                    'q  --  --  q   aMa
                                    pila.Pop()
                                    push = "aMa"
                                    pila.Push("a")
                                    pila.Push("M")
                                    pila.Push("a")
                                    i += 1
                                    imprimir(origen, "", pop, destino, push)
                                ElseIf (entrada = "z") Then
                                    'q  --  --  q   z
                                    pila.Pop()
                                    push = "z"
                                    pila.Push(push)
                                    i += 1
                                    imprimir(origen, "", pop, destino, push)
                                Else
                                    Console.WriteLine("Error, se esperaba una a o una z")
                                    i += 1
                                    'Exit While
                                End If
                            Case "N"
                                If (entrada = "b") Then
                                    'q  --  --  q   bNb
                                    pila.Pop()
                                    push = "bNb"
                                    pila.Push("b")
                                    pila.Push("N")
                                    pila.Push("b")
                                    i += 1
                                    imprimir(origen, "", pop, destino, push)
                                ElseIf (entrada = "z") Then
                                    'q  --  --  q   z
                                    pila.Pop()
                                    push = "z"
                                    pila.Push(push)
                                    i += 1
                                    imprimir(origen, "", pop, destino, push)
                                Else
                                    Console.WriteLine("Error, se esperaba una b o una z")
                                    i += 1
                                    'Exit While
                                End If
                            Case "#"
                                pop = pila.Pop
                                destino = "f"
                                imprimir(origen, "", pop, destino, push)
                        End Select
                    End If

                Case "f"
                    fin = False
                    Console.WriteLine("Automata de pila finalizado")
            End Select
            pop = Nothing
            push = Nothing
        End While
    End Sub

    Sub Cola()
        Dim cola As New Queue
    End Sub

    Sub imprimir(ByRef origen As String, ByRef leer As String, ByRef extraer As String, ByRef destino As String, ByRef Ingresar As String)
        Console.WriteLine(origen & " , " & leer & " , " & extraer & " , " & destino & " , " & Ingresar)
    End Sub
End Module
