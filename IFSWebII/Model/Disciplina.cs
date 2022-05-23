using System.ComponentModel.DataAnnotations.Schema;

namespace IFSWebII.Model
{
    public class Disciplina
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? Periodo { get; set; }
        public string? Categoria { get; set; }
        public double? Dificuldade { get; set; }
        public int? Creditos { get; set; }
        public int? HoraAula { get; set; }
        public int? HoraRelogio { get; set; }
        public int? QtdTeorica { get; set; }
        public int? QtdPratica { get; set; }
        public string? Ementa { get; set; }
        public List<Prerequisito>? Prerequisitos { get; set; }

        public Disciplina(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Disciplina(int id, string nome, int? periodo, string? categoria, 
            double? dificuldade, int? creditos, int? horaAula, int? horaRelogio, 
            int? qtdTeorica, int? qtdPratica, string? ementa) : this(id, nome)
        {
            Periodo = periodo;
            Categoria = categoria;
            Dificuldade = dificuldade;
            Creditos = creditos;
            HoraAula = horaAula;
            HoraRelogio = horaRelogio;
            QtdTeorica = qtdTeorica;
            QtdPratica = qtdPratica;
            Ementa = ementa;
        }

        public static List<Disciplina> LerCSV(string filePath)
        {
            List<Disciplina> disciplinas = new();

            using StreamReader sr = new(filePath);
            sr.ReadLine();
            do
            {
                string linha = sr.ReadLine()!;
                string[] dadosLinha = linha.Split(';');

                Disciplina disciplina = new(int.Parse(dadosLinha[1]), dadosLinha[0])
                {
                    Periodo = (dadosLinha[2] != "") ? int.Parse(dadosLinha[2]) : 0,
                    Categoria = dadosLinha[3],
                    Dificuldade = (dadosLinha[4] != "") ? double.Parse(dadosLinha[4]) : 0.0,
                    Creditos = (dadosLinha[5] != "") ? int.Parse(dadosLinha[5]) : 0,
                    HoraAula = (dadosLinha[6] != "") ? int.Parse(dadosLinha[6]) : 0,
                    HoraRelogio = (dadosLinha[7] != "") ? int.Parse(dadosLinha[7]) : 0,
                    QtdTeorica = (dadosLinha[8] != "") ? int.Parse(dadosLinha[8]) : 0,
                    QtdPratica = (dadosLinha[9] != "") ? int.Parse(dadosLinha[9]) : 0,
                    Ementa = dadosLinha[10]
                };

                disciplinas.Add(disciplina);
            }
            while (!(sr.EndOfStream));

            return disciplinas;
        }
    }
}
