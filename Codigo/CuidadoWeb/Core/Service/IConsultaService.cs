using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IConsultaService
	{
		uint Create(Consultum consulta);
		void Edit(Consultum consulta);
		void Delete(int id);
		Consultum? Get(int id);
	}
}
