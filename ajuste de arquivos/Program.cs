using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Digite o caminho da pasta: ");
        string pasta = Console.ReadLine()!;
        string pastaDestino = Path.Combine(pasta, "Arquivos Especiais");

        // Cria a pasta de destino se não existir
        if (!Directory.Exists(pastaDestino))
        {
            Directory.CreateDirectory(pastaDestino);
        }

        // Lista de caracteres especiais
        char[] especiais = { '#', '$', '%', '&', '*', '@', '!', '?', '+' };

        // Percorre todos os arquivos da pasta
        foreach (string arquivo in Directory.GetFiles(pasta))
        {
            string nomeArquivo = Path.GetFileName(arquivo);

            // Verifica caracteres especiais no nome do arquivo
            if (nomeArquivo.Any(c => especiais.Contains(c)))
            {
                string destino = Path.Combine(pastaDestino, nomeArquivo);

                try
                {
                    // Move o arquivo para a pasta de destino
                    File.Move(arquivo, destino);
                    Console.WriteLine($"[OK] {nomeArquivo} movido para {pastaDestino}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERRO] {nomeArquivo}: {ex.Message}");
                }
            }
        }

        Console.WriteLine("Processo concluído!");
    }
}
