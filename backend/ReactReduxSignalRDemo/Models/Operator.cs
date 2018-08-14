using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ReactReduxSignalRDemo.Enums;

namespace ReactReduxSignalRDemo.Models
{

    public class OperatorsContext : DbContext
    {
        public OperatorsContext(DbContextOptions<OperatorsContext> options) : base(options) { }
        public DbSet<Operator> Operators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operator>().HasData(
                new Operator { OperatorId = 1, Name = "Sledge", Type = OperatorType.Attacker.ToString(), Icon = "sledge.svg" },
                new Operator { OperatorId = 2, Name = "Thatcher", Type = OperatorType.Attacker.ToString(), Icon = "thatcher.svg" },
                new Operator { OperatorId = 3, Name = "Ash", Type = OperatorType.Attacker.ToString(), Icon = "ash.svg" },
                new Operator { OperatorId = 4, Name = "Thermite", Type = OperatorType.Attacker.ToString(), Icon = "thermite.svg" },
                new Operator { OperatorId = 5, Name = "Twitch", Type = OperatorType.Attacker.ToString(), Icon = "twitch.svg" },
                new Operator { OperatorId = 6, Name = "Montagne", Type = OperatorType.Attacker.ToString(), Icon = "montagne.svg" },
                new Operator { OperatorId = 7, Name = "Glaz", Type = OperatorType.Attacker.ToString(), Icon = "glaz.svg" },
                new Operator { OperatorId = 8, Name = "Fuze", Type = OperatorType.Attacker.ToString(), Icon = "fuze.svg" },
                new Operator { OperatorId = 9, Name = "Blitz", Type = OperatorType.Attacker.ToString(), Icon = "blitz.svg" },
                new Operator { OperatorId = 10, Name = "IQ", Type = OperatorType.Attacker.ToString(), Icon = "iq.svg" },
                new Operator { OperatorId = 11, Name = "Buck", Type = OperatorType.Attacker.ToString(), Icon = "buck.svg" },
                new Operator { OperatorId = 12, Name = "Blackbeard", Type = OperatorType.Attacker.ToString(), Icon = "blackbeard.svg" },
                new Operator { OperatorId = 13, Name = "Capitão", Type = OperatorType.Attacker.ToString(), Icon = "capitão.svg" },
                new Operator { OperatorId = 14, Name = "Hibana", Type = OperatorType.Attacker.ToString(), Icon = "hibana.svg" },
                new Operator { OperatorId = 15, Name = "Jackal", Type = OperatorType.Attacker.ToString(), Icon = "jackal.svg" },
                new Operator { OperatorId = 16, Name = "Ying", Type = OperatorType.Attacker.ToString(), Icon = "ying.svg" },
                new Operator { OperatorId = 17, Name = "Zofia", Type = OperatorType.Attacker.ToString(), Icon = "zofia.svg" },
                new Operator { OperatorId = 18, Name = "Dokkaebi", Type = OperatorType.Attacker.ToString(), Icon = "dokkaebi.svg" },
                new Operator { OperatorId = 19, Name = "Lion", Type = OperatorType.Attacker.ToString(), Icon = "lion.svg" },
                new Operator { OperatorId = 20, Name = "Finka", Type = OperatorType.Attacker.ToString(), Icon = "finka.svg" },
                new Operator { OperatorId = 21, Name = "Recruit", Type = OperatorType.Attacker.ToString(), Icon = "recruit.svg" },
                new Operator { OperatorId = 22, Name = "Smoke", Type = OperatorType.Defender.ToString(), Icon = "smoke.svg" },
                new Operator { OperatorId = 23, Name = "Mute", Type = OperatorType.Defender.ToString(), Icon = "mute.svg" },
                new Operator { OperatorId = 24, Name = "Castle", Type = OperatorType.Defender.ToString(), Icon = "castle.svg" },
                new Operator { OperatorId = 25, Name = "Pulse", Type = OperatorType.Defender.ToString(), Icon = "pulse.svg" },
                new Operator { OperatorId = 26, Name = "Doc", Type = OperatorType.Defender.ToString(), Icon = "doc.svg" },
                new Operator { OperatorId = 27, Name = "Rook", Type = OperatorType.Defender.ToString(), Icon = "rook.svg" },
                new Operator { OperatorId = 28, Name = "Kapkan", Type = OperatorType.Defender.ToString(), Icon = "kapkan.svg" },
                new Operator { OperatorId = 29, Name = "Tachanka", Type = OperatorType.Defender.ToString(), Icon = "tachanka.svg" },
                new Operator { OperatorId = 30, Name = "Jäger", Type = OperatorType.Defender.ToString(), Icon = "jäger.svg" },
                new Operator { OperatorId = 31, Name = "Bandit", Type = OperatorType.Defender.ToString(), Icon = "bandit.svg" },
                new Operator { OperatorId = 32, Name = "Frost", Type = OperatorType.Defender.ToString(), Icon = "frost.svg" },
                new Operator { OperatorId = 33, Name = "Valkyrie", Type = OperatorType.Defender.ToString(), Icon = "valkyrie.svg" },
                new Operator { OperatorId = 34, Name = "Caveira", Type = OperatorType.Defender.ToString(), Icon = "caveira.svg" },
                new Operator { OperatorId = 35, Name = "Echo", Type = OperatorType.Defender.ToString(), Icon = "echo.svg" },
                new Operator { OperatorId = 36, Name = "Mira", Type = OperatorType.Defender.ToString(), Icon = "mira.svg" },
                new Operator { OperatorId = 37, Name = "Lesion", Type = OperatorType.Defender.ToString(), Icon = "lesion.svg" },
                new Operator { OperatorId = 38, Name = "Ela", Type = OperatorType.Defender.ToString(), Icon = "ela.svg" },
                new Operator { OperatorId = 39, Name = "Vigil", Type = OperatorType.Defender.ToString(), Icon = "vigil.svg" },
                new Operator { OperatorId = 40, Name = "Maestro", Type = OperatorType.Defender.ToString(), Icon = "maestro.svg" },
                new Operator { OperatorId = 41, Name = "Alibi", Type = OperatorType.Defender.ToString(), Icon = "alibi.svg" },
                new Operator { OperatorId = 42, Name = "Recruit", Type = OperatorType.Defender.ToString(), Icon = "recruit.svg" }
            );
        }
    }

    public class Operator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OperatorId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
    }
}
