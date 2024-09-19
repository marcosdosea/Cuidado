using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface ITipoCuidadoService
	{
		uint Create(Tipocuidado tipoCuidado);
		void Edit(Tipocuidado tipoCuidado);
		void Delete(int id);
		Tipocuidado? Get(int id);
	}
}
