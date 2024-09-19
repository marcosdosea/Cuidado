using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IAquisicaoService
	{
		uint Create(Aquisicao aquisicao);
		void Edit(Aquisicao aquisicao);
		void Delete(int id);
		Aquisicao? Get(int id);
	}
}
