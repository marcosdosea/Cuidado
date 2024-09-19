using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IResponsavelService
	{
		uint Create(Responsavel responsavel);
		void Edit(Responsavel responsavel);
		void Delete(int id);
		Responsavel? Get(int id);
	}
}
