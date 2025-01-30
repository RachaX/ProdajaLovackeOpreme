using ProdavnicaLovackeOpreme.DB;
using ProdavnicaLovackeOpreme.Models;

namespace ProdavnicaLovackeOpreme.Services
{
    public class BaseService
    {
        protected ProdavnicaContext _context;

        public BaseService()
        {
            _context = DBUtil.getContext();
        }
    }
}
