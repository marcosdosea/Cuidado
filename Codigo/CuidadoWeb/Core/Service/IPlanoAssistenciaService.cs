using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IPlanoAssistenciaService
	{
		uint Create(Planoassistencium planoAssistencia);
		void Edit(Planoassistencium planoAssistencia);
		void Delete(int id);
		Planoassistencium? Get(int id);
	}
}
