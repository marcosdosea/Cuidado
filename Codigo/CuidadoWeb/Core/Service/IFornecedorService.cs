using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IFornecedorService
	{
		uint Create(Fornecedor fornecedor);
		void Edit(Fornecedor fornecedor);
		void Delete(int id);
		Fornecedor? Get(int id);
	}
}
