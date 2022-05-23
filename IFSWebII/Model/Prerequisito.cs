using IFSWebII.Data;

namespace IFSWebII.Model
{
    public class Prerequisito
    {
        public int Id { get; set; }
        public string NomeDisciplina { get; set; }
        public string NomePrerequisito { get; set; }
        public int? Periodo { get; set; }
        public int? Creditos { get; set; }
        public int? NecessariaPara { get; set; }
        public int DisciplinaId { get; set; }

        public Prerequisito(string nomeDisciplina, string nomePrerequisito, int disciplinaId)
        {
            NomeDisciplina = nomeDisciplina;
            NomePrerequisito = nomePrerequisito;
            DisciplinaId = disciplinaId;
        }

        public Prerequisito(int id, string nomeDisciplina, string nomePrerequisito, int disciplinaId) :
            this(nomeDisciplina, nomePrerequisito, disciplinaId)
        {
            Id = id;
        }

        public Prerequisito(int id, string nomeDisciplina, string nomePrerequisito, int? periodo,
            int? creditos, int? necessariaPara, int disciplinaId) :
            this(id, nomeDisciplina, nomePrerequisito, disciplinaId)
        {
            Periodo = periodo;
            Creditos = creditos;
            NecessariaPara = necessariaPara;
        }

        public static List<Prerequisito> LerCSV(string filePath)
        {
            List<Prerequisito> prerequisitos = new();

            using StreamReader sr = new(filePath);
            sr.ReadLine();
            do
            {
                string linha = sr.ReadLine()!;
                string[] dadosLinha = linha.Split(';');

                if (int.TryParse(dadosLinha[0], out _))
                {
                    Prerequisito prerequisito = new(dadosLinha[1], dadosLinha[2], int.Parse(dadosLinha[0]))
                    {
                        Periodo = int.Parse(dadosLinha[3]),
                        Creditos = int.Parse(dadosLinha[4]),
                        NecessariaPara = int.Parse(dadosLinha[5]),
                    };

                    prerequisitos.Add(prerequisito);
                }
            }
            while (!(sr.EndOfStream));

            return prerequisitos;
        }
    }
}
