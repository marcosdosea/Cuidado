using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IEspecialidadeMedicinaService
	{
		uint Create(Especialidademedicina especialidadeMedicina);
		void Edit(Especialidademedicina especialidadeMedicina);
		void Delete(int id);
		Especialidademedicina? Get(int id);
	}
}
