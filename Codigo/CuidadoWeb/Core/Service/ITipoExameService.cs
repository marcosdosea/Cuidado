using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface ITipoExameService
	{
		uint Create(Tipoexame tipoExame);
		void Edit(Tipoexame tipoExame);
		void Delete(int id);
		Tipoexame? Get(int id);
	}
}
