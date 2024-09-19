using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface ICuidadoService
	{
		uint Create(Cuidado cuidado);
		void Edit(Cuidado cuidado);
		void Delete(int id);
		Cuidado? Get(int id);
	}
}
