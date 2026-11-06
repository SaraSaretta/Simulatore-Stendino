
using Test;

// Ciclo tutti gli indumenti del test
// Per ogni indumento cerco un filo dove può essere posizionato
// Ciclo i fili dello stendino
// Per ogni filo ciclo le sue posizioni
// Quando trovo una posizione libera, controllo se da quella posizione
// c'è abbastanza spazio libero per tutta la dimensione dell'indumento
// Se lo spazio è utilizzabile, occupo quelle posizioni con il codice dell'indumento
// Dopo aver posizionato l'indumento, passo all'indumento successivo

int numeroFili = 5;
int numeroPosizioni = 5;

string[,] stendino1 = new string[numeroFili, numeroPosizioni];
string[,] stendino2 = new string[numeroFili, numeroPosizioni];
string[,] stendino3 = new string[numeroFili, numeroPosizioni];
string[,] stendino4 = new string[numeroFili, numeroPosizioni];

var test1 = Test.Test.test1;
var test2 = Test.Test.test2;
var test3 = Test.Test.test3;
var test4 = Test.Test.test4;

Console.WriteLine("Inizio test1");
riempiStendino(test1, stendino1);
Console.WriteLine("\n Inizio test2");
riempiStendino(test2, stendino2);
Console.WriteLine("\n Inizio test3");
riempiStendino(test3, stendino3);
Console.WriteLine("\n Inizio test4");
riempiStendino(test4, stendino4);


static void riempiStendino(List<Indumento> test, string[,] stendino)
{
    var numeroFili = stendino.GetLength(0);
    var numeroPosizioni = stendino.GetLength(1);
    var codiceRimastiFuori = new List<string>();
    //e' piu facile se inizio prima da ciclare i panni (dopo non avro' problemi)
    foreach (Indumento indumento1 in test)
    {
        //indumento e' stato posizionato?
        var posizionato = false;
        //ciclo fili
        for (int i = 0; i < numeroFili; i++)
        {
            // ciclo posizioni
            for (int j = 0; j < numeroPosizioni; j++)
            {
                // controllo se posizione e' libera
                if (String.IsNullOrEmpty(stendino[i, j]))
                {
                    // se lo spazio e' utilizzabile, posso mettere indumento
                    if (j + indumento1.Dimensione <= numeroPosizioni)
                    {
                        for (int k = 0; k < indumento1.Dimensione; k++)
                        {
                            stendino[i, j + k] = indumento1.Codice;
                        }
                        posizionato = true;
                        break;
                    }
                }
            }
            // se gia ho posizionato indumento, non deve controllare altri fili
            if (posizionato)
            {
                break;
            }
        }
        if(!posizionato)
        {
            codiceRimastiFuori.Add(indumento1.Codice);

        }
    }
   
    for (int i = 0; i < numeroFili; i++)
    {
        Console.WriteLine($" ");
        for (int j = 0; j < numeroPosizioni; j++)
        {
            Console.Write($"{stendino[i, j]}");
        }
    }
    Console.WriteLine();
    Console.WriteLine("Codici rimasti fuori:");
    foreach (var codice in codiceRimastiFuori)
    {
        Console.WriteLine($"{codice}");
    }
}
Console.ReadLine();