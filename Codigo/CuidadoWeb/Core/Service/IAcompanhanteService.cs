using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IAcompanhanteService
	{
		uint Create(Acompanhante acompanhante);
		void Edit(Acompanhante acompanhante);
		void Delete(int id);
		Acompanhante? Get(int id);
	}
}
