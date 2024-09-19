using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IExameService
	{
		uint Create(Exame exame);
		void Edit(Exame exame);
		void Delete(int id);
		Exame? Get(int id);
	}
}
