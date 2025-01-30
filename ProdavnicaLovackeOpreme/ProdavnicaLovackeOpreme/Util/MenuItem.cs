using ProdavnicaLovackeOpreme.Commands;

namespace ProdavnicaLovackeOpreme.Util
{
    public class MenuItem
    {
        public String Text { get; set; }
        public RelayCommand Command { get; set; }
        public String Icon { get; set; }
    }
}
