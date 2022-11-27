using AutoMapper;
using Cadastro_Teleatendimento.Data.DAO.Interface;
using Cadastro_Teleatendimento.Data.DTOs.PessoaDTO;
using Cadastro_Teleatendimento.Models;
using Cadastro_Teleatendimento.Services.Interfaces;
using FluentResults;

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

    public ReadPessoaDto? BuscaCpf(int cpf)
    {
      Pessoa? pessoa = _pessoaDAO.BuscaPorCpf(cpf);
      if (pessoa == null)
        return null;

      return _mapper.Map<ReadPessoaDto>(pessoa);
    }
    //não implementado
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
        var resolvido = _pessoaDAO.CadastraTelefones(newPessoa!.Id_Pessoa, telefone);

        if (!resolvido) break;
      }

      return _mapper.Map<ReadPessoaDto>(newPessoa);
    }

    //Delete
    public Result ExcluiPessoa(int Cpf)
    {
      var resultado = _pessoaDAO.Exclua(Cpf);
      if (!resultado)
        return Result.Fail("Item não encontrado.");

      return Result.Ok();
    }
  }
}