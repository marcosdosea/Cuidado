using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IPlanejamentoCuidadoDiarioService
	{
		uint Create(Planejamentocuidadodiario planejamentoCuidadoDiario);
		void Edit(Planejamentocuidadodiario planejamentoCuidadoDiario);
		void Delete(int id);
		Planejamentocuidadodiario? Get(int id);
	}
}
