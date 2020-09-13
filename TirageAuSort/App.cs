using Domain;
using Infrastructure.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace TirageAuSort
{
    public class App
    {
        private readonly IFileManager fileManager;
        private readonly string dateTimeNow;

        public App(IFileManager fileManager)
        {
            this.fileManager = fileManager;
            dateTimeNow = DateTime.UtcNow.ToString("yyyy-MM-ddTHH-mm-ss");
        }
        public void Run(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Erreur : mauvais nombre de paramètres ! (il faut 2 fichiers)");
                return;
            }
            IList<string> candidats = fileManager.GetData(args[0]);
            IList<string> lots = fileManager.GetData(args[1]);
            if (candidats != null && candidats.Count>0 && lots != null && lots.Count > 0)
            {
                Rng rng = new Rng(candidats, lots);
                Dictionary<string, string> tirage = rng.TirageAuSort();

                
                fileManager.WriteData("./Resultats/TirageAuSort_" + dateTimeNow + ".json", tirage);
            }
            else
            {
                Console.WriteLine("ERREUR : Un des fichiers est manquant ou vide");
            }

            fileManager.WriteData("./Resultats/CandidatsRestants_" + dateTimeNow + ".txt", candidats);
            fileManager.WriteData("./Resultats/LotsRestants_" + dateTimeNow + ".txt", lots);

        }

        
    }
}
