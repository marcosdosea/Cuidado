using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IPlanoSaudeService
	{
		uint Create(Planosaude planoSaude);
		void Edit(Planosaude planoSaude);
		void Delete(int id);
		Planosaude? Get(int id);
	}
}
