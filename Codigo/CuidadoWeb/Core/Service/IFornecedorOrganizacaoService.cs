using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IFornecedorOrganizacaoService
	{
		uint Create(Fornecedororganizacao fornecedorOrganizacao);
		void Edit(Fornecedororganizacao fornecedorOrganizacao);
		void Delete(int id);
		Fornecedororganizacao? Get(int id);
	}
}
