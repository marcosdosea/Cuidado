using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IFonteRendaService
	{
		uint Create(Fonterendum fonteRenda);
		void Edit(Fonterendum fonteRenda);
		void Delete(int id);
		Fonterendum? Get(int id);
	}
}
