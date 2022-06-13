using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Реконструирование.Help
{
    public class Helper
    {
        private static ReconstructionContext _context;
        public static ReconstructionContext GetContext()
        {
            if (_context == null)
                _context = new ReconstructionContext();
            return _context;
        }
    }
}
