using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IPlanejamentoCuidadoService
	{
		uint Create(Planejamentocuidado planejamentoCuidado);
		void Edit(Planejamentocuidado planejamentoCuidado);
		void Delete(int id);
		Planejamentocuidado? Get(int id);
	}
}
