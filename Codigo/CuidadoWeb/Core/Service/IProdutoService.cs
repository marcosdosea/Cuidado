using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IProdutoService
	{
		uint Create(Produto produto);
		void Edit(Produto produto);
		void Delete(int id);
		Produto? Get(int id);
	}
}
