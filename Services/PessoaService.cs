using AutoMapper;
using Cadastro_Teleatendimento.Data.DAO.Interface;
using Cadastro_Teleatendimento.Data.DTOs.PessoaDTO;
using Cadastro_Teleatendimento.Models;
using Cadastro_Teleatendimento.Services.Interfaces;

namespace Cadastro_Teleatendimento.Services
{
  public class PessoaService : IPessoaService
  {
    private IPessoaTelefone<Pessoa> _pessoaDAO;
    private IMapper _mapper;

    public PessoaService(IPessoaTelefone<Pessoa> pessoaDAO, IMapper mapper)
    {
      _mapper = mapper;
      _pessoaDAO = pessoaDAO;
    }

    public List<ReadPessoaDto>? BuscaPessoas(int? cpf)
    {
      throw new NotImplementedException();
    }

    public ReadPessoaDto? BuscaPorId(int id)
    {
      throw new NotImplementedException();
    }

    //Post
    public ReadPessoaDto? CadastraPessoa(CreatePessoaDto pessoaDto)
    {
      if (String.IsNullOrEmpty(pessoaDto.Nome) || pessoaDto.Cpf == 0 || pessoaDto.Fk_Endereco == 0 || pessoaDto.Telefones == null)
        return null;

      List<int> telefones = pessoaDto.Telefones;

      Pessoa pessoa = _mapper.Map<Pessoa>(pessoaDto);
      var resultado = _pessoaDAO.Insira(pessoa);
      if (!resultado)
        return null;

      var newPessoa = _pessoaDAO.UltimoInsert();

      foreach (var telefone in telefones)
      {
        var resolvido = _pessoaDAO.CadastraTelefones(newPessoa.Id_Pessoa, telefone);

        if (!resolvido) break;
      }

      return _mapper.Map<ReadPessoaDto>(newPessoa);
    }
  }
}