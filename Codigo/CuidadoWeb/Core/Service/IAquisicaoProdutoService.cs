using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IAquisicaoProdutoService
	{
		uint Create(Aquisicaoproduto aquisicaoProduto);
		void Edit(Aquisicaoproduto aquisicaoProduto);
		void Delete(int id);
		Aquisicaoproduto? Get(int id);
	}
}
