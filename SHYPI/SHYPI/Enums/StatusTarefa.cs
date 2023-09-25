using System.ComponentModel;

namespace SHYPI.Enums {
    public enum StatusTarefa {
        [Description("A fazer")]
        AFazer = 1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Feito")]
        Feito = 3
    }
}
